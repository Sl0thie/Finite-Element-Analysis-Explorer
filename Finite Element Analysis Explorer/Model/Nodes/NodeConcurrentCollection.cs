using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Finite_Element_Analysis_Explorer
{
    internal class NodeConcurrentCollection : ConcurrentDictionary<Tuple<decimal, decimal>, Node>
    {
        internal NodeConcurrentCollection()
        {

        }

        /// <summary>
        /// Dictionaries
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

        internal Node GetFromPosition(decimal X, decimal Y)
        {
            foreach (var Item in this)
            {
                if ((Item.Value.Position.X == X) && (Item.Value.Position.Y == Y))
                {
                    return (Node)Item.Value;
                }
            }
            return null;
        }

        internal Node GetFromIndex(int index)
        {
            foreach (var Item in this)
            {
                if (Item.Value.Index == index)
                {
                    return (Node)Item.Value;
                }
            }
            return null;
        }

        internal void RemoveNode(Node NodeToRemove)
        {
            if (this.ContainsKey(new Tuple<decimal, decimal>(NodeToRemove.Position.X, NodeToRemove.Position.Y)))
            {
                if (this.NodesWithConstraints.ContainsKey(NodeToRemove.Index))
                {
                    Node tempNode = new Node();
                    this.NodesWithConstraints.TryRemove(NodeToRemove.Index, out tempNode);
                }

                if (this.NodesWithNodalLoads.ContainsKey(NodeToRemove.Index))
                {
                    Node tempNode = new Node();
                    this.NodesWithNodalLoads.TryRemove(NodeToRemove.Index, out tempNode);
                }

                if (this.NodesWithReactions.ContainsKey(NodeToRemove.Index))
                {
                    Node tempNode = new Node();
                    this.NodesWithReactions.TryRemove(NodeToRemove.Index, out tempNode);
                }

                this.TryRemove(new Tuple<decimal, decimal>(NodeToRemove.Position.X, NodeToRemove.Position.Y), out NodeToRemove);
            }
        }
    }
}
