using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Finite_Element_Analysis_Explorer
{
    internal class MemberCollection : ConcurrentDictionary<int, Member>
    {
        internal MemberCollection()
        {
            Reset();
        }

        private Member currentMember;

        internal Member CurrentMember
        {
            get
            {
                return currentMember;
            }

            set
            {
                currentMember = value;
                if (!object.ReferenceEquals(null, currentMember))
                {
                    Model.Sections.CurrentSection = currentMember.Section;
                }
            }
        }

        private int nextIndex = 1;

        internal int NextIndex
        {
            get
            {
                FindNextIndex();
                return nextIndex;
            }

            set
            {
                nextIndex = value;
            }
        }

        public ConcurrentDictionary<Tuple<int, int>, List<Tuple<int, int>>> MemberTiles = new ConcurrentDictionary<Tuple<int, int>, List<Tuple<int, int>>>();
        public ConcurrentDictionary<int, Member> MembersWithLinearLoads = new ConcurrentDictionary<int, Member>();

        public float GridSize = Options.SelectGridSize;

        private int total;

        public int Total
        {
            get { return total; }

            // set { total = value; }
        }

        internal void RemoveMember(int indexToRemove)
        {
            if (this.ContainsKey(indexToRemove))
            {
                // foreach (Segment nextSegment in Model.Members[indexToRemove].Segments)
                // {
                //    if (!nextSegment.NodeNear.IsPrimary)
                //    {
                //        Model.Nodes.RemoveNode(nextSegment.NodeNear);
                //    }
                //    if (!nextSegment.NodeFar.IsPrimary)
                //    {
                //        Model.Nodes.RemoveNode(nextSegment.NodeFar);
                //    }
                // }
                foreach (var item in Model.Members[indexToRemove].Segments)
                {
                    if (!item.Value.NodeNear.IsPrimary)
                    {
                        Model.Nodes.RemoveNode(item.Value.NodeNear);
                    }

                    if (!item.Value.NodeFar.IsPrimary)
                    {
                        Model.Nodes.RemoveNode(item.Value.NodeFar);
                    }
                }

                if (this.MembersWithLinearLoads.ContainsKey(indexToRemove))
                {
                    // MembersWithLinearLoads.Remove(indexToRemove);
                    Member tmpMember = new Member();
                    MembersWithLinearLoads.TryRemove(indexToRemove, out tmpMember);
                }

                RemoveElementFromTiles(indexToRemove, Model.Members[indexToRemove].CenterPoint);

                this.TryRemove(indexToRemove, out currentMember);
                currentMember = null;
                FindNextIndex();
                Model.Shrink();
                total--;
            }
        }

        // internal Member AddNewMember(Node _nearNode, Node _farNode, Section _section, int _totalSegments, decimal _LDLNear, decimal _LDLFar)
        // {
        //    int nextIndexToUse = nextIndex;
        //    if (this.ContainsKey(nextIndexToUse))
        //    {
        //        Debug.WriteLine("Index is already in use");
        //    }

        // Member newMember = new Member(nextIndexToUse, _nearNode, _farNode, _section, _totalSegments, _LDLNear, _LDLFar);
        //    if (!TryAdd(newMember.Index, newMember)) { Debug.WriteLine("AddNewMember TryAdd Failed"); }
        //    //AddNewElementToTiles(newMember.Index, newMember.CenterPoint);
        //    FindNextIndex();
        //    total++;
        //    return newMember;
        // }

        // internal Member AddNewMemberToIndex(int _index, Node _nearNode, Node _farNode, Section _section, int _totalSegments, decimal _LDLNear, decimal _LDLFar)
        // {
        //    Member newMember = new Member(_index, _nearNode, _farNode, _section, _totalSegments, _LDLNear, _LDLFar);
        //    //TryAdd(_index, newMember);
        //    if (!TryAdd(_index, newMember)) { Debug.WriteLine("AddNewMemberToIndex TryAdd Failed"); }
        //    //AddNewElementToTiles(newMember.Index, newMember.CenterPoint);
        //    FindNextIndex();

        // total++;
        //    return newMember;
        // }
        internal void Reset()
        {
            Model.TotalMembers = 0;
            this.currentMember = null;
            this.Clear();
            nextIndex = 1;
            MemberTiles.Clear();
            MembersWithLinearLoads.Clear();
        }

        private void FindNextIndex()
        {
            for (int i = 1; i < Count + 1; i++)
            {
                if (!ContainsKey(i))
                {
                    nextIndex = i;
                    return;
                }
            }

            nextIndex = Count + 1;
            return;
        }

        public int FindNearestElement(Vector2 position)
        {
            int dimX = Convert.ToInt32(position.X / GridSize);
            int dimY = Convert.ToInt32(position.Y / GridSize);
            int closestMember = -1;
            double closestLength = double.MaxValue;
            int totalChecked = 0;

            List<Tuple<int, int>> grids = new List<Tuple<int, int>>();
            grids.Add(new Tuple<int, int>(dimX - 1, dimY - 1));
            grids.Add(new Tuple<int, int>(dimX, dimY - 1));
            grids.Add(new Tuple<int, int>(dimX + 1, dimY - 1));
            grids.Add(new Tuple<int, int>(dimX - 1, dimY));
            grids.Add(new Tuple<int, int>(dimX, dimY));
            grids.Add(new Tuple<int, int>(dimX + 1, dimY));
            grids.Add(new Tuple<int, int>(dimX - 1, dimY + 1));
            grids.Add(new Tuple<int, int>(dimX, dimY + 1));
            grids.Add(new Tuple<int, int>(dimX + 1, dimY + 1));

            foreach (Tuple<int, int> grid in grids)
            {
                List<Tuple<int, int>> iTmp = null;
                if (MemberTiles.ContainsKey(grid))
                {
                    iTmp = MemberTiles[grid];
                    foreach (Tuple<int, int> nextInt in iTmp)
                    {
                        try
                        {
                            totalChecked++;
                            double nextLength = Vector2.DistanceSquared(position, Model.Members[nextInt.Item1].Segments[nextInt.Item2].CenterPointDisplaced);
                            if (nextLength < closestLength)
                            {
                                closestMember = nextInt.Item1;
                                closestLength = nextLength;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("ElementAreas Error " + ex.Message);
                        }
                    }
                }
            }

            return closestMember;
        }

        public void AddNewElementToTiles(int elementNumber, Vector2 position)
        {
            foreach (var item in Model.Members[elementNumber].Segments)
            {
                Tuple<int, int> position2D = new Tuple<int, int>(Convert.ToInt32(item.Value.CenterPointDisplaced.X / GridSize), Convert.ToInt32(item.Value.CenterPointDisplaced.Y / GridSize));
                List<Tuple<int, int>> iTmp = null;

                if (MemberTiles.ContainsKey(position2D))
                {
                    iTmp = MemberTiles[position2D];
                    iTmp.Add(new Tuple<int, int>(elementNumber, item.Value.Index));
                }
                else
                {
                    List<Tuple<int, int>> newList = new List<Tuple<int, int>>();
                    newList.Add(new Tuple<int, int>(elementNumber, item.Value.Index));
                    if (!MemberTiles.TryAdd(position2D, newList))
                    {
                        Debug.WriteLine("TryAdd Failed");
                    }
                }
            }
        }

        public void RemoveElementFromTiles(int elementNumber, Vector2 position)
        {
            foreach (var item in Model.Members[elementNumber].Segments)
            {
                Tuple<int, int> position2D = new Tuple<int, int>(Convert.ToInt32(item.Value.CenterPointDisplaced.X / GridSize), Convert.ToInt32(item.Value.CenterPointDisplaced.Y / GridSize));
                if (MemberTiles.ContainsKey(position2D))
                {
                    List<Tuple<int, int>> iTmp = MemberTiles[position2D];
                    iTmp.Remove(new Tuple<int, int>(elementNumber, item.Value.Index));
                }
            }
        }
    }
}