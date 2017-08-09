using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CycleDetection
{
    public class Node<T>
    {
        // Private member-variables
        public T Value;
        public NodeList<T> Neighbors = null;

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors)
        {
            this.Value = data;
            this.Neighbors = neighbors;
        }
    }

    public class NodeList<T> : Collection<Node<T>>
    {
        public NodeList()
        { }

        public NodeList(int initialSize)
        {
            // Add the specified number of items
            for (var i = 0; i < initialSize; i++)
                Items.Add(default(Node<T>));
        }

        public Node<T> FindByValue(T value)
        {
            // search the list for the value
            foreach (Node<T> node in Items)
                if (node.Value.Equals(value))
                    return node;

            // if we reached here, we didn't find a matching node
            return null;
        }
    }

    public class GraphNode<T> : Node<T>
    {
        public GraphNode() : base() { }
        public GraphNode(T value) : base(value) { }
        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }

        new public NodeList<T> Neighbors
        {
            get { return base.Neighbors ?? (base.Neighbors = new NodeList<T>()); }
        }
    }

    public class Graph<T> : IEnumerable<T>
    {
        private NodeList<T> nodeSet;

        public Graph() : this(null) { }
        public Graph(NodeList<T> nodeSet)
        {
            this.nodeSet = nodeSet ?? new NodeList<T>();
        }

        public void AddNode(GraphNode<T> node)
        {
            // adds a node to the graph
            nodeSet.Add(node);
        }

        public void AddNode(T value)
        {
            // adds a node to the graph
            nodeSet.Add(new GraphNode<T>(value));
        }

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to)
        {
            from.Neighbors.Add(to);
        }

        public bool Contains(T value)
        {
            return nodeSet.FindByValue(value) != null;
        }

        public bool Remove(T value)
        {
            // first remove the node from the nodeset
            var nodeToRemove = (GraphNode<T>)nodeSet.FindByValue(value);
            if (nodeToRemove == null)
                // node wasn't found
                return false;

            // otherwise, the node was found
            nodeSet.Remove(nodeToRemove);

            // enumerate through each node in the nodeSet, removing edges to this node
            foreach (GraphNode<T> gnode in nodeSet)
            {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    // remove the reference to the node and associated cost
                    gnode.Neighbors.RemoveAt(index);
                }
            }

            return true;
        }

        public NodeList<T> Nodes
        {
            get
            {
                return nodeSet;
            }
        }

        public int Count
        {
            get { return nodeSet.Count; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Program
    {
        static void Main()
        {
            var web = new Graph<string>();
            web.AddNode("Privacy.htm");
            web.AddNode("People.aspx");
            web.AddNode("About.htm");
            web.AddNode("Index.htm");
            web.AddNode("Products.aspx");
            web.AddNode("Contact.aspx");

            web.AddDirectedEdge("People.aspx", "Privacy.htm");  // People -> Privacy
            web.AddDirectedEdge("Privacy.htm", "Index.htm");    // Privacy -> Index
            web.AddDirectedEdge("Privacy.htm", "About.htm");    // Privacy -> About

            web.AddDirectedEdge("About.htm", "Privacy.htm");    // About -> Privacy
            web.AddDirectedEdge("About.htm", "People.aspx");    // About -> People
            web.AddDirectedEdge("About.htm", "Contact.aspx");   // About -> Contact

            web.AddDirectedEdge("Index.htm", "About.htm");      // Index -> About
            web.AddDirectedEdge("Index.htm", "Contact.aspx");   // Index -> Contacts
            web.AddDirectedEdge("Index.htm", "Products.aspx");  // Index -> Products

            web.AddDirectedEdge("Products.aspx", "Index.htm");  // Products -> Index
            web.AddDirectedEdge("Products.aspx", "People.aspx");// Products -> People

            var cycleDetection = new CycleDetection();
            var parentNode = new DocumentReference { From = "A" };
            cycleDetection.FormLinkedList(parentNode);
            cycleDetection.Print();
            var isCycle = cycleDetection.FloydCycleDetection();
            var parents = cycleDetection.GetAllLinkedNodes(parentNode);
            Console.ReadLine();
        }
    }



    public class DocumentReference
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    public class CycleDetection
    {
        static Collection<DocumentReference> references = new Collection<DocumentReference>
                                                   {
                                                       new DocumentReference {From = "C", To = "B"},
                                                       new DocumentReference {From = "B", To = "A"},
                                                       new DocumentReference {From = "D", To = "B"},
                                                       new DocumentReference {From = "E", To = "D"}
                                                       //new DocumentReference {From = "E", To = "F"},
                                                       //new DocumentReference {From = "C", To = "G"}
                                                   };
        public LinkedList<DocumentReference> linkedList = new LinkedList<DocumentReference>();


        public IEnumerable<DocumentReference> GetAllLinkedNodes(DocumentReference reference)
        {
            var parents = references.Where(r => r.To.Equals(reference.From));
            foreach (DocumentReference documentReferenceEntity in parents)
            {
                yield return documentReferenceEntity;
                foreach (DocumentReference child in GetAllLinkedNodes(documentReferenceEntity))
                {
                    yield return child;
                }
            }
        }

        public bool FloydCycleDetection()
        {
            var tortoise = linkedList.First;
            var hare = linkedList.First;

            while (tortoise != null && hare != null)
            {
                if (tortoise == hare)
                {
                    return true;
                }
                if (hare.Next != null)
                {
                    hare = hare.Next.Next;
                }
                tortoise = tortoise.Next;
            }
            return false;
        }

        public void FormLinkedList(DocumentReference parent)
        {
            var docParent = references.Where(t => t.To.Equals(parent.From)).FirstOrDefault();
            linkedList.AddFirst(docParent);
            AddChilds(docParent);

        }

        public void AddChilds(DocumentReference parent)
        {
            var node = linkedList.Find(parent);
            var childs = references.Where(t => t.To.Equals(parent.From));
            if (childs.Count() == 0)
            {
                return;
            }
            foreach (var child in childs)
            {
                linkedList.AddAfter(node, child);
                AddChilds(child);
            }
        }

        public void Print()
        {
            foreach (var value in linkedList)
            {
                Console.WriteLine("{0} - > {1}", value.From, value.To);
            }
        }

    }
}
