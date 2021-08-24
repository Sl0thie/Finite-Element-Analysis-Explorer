namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Numerics;

    /// <summary>
    /// MemberCollection class.
    /// </summary>
    internal class MemberCollection : ConcurrentDictionary<int, Member>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberCollection"/> class.
        /// </summary>
        internal MemberCollection()
        {
            Reset();
        }

        /// <summary>
        /// Gets or sets current member.
        /// </summary>
        internal Member CurrentMember
        {
            get
            {
                return currentMember;
            }

            set
            {
                currentMember = value;
                if (currentMember is object)
                {
                    Model.Sections.CurrentSection = currentMember.Section;
                }
            }
        }

        /// <summary>
        /// Gets or sets the next index.
        /// </summary>
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

        /// <summary>
        /// Gets the total.
        /// </summary>
        public int Total
        {
            get { return total; }
        }

        /// <summary>
        /// Gets or sets the Member tiles.
        /// </summary>
        internal ConcurrentDictionary<Tuple<int, int>, List<Tuple<int, int>>> MemberTiles { get => memberTiles; set => memberTiles = value; }

        /// <summary>
        /// Gets or sets the Members with linear loads.
        /// </summary>
        internal ConcurrentDictionary<int, Member> MembersWithLinearLoads { get => membersWithLinearLoads; set => membersWithLinearLoads = value; }

        /// <summary>
        /// Gets or sets the grid size.
        /// </summary>
        internal float GridSize { get => gridSize; set => gridSize = value; }

        private Member currentMember;
        private int nextIndex = 1;
        private int total;
        private ConcurrentDictionary<Tuple<int, int>, List<Tuple<int, int>>> memberTiles = new ConcurrentDictionary<Tuple<int, int>, List<Tuple<int, int>>>();
        private ConcurrentDictionary<int, Member> membersWithLinearLoads = new ConcurrentDictionary<int, Member>();
        private float gridSize = Options.SelectGridSize;

        /// <summary>
        /// Removes a member from the collection.
        /// </summary>
        /// <param name="indexToRemove">The index of the member.</param>
        internal void RemoveMember(int indexToRemove)
        {
            if (ContainsKey(indexToRemove))
            {
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

                if (MembersWithLinearLoads.ContainsKey(indexToRemove))
                {
                    Member tmpMember = new Member();
                    MembersWithLinearLoads.TryRemove(indexToRemove, out tmpMember);
                }

                RemoveElementFromTiles(indexToRemove, Model.Members[indexToRemove].CenterPoint);

                TryRemove(indexToRemove, out currentMember);
                currentMember = null;
                FindNextIndex();
                Model.Shrink();
                total--;
            }
        }

        /// <summary>
        /// Resets the member collection.
        /// </summary>
        internal void Reset()
        {
            Model.TotalMembers = 0;
            currentMember = null;
            Clear();
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

        /// <summary>
        /// Finds the nearest element.
        /// </summary>
        /// <param name="position">The position to find the closest member.</param>
        /// <returns>The index of element that is nearest to the position.</returns>
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
                            WService.ReportException(ex);
                        }
                    }
                }
            }

            return closestMember;
        }

        /// <summary>
        /// Adds a new element to the tiles.
        /// </summary>
        /// <param name="elementNumber">The index number of the element.</param>
        /// <param name="position">The position of the element.</param>
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

        /// <summary>
        /// Removes an element from the tiles.
        /// </summary>
        /// <param name="elementNumber">The index of the element.</param>
        /// <param name="position">The position of the element.</param>
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