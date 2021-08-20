using System;
using System.Collections.Concurrent;

namespace Finite_Element_Analysis_Explorer
{
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
        /// Resets the collection.
        /// </summary>
        internal void Reset()
        {
            this.Clear();
            NodesWithNodalLoads.Clear();
            NodesWithConstraints.Clear();
            NodesWithReactions.Clear();
        }

        /// <summary>
        /// Gets a node from a position.
        /// </summary>
        /// <param name="x">The X co-ordinate.</param>
        /// <param name="y">The Y co-ordinate.</param>
        /// <returns>The node at the position.</returns>
        internal Node GetFromPosition(decimal x, decimal y)
        {
            foreach (var item in this)
            {
                if ((item.Value.Position.X == x) && (item.Value.Position.Y == y))
                {
                    return (Node)item.Value;
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
            foreach (var item in this)
            {
                if (item.Value.Index == index)
                {
                    return (Node)item.Value;
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
            if (this.ContainsKey(new Tuple<decimal, decimal>(nodeToRemove.Position.X, nodeToRemove.Position.Y)))
            {
                if (this.NodesWithConstraints.ContainsKey(nodeToRemove.Index))
                {
                    Node tempNode = new Node();
                    this.NodesWithConstraints.TryRemove(nodeToRemove.Index, out tempNode);
                }

                if (this.NodesWithNodalLoads.ContainsKey(nodeToRemove.Index))
                {
                    Node tempNode = new Node();
                    this.NodesWithNodalLoads.TryRemove(nodeToRemove.Index, out tempNode);
                }

                if (this.NodesWithReactions.ContainsKey(nodeToRemove.Index))
                {
                    Node tempNode = new Node();
                    this.NodesWithReactions.TryRemove(nodeToRemove.Index, out tempNode);
                }

                this.TryRemove(new Tuple<decimal, decimal>(nodeToRemove.Position.X, nodeToRemove.Position.Y), out nodeToRemove);
            }
        }
    }
}
