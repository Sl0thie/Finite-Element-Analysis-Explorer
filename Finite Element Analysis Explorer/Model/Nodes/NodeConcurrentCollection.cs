using System;
using System.Collections.Concurrent;

namespace Finite_Element_Analysis_Explorer
{
    internal class NodeConcurrentCollection : ConcurrentDictionary<Tuple<decimal, decimal>, Node>
    {
        internal NodeConcurrentCollection()
        {
        }

        /// <summary>
        /// Dictionaries.
        /// </summary>
        internal ConcurrentDictionary<int, Node> NodesWithNodalLoads = new ConcurrentDictionary<int, Node>();
        internal ConcurrentDictionary<int, Node> NodesWithConstraints = new ConcurrentDictionary<int, Node>();
        internal ConcurrentDictionary<int, Node> NodesWithReactions = new ConcurrentDictionary<int, Node>();

        internal void Reset()
        {
            this.Clear();
            NodesWithNodalLoads.Clear();
            NodesWithConstraints.Clear();
            NodesWithReactions.Clear();
        }

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
