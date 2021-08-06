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
            int DimY = Convert.ToInt32(position.Y / GridSize);

            int ClosestMember = -1;
            double ClosestLength = double.MaxValue;

            int TotalChecked = 0;

            List<Tuple<int, int>> Grids = new List<Tuple<int, int>>();
            Grids.Add(new Tuple<int, int>(dimX - 1, DimY - 1));
            Grids.Add(new Tuple<int, int>(dimX, DimY - 1));
            Grids.Add(new Tuple<int, int>(dimX + 1, DimY - 1));
            Grids.Add(new Tuple<int, int>(dimX - 1, DimY));
            Grids.Add(new Tuple<int, int>(dimX, DimY));
            Grids.Add(new Tuple<int, int>(dimX + 1, DimY));
            Grids.Add(new Tuple<int, int>(dimX - 1, DimY + 1));
            Grids.Add(new Tuple<int, int>(dimX, DimY + 1));
            Grids.Add(new Tuple<int, int>(dimX + 1, DimY + 1));

            foreach (Tuple<int, int> grid in Grids)
            {
                List<Tuple<int, int>> ITmp = null;
                if (MemberTiles.ContainsKey(grid))
                {
                    ITmp = MemberTiles[grid];
                    foreach (Tuple<int, int> nextInt in ITmp)
                    {
                        try
                        {
                            TotalChecked++;
                            double NextLength = Vector2.DistanceSquared(position, Model.Members[nextInt.Item1].Segments[nextInt.Item2].CenterPointDisplaced);

                            // Debug.WriteLine("Check Distance " + NextInt.Item1 + " " + NextInt.Item2 + " " + NextLength);
                            if (NextLength < ClosestLength)
                            {
                                ClosestMember = nextInt.Item1;
                                ClosestLength = NextLength;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("ElementAreas Error " + ex.Message);
                        }
                    }
                }
            }

            Debug.WriteLine("Closest Member " + ClosestMember + " " + TotalChecked);
            return ClosestMember;
        }

        public void AddNewElementToTiles(int ElementNumber, Vector2 position)
        {
            Debug.WriteLine("AddNewElementToTiles " + ElementNumber + " " + Model.Members[ElementNumber].Segments.Count);

            // foreach(Segment nextSegment in Model.Members[ElementNumber].Segments)
            // {
            //    Tuple<int, int> Position = new Tuple<int, int>(Convert.ToInt32(nextSegment.CenterPointDisplaced.X / GridSize), Convert.ToInt32(nextSegment.CenterPointDisplaced.Y / GridSize));
            //    List<Tuple<int, int>> ITmp = null;

            // if (MemberTiles.ContainsKey(Position))
            //    {
            //        Debug.WriteLine("Update Position " + Position.ToString());

            // ITmp = MemberTiles[Position];
            //        ITmp.Add(new Tuple<int, int>(ElementNumber, nextSegment.Index));
            //    }
            //    else
            //    {
            //        Debug.WriteLine("New Position " + Position.ToString());
            //        //List<int> NewList = new List<int>();
            //        List<Tuple<int, int>> NewList = new List<Tuple<int, int>>();
            //        NewList.Add(new Tuple<int, int>(ElementNumber,nextSegment.Index));
            //        MemberTiles.TryAdd(Position, NewList);
            //    }
            // }
            foreach (var item in Model.Members[ElementNumber].Segments)
            {

                Tuple<int, int> Position = new Tuple<int, int>(Convert.ToInt32(item.Value.CenterPointDisplaced.X / GridSize), Convert.ToInt32(item.Value.CenterPointDisplaced.Y / GridSize));
                List<Tuple<int, int>> iTmp = null;

                if (MemberTiles.ContainsKey(Position))
                {
                    Debug.WriteLine("Update Position " + ElementNumber + " " + item.Key + " " + Position.ToString() + " " + item.Value.CenterPointDisplaced.ToString());

                    iTmp = MemberTiles[Position];
                    iTmp.Add(new Tuple<int, int>(ElementNumber, item.Value.Index));
                }
                else
                {
                    Debug.WriteLine("New    Position " + ElementNumber + " " + item.Key + " " + Position.ToString() + " " + item.Value.CenterPointDisplaced.ToString());

                    // List<int> NewList = new List<int>();
                    List<Tuple<int, int>> newList = new List<Tuple<int, int>>();
                    newList.Add(new Tuple<int, int>(ElementNumber, item.Value.Index));

                    // MemberTiles.TryAdd(Position, NewList);
                    if (!MemberTiles.TryAdd(Position, newList))
                    {
                        Debug.WriteLine("TryAdd Failed");
                    }
                }
            }
        }

        public void RemoveElementFromTiles(int ElementNumber, Vector2 position)
        {
            // foreach (Segment nextSegment in Model.Members[ElementNumber].Segments)
            // {
            //    Tuple<int, int> Position = new Tuple<int, int>(Convert.ToInt32(nextSegment.CenterPointDisplaced.X / GridSize), Convert.ToInt32(nextSegment.CenterPointDisplaced.Y / GridSize));
            //    if (MemberTiles.ContainsKey(Position))
            //    {
            //        List<Tuple<int, int>> ITmp = MemberTiles[Position];
            //        ITmp.Remove(new Tuple<int, int>(ElementNumber, nextSegment.Index));
            //    }
            // }
            foreach (var item in Model.Members[ElementNumber].Segments)
            {
                Tuple<int, int> Position = new Tuple<int, int>(Convert.ToInt32(item.Value.CenterPointDisplaced.X / GridSize), Convert.ToInt32(item.Value.CenterPointDisplaced.Y / GridSize));
                if (MemberTiles.ContainsKey(Position))
                {
                    List<Tuple<int, int>> iTmp = MemberTiles[Position];
                    iTmp.Remove(new Tuple<int, int>(ElementNumber, item.Value.Index));
                }
            }
        }

        // public int FindNearestElement(Vector2 position)
        // {
        //    int DimX = Convert.ToInt32(position.X / GridSize);
        //    int DimY = Convert.ToInt32(position.Y / GridSize);

        // int ClosestNode = -1;
        //    double ClosestLength = double.MaxValue;

        // List<Tuple<int, int>> Grids = new List<Tuple<int, int>>();
        //    Grids.Add(new Tuple<int, int>(DimX - 1, DimY - 1));
        //    Grids.Add(new Tuple<int, int>(DimX, DimY - 1));
        //    Grids.Add(new Tuple<int, int>(DimX + 1, DimY - 1));
        //    Grids.Add(new Tuple<int, int>(DimX - 1, DimY));
        //    Grids.Add(new Tuple<int, int>(DimX, DimY));
        //    Grids.Add(new Tuple<int, int>(DimX + 1, DimY));
        //    Grids.Add(new Tuple<int, int>(DimX - 1, DimY + 1));
        //    Grids.Add(new Tuple<int, int>(DimX, DimY + 1));
        //    Grids.Add(new Tuple<int, int>(DimX + 1, DimY + 1));

        // foreach (Tuple<int, int> Grid in Grids)
        //    {
        //        List<int> ITmp = null;
        //        if (MemberTiles.ContainsKey(Grid))
        //        {
        //            ITmp = MemberTiles[Grid];
        //            foreach (int NextInt in ITmp)
        //            {
        //                try
        //                {
        //                    double NextLength = Vector2.DistanceSquared(position, Model.Members[NextInt].CenterPoint);
        //                    if (NextLength < ClosestLength)
        //                    {
        //                        ClosestNode = NextInt;
        //                        ClosestLength = NextLength;
        //                    }
        //                }
        //                catch (Exception ex) { Debug.WriteLine("ElementAreas Error " + ex.Message); }
        //            }
        //        }
        //    }

        // Debug.WriteLine("Closest Member " + ClosestNode);

        // return ClosestNode;
        // }

        // public void AddNewElementToTiles(int ElementNumber, Vector2 position)
        // {
        //    Tuple<int, int> Position = new Tuple<int, int>(Convert.ToInt32(position.X / GridSize), Convert.ToInt32(position.Y / GridSize));
        //    List<int> ITmp = null;

        // if (MemberTiles.ContainsKey(Position))
        //    {
        //        ITmp = MemberTiles[Position];
        //        ITmp.Add(ElementNumber);
        //    }
        //    else
        //    {
        //        List<int> NewList = new List<int>();
        //        NewList.Add(ElementNumber);
        //        MemberTiles.Add(Position, NewList);
        //    }
        // }

        // public void RemoveElementFromTiles(int ElementNumber, Vector2 position)
        // {
        //    Tuple<int, int> Position = new Tuple<int, int>(Convert.ToInt32(position.X / GridSize), Convert.ToInt32(position.Y / GridSize));
        //    if (MemberTiles.ContainsKey(Position))
        //    {
        //        List<int> ITmp = MemberTiles[Position];
        //        ITmp.Remove(ElementNumber);
        //    }
        // }
    }
}