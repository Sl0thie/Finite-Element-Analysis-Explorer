namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Collections.Concurrent;

    /// <summary>
    /// NodeConcurrentCollection class.
    /// </summary>
    internal class NodeConcurrentCollection : ConcurrentDictionary<Tuple<decimal, decimal>, Node>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NodeConcurrentCollection"/> class.
        /// </summary>
        internal NodeConcurrentCollection()
        {
        }

        /// <summary>
        /// Gets or sets the nodes with loads dictionary.
        /// </summary>
        internal ConcurrentDictionary<int, Node> NodesWithNodalLoads { get; set; } = new ConcurrentDictionary<int, Node>();

        /// <summary>
        /// Gets or sets the nodes with constrains dictionary.
        /// </summary>
        internal ConcurrentDictionary<int, Node> NodesWithConstraints { get; set; } = new ConcurrentDictionary<int, Node>();

        /// <summary>
        /// Gets or sets the nodes with reactions dictionary.
        /// </summary>
        internal ConcurrentDictionary<int, Node> NodesWithReactions { get; set; } = new ConcurrentDictionary<int, Node>();

        /// <summary>
        /// Gets or sets the total no of primary nodes.
        /// </summary>
        public int NoOfPrimaryNodes { get; set; }

        /// <summary>
        /// Resets the collection.
        /// </summary>
        internal void Reset()
        {
            Clear();
            NoOfPrimaryNodes = 0;
            NodesWithNodalLoads.Clear();
            NodesWithConstraints.Clear();
            NodesWithReactions.Clear();
        }

        /// <summary>
        /// Updates the total no of primary nodes.
        /// </summary>
        internal void UpdateNoOfPrimaryNodes()
        {
            NoOfPrimaryNodes = 0;
            foreach (System.Collections.Generic.KeyValuePair<Tuple<decimal, decimal>, Node> item in this)
            {
                if (item.Value.IsPrimary)
                {
                    NoOfPrimaryNodes++;
                }
            }
        }

        /// <summary>
        /// Gets a node from a position.
        /// </summary>
        /// <param name="x">The X co-ordinate.</param>
        /// <param name="y">The Y co-ordinate.</param>
        /// <returns>The node at the position.</returns>
        internal Node GetFromPosition(decimal x, decimal y)
        {
            foreach (System.Collections.Generic.KeyValuePair<Tuple<decimal, decimal>, Node> item in this)
            {
                if ((item.Value.Position.X == x) && (item.Value.Position.Y == y))
                {
                    return item.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets a node from the index.
        /// </summary>
        /// <param name="index">The index of the node.</param>
        /// <returns>The node at that index.</returns>
        internal Node GetFromIndex(int index)
        {
            foreach (System.Collections.Generic.KeyValuePair<Tuple<decimal, decimal>, Node> item in this)
            {
                if (item.Value.Index == index)
                {
                    return item.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Removes a node from the dictionary.
        /// </summary>
        /// <param name="nodeToRemove">The node to remove.</param>
        internal void RemoveNode(Node nodeToRemove)
        {
            if (ContainsKey(new Tuple<decimal, decimal>(nodeToRemove.Position.X, nodeToRemove.Position.Y)))
            {
                if (NodesWithConstraints.ContainsKey(nodeToRemove.Index))
                {
                    Node tempNode = new Node();
                    NodesWithConstraints.TryRemove(nodeToRemove.Index, out tempNode);
                }

                if (NodesWithNodalLoads.ContainsKey(nodeToRemove.Index))
                {
                    Node tempNode = new Node();
                    NodesWithNodalLoads.TryRemove(nodeToRemove.Index, out tempNode);
                }

                if (NodesWithReactions.ContainsKey(nodeToRemove.Index))
                {
                    Node tempNode = new Node();
                    NodesWithReactions.TryRemove(nodeToRemove.Index, out tempNode);
                }

                TryRemove(new Tuple<decimal, decimal>(nodeToRemove.Position.X, nodeToRemove.Position.Y), out nodeToRemove);
            }
        }
    }
}