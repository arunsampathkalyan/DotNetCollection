using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace GenericSinglyLinkedList
{
    public class Node
    {
        public int item;
        public Node leftc;
        public Node rightc;
    }

    public class Tree
    {
        public Node root;
        public Tree()
        {
            root = null;
        }

        public Node ReturnRoot()
        {
            return root;
        }

        public void Insert(int id)
        {

            var newNode = new Node { item = id };

            if (root == null)
                root = newNode;
            else
            {
                Node current = root;
                Node parent;

                while (true)
                {
                    parent = current;
                    if (id < current.item)
                    {
                        current = current.leftc;
                        if (current == null)
                        {
                            parent.leftc = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightc;
                        if (current == null)
                        {
                            parent.rightc = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public void Inorder(Node Root)
        {
            if (Root != null)
            {
                Inorder(Root.leftc);
                Console.Write(Root.item + " ");
                Inorder(Root.rightc);
            }
        }
    }
     

    public class DocumentReference
    {
        public string ReferenceId { get; set; }
        public int SectionVersion { get; set; }
        public int RefToSectionVersion { get; set; }
        public string SectionPath { get; set; }
        public string RefToSectionPath { get; set; }
        public bool IsParent { get; set; }
    }

    class Program
    {
        //static Collection<DocumentReference> references = new Collection<DocumentReference>
        //                                           {
        //                                               new DocumentReference {From = "A", To = "B"},
        //                                               new DocumentReference {From = "F", To = "B"},
        //                                               new DocumentReference {From = "B", To = "B1"},
        //                                               new DocumentReference {From = "B", To = "B2"},
        //                                               new DocumentReference {From = "B", To = "B3"},
        //                                               new DocumentReference {From = "B3", To = "E"}
        //                                           };
        readonly static Collection<DocumentReference> references = new Collection<DocumentReference>
                                                   {
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefA\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefB\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1},
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefB\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefC\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1},
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefB\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefD\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1},
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefD\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefE\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1},
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefF\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefB\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1}
                                                   };

        static Tree<string> Root;

        static Collection<DocumentReference> Roots = new Collection<DocumentReference>();


        static HashSet<string> ChildNodePaths = new HashSet<string>();

        public static string GetSDSTopLevelNodePath(string sdsSectionPath)
        {
            string[] pathArray = sdsSectionPath.Split('\\');
            string returnPath = string.Empty;
            int sdsPathCount = 0;
            int index = 0;

            while (sdsPathCount < 2 && index < pathArray.Count())
            {
                returnPath = Path.Combine(returnPath, pathArray[index]);

                if (pathArray[index++].ToUpper().Equals("SDS"))
                {
                    sdsPathCount++;
                }

            }

            if (index >= pathArray.Count())
                throw new Exception("Unable to get SDS top level node path from path: " + sdsSectionPath);

            returnPath = Path.Combine(returnPath, pathArray[index]);

            return returnPath;
        }

        static void Main(string[] args)
        {
            var path = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_refB\PRODUCT AND COMPANY IDENTIFICATION\Product Identifier\Chemical Family|1";
            var curNodePath = GetSDSTopLevelNodePath(path);
            var nodePath = path.Substring(2);
            var version = path.Split('|').Last();
            //var test2 = GetAllChildNodes(new DocumentReference { From = "B", To = "D" });
           // var test = GetAllChildLinkedNodes("E");
            var testNew = GetAllChildLinkedNodes(@"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefE",true);
            int number_no_nodes, source = 1;
            Root = new Tree<string>("B");
            try
            {
                number_no_nodes = 5;
                var adjacencyMatrix = new int[6 + 1, 6 + 1];
                adjacencyMatrix[1, 1] = 0;
                adjacencyMatrix[1, 2] = 0;
                adjacencyMatrix[1, 3] = 0;
                adjacencyMatrix[1, 4] = 0;
                adjacencyMatrix[1, 5] = 1;
                adjacencyMatrix[1, 6] = 1;

                adjacencyMatrix[2, 1] = 1;
                adjacencyMatrix[2, 2] = 0;
                adjacencyMatrix[2, 3] = 0;
                adjacencyMatrix[2, 4] = 0;
                adjacencyMatrix[2, 5] = 0;
                adjacencyMatrix[2, 6] = 0;

                adjacencyMatrix[3, 1] = 1;
                adjacencyMatrix[3, 2] = 0;
                adjacencyMatrix[3, 3] = 0;
                adjacencyMatrix[3, 4] = 0;
                adjacencyMatrix[3, 5] = 0;
                adjacencyMatrix[3, 6] = 0;

                adjacencyMatrix[4, 1] = 0;
                adjacencyMatrix[4, 2] = 0;
                adjacencyMatrix[4, 3] = 1;
                adjacencyMatrix[4, 4] = 0;
                adjacencyMatrix[4, 5] = 0;
                adjacencyMatrix[4, 6] = 0;

                adjacencyMatrix[5, 1] = 0;
                adjacencyMatrix[5, 2] = 0;
                adjacencyMatrix[5, 3] = 0;
                adjacencyMatrix[5, 4] = 0;
                adjacencyMatrix[5, 5] = 0;
                adjacencyMatrix[5, 6] = 0;

                adjacencyMatrix[6, 1] = 1;
                adjacencyMatrix[6, 2] = 0;
                adjacencyMatrix[6, 3] = 0;
                adjacencyMatrix[6, 4] = 0;
                adjacencyMatrix[6, 5] = 0;
                adjacencyMatrix[6, 6] = 0;


                var iscycledetected = (new TopoCycle()).CheckCycle(adjacencyMatrix, 1);
            }
            catch (Exception inputMismatch)
            {

                Console.WriteLine("Wrong Input format");

            }


            var theTree = new Tree();

            theTree.Insert(10);
            theTree.Insert(20);
            theTree.Insert(30);
            theTree.Insert(40);
            theTree.Insert(50);

            Console.WriteLine("Inorder Traversal : ");

            theTree.Inorder(theTree.ReturnRoot());

            Console.WriteLine(" ");

            Console.ReadLine();


            var listNode = new ListNode<DocumentReference>(new DocumentReference { SectionPath = "B", RefToSectionPath = "A" })
                               {
                                   Next = new ListNode<DocumentReference>(new DocumentReference { SectionPath = "A" })
                               };
        }

        private static void PrintMatrix(ref int[,] matrix, int Count)
        {
            Console.Write("       ");
            for (int i = 0; i < Count; i++)
            {
                Console.Write("{0}  ", (char)('A' + i));
            }

            Console.WriteLine();

            for (int i = 0; i < Count; i++)
            {
                Console.Write("{0}   [ ", (char)('A' + i));

                for (int j = 0; j < Count; j++)
                {
                    if (i == j)
                    {
                        Console.Write(" {0} ", matrix[i, j]);
                    }
                    else if (matrix[i, j] == null)
                    {
                        Console.Write(" .,");
                    }
                    else
                    {
                        Console.Write(" {0} ", matrix[i, j]);
                    }

                }
                Console.Write(" ]\r\n");
            }
            Console.Write("\r\n");
            Console.ReadLine();
        }

        //public IEnumerable<Node> GetAllOwnerSdsNodes()
        //{
        //    return _dict.SelectMany(kvp => kvp.Value).Select(kvp => kvp.Value.SdsNode);
        //}

        public static IEnumerable<DocumentReference> GetAllChildLinkedNodes(string nodePath, bool isNew = true)
        {
            var parentPaths = new Collection<DocumentReference>();
            GetAllParentNodes(nodePath, parentPaths,references);
            return parentPaths;
        }


        public static void GetAllParentNodes(string nodePath, Collection<DocumentReference> nodePaths, Collection<DocumentReference> references)
        {
            var parents = references.Where(r => r.RefToSectionPath.StartsWith(nodePath)).ToList();
            for (var i = parents.Count() - 1; i >= 0; i--)
            {
                nodePaths.Add(parents[i]);
                references.Remove(parents[i]);
                GetAllParentNodes(parents[i].SectionPath, nodePaths,references);
                GetAllChildsOfNodes(parents[i].RefToSectionPath, nodePaths, references);
            }
        }

        public static void GetAllChildsOfNodes(string nodePath, Collection<DocumentReference> nodePaths, Collection<DocumentReference> references)
        {
            var childs = references.Where(r => r.SectionPath.StartsWith(nodePath) && !nodePaths.Any(n => n.Equals(r))).ToList();
            for (var i = childs.Count() - 1; i >= 0; i--)
            {
                nodePaths.Add(childs[i]);
                GetAllChildsOfNodes(childs[i].RefToSectionPath, nodePaths, references);
            }
        }

        public static IEnumerable<string> GetAllChildLinkedNodes(string nodePath)
        {
            var parentPaths = new HashSet<string>();
            GetAllParentNodes(nodePath, parentPaths);
            return parentPaths;
        }


        public static void GetAllParentNodes(string nodePath, HashSet<string> nodePaths)
        {
            var parents = references.Where(r => r.RefToSectionPath.Equals(nodePath)).ToList();
            for (var i = parents.Count() - 1; i >= 0; i--)
            {
                nodePaths.Add(parents[i].SectionPath);
                references.Remove(parents[i]);
                GetAllParentNodes(parents[i].SectionPath, nodePaths);
                GetAllChildsOfNodes(parents[i].RefToSectionPath, nodePaths);
            }
        }

        public static void GetAllChildsOfNodes(string nodePath, HashSet<string> nodePaths)
        {
            var childs = references.Where(r => r.SectionPath.Equals(nodePath) && !nodePaths.Any(n => n.Equals(r.RefToSectionPath))).ToList();
            for (var i = childs.Count() - 1; i >= 0; i--)
            {
                nodePaths.Add(childs[i].RefToSectionPath);
                GetAllChildsOfNodes(childs[i].RefToSectionPath, nodePaths);
            }
        }

        //public static IEnumerable<DocumentReference> GetAllParentNodes(string nodePath, HashSet<string> nodePaths)
        //{
        //    var parents = references.Where(r => r.To.Equals(nodePath)).ToList();
        //    for (var i = parents.Count() - 1; i >= 0; i--)
        //    {
        //        nodePaths.Add(parents[i].From);
        //        references.Remove(parents[i]);
        //        var childs = GetAllParentNodes(parents[i].From, nodePaths);
        //        if (childs != null)
        //        {
        //            foreach (var grandParent in childs)
        //            {
        //                nodePaths.Add(grandParent.To);
        //                references.Remove(grandParent);
        //            }
        //        }
        //    }
        //    return null;
        //}



        public static IEnumerable<DocumentReference> GetAllLinkedNodes(DocumentReference reference)
        {

            var documentReferences = references.Where(r => r.RefToSectionPath.Equals(reference.RefToSectionPath)).ToList();
            documentReferences.AddRange(references.Where(r => r.SectionPath.Equals(reference.SectionPath)));

            if (documentReferences.Count == 0)
            {
                return null;
            }

            var parentAndChilds = references.Select(r =>
                                                {
                                                    if (r.RefToSectionPath.Equals(reference.SectionPath) && !r.Equals(reference))
                                                    {
                                                        r.IsParent = true;
                                                    }
                                                    return r;
                                                }).ToList();

            parentAndChilds.AddRange(references.Where(r => r.SectionPath.Equals(reference.RefToSectionPath) && !r.Equals(reference)));

            foreach (var documentReferenceEntity in parentAndChilds)
            {
                Roots.Add(documentReferenceEntity);
                references.Remove(documentReferenceEntity);

                var childs = GetAllLinkedNodes(documentReferenceEntity);

                if (childs != null)
                {
                    foreach (var child in GetAllLinkedNodes(documentReferenceEntity))
                    {
                        Roots.Add(child);
                        references.Remove(child);
                    }
                }
            }
            return null;
        }

        public static IEnumerable<DocumentReference> GetAllChildNodes(DocumentReference reference)
        {
            var parents = references.Where(r => r.RefToSectionPath.Equals(reference.RefToSectionPath));
            foreach (DocumentReference documentReferenceEntity in parents)
            {
                Roots.Add(documentReferenceEntity);
                references.Remove(documentReferenceEntity);

                var childs = GetAllLinkedNodes(documentReferenceEntity);
                if (childs != null)
                {
                    foreach (DocumentReference child in childs)
                    {
                        Roots.Add(child);
                        references.Remove(child);
                    }
                }
            }
            return null;
        }
    }

    public class ListNode<T>
    {
        private ListNode<T> next;
        private T item;

        public ListNode<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        public ListNode(T item)
            : this(item, null)
        {
        }

        public ListNode(T item, ListNode<T> next)
        {
            this.item = item;
            this.next = next;
        }

        public override string ToString()
        {
            if (item == null)
                return string.Empty;
            return item.ToString();
        }
    }

    public class SinglyLinkedList<T> : ICollection<T>
    {
        private ListNode<T> firstNode;
        private ListNode<T> lastNode;
        private int count;
        private string _strListName;

        public ListNode<T> FirstNode
        {
            get { return firstNode; }
        }

        public ListNode<T> LastNode
        {
            get { return lastNode; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0)
                    throw new ArgumentOutOfRangeException();
                ListNode<T> currentNode = firstNode;
                for (int i = 0; i < index; i++)
                {
                    if (currentNode.Next == null)
                        throw new ArgumentOutOfRangeException();
                    currentNode = currentNode.Next;
                }
                return currentNode.Item;
            }
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsEmpty
        {
            get
            {
                lock (this)
                {
                    return firstNode == null;
                }
            }
        }

        /// <summary>
        /// Constructor initializing list with a provided list name
        /// </summary>
        /// <param name="strListName"></param>

        public SinglyLinkedList(string strListName)
        {
            this._strListName = strListName;
            count = 0;
            firstNode = lastNode = null;
        }

        /// <summary>
        /// default constructor initializing list with a default name 'MyList'
        /// </summary>

        public SinglyLinkedList() : this("MyList") { }
        /// <summary>
        /// Operation ToString overridden to get the contents from the list
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            if (IsEmpty)
                return string.Empty;
            var returnString = new StringBuilder();
            foreach (T item in this)
            {
                if (returnString.Length > 0)
                    returnString.Append("->");
                returnString.Append(item);
            }
            return returnString.ToString();
        }

        public void InsertAtFront(T item)
        {
            lock (this)
            {
                if (IsEmpty)
                    firstNode = lastNode = new ListNode<T>(item);
                else
                    firstNode = new ListNode<T>(item, firstNode);
                count++;
            }
        }

        public void InsertAtBack(T item)
        {
            lock (this)
            {
                if (IsEmpty)
                    firstNode = lastNode = new ListNode<T>(item);
                else
                    lastNode = lastNode.Next = new ListNode<T>(item);
                count++;
            }
        }

        public object RemoveFromFront()
        {
            lock (this)
            {
                if (IsEmpty)
                    throw new ApplicationException("list is empty");
                object removedData = firstNode.Item;
                if (firstNode == lastNode)
                    firstNode = lastNode = null;
                else
                    firstNode = firstNode.Next;
                count--;
                return removedData;
            }
        }

        public object RemoveFromBack()
        {
            lock (this)
            {
                if (IsEmpty)
                    throw new ApplicationException("list is empty");
                object removedData = lastNode.Item;
                if (firstNode == lastNode)
                    firstNode = lastNode = null;
                else
                {
                    ListNode<T> currentNode = firstNode;
                    while (currentNode.Next != lastNode)
                        currentNode = currentNode.Next;
                    lastNode = currentNode;
                    currentNode.Next = null;
                }
                count--;
                return removedData;
            }
        }

        public void InsertAt(int index, T item)
        {
            lock (this)
            {
                if (index > count || index < 0)
                    throw new ArgumentOutOfRangeException();
                if (index == 0)
                    InsertAtFront(item);
                else if (index == (count - 1))
                    InsertAtBack(item);
                else
                {
                    ListNode<T> currentNode = firstNode;
                    for (int i = 0; i < index - 1; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    ListNode<T> newNode = new ListNode<T>(item, currentNode.Next);
                    currentNode.Next = newNode;
                    count++;
                }
            }
        }

        public object RemoveAt(int index)
        {
            lock (this)
            {
                if (index > count || index < 0)
                    throw new ArgumentOutOfRangeException();
                object removedData;
                if (index == 0)
                    removedData = RemoveFromFront();
                else if (index == (count - 1))
                    removedData = RemoveFromBack();
                else
                {
                    ListNode<T> currentNode = firstNode;
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode.Next;
                    }
                    removedData = currentNode.Item;
                    currentNode.Next = currentNode.Next.Next;
                    count--;
                }
                return removedData;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (firstNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromFront();
                return true;
            }
            else if (lastNode.Item.ToString().Equals(item.ToString()))
            {
                RemoveFromBack();
                return true;
            }
            else
            {
                ListNode<T> currentNode = firstNode;
                while (currentNode.Next != null)
                {
                    if (currentNode.Next.Item.ToString().Equals(item.ToString()))
                    {
                        currentNode.Next = currentNode.Next.Next;
                        count--;
                        if (currentNode.Next == null)
                            lastNode = currentNode;
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }

        public bool Update(T oldItem, T newItem)
        {
            lock (this)
            {
                ListNode<T> currentNode = firstNode;
                while (currentNode != null)
                {
                    if (currentNode.ToString().Equals(oldItem.ToString()))
                    {
                        currentNode.Item = newItem;
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
                return false;
            }
        }

        public bool Contains(T item)
        {
            lock (this)
            {
                ListNode<T> currentNode = firstNode;
                while (currentNode != null)
                {
                    if (currentNode.Item.ToString().Equals(item.ToString()))
                    {
                        return true;
                    }
                    currentNode = currentNode.Next;
                }
                return false;
            }
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            firstNode = lastNode = null;
            count = 0;
        }

        public void Reverse()
        {
            if (firstNode == null || firstNode.Next == null)
                return;
            lastNode = firstNode;
            ListNode<T> prevNode = null;
            ListNode<T> currentNode = firstNode;
            ListNode<T> nextNode = firstNode.Next;

            while (currentNode != null)
            {
                currentNode.Next = prevNode;
                if (nextNode == null)
                    break;
                prevNode = currentNode;
                currentNode = nextNode;
                nextNode = nextNode.Next;
            }
            firstNode = currentNode;
        }

        public bool HasCycle()
        {
            ListNode<T> currentNode = firstNode;
            ListNode<T> iteratorNode = firstNode;
            for (; iteratorNode != null && iteratorNode.Next != null;
                iteratorNode = iteratorNode.Next)
            {
                if (currentNode.Next == null ||
                    currentNode.Next.Next == null) return false;
                if (currentNode.Next == iteratorNode ||
                    currentNode.Next.Next == iteratorNode) return true;
                currentNode = currentNode.Next.Next;
            }
            return false;
        }

        public ListNode<T> GetMiddleItem()
        {
            ListNode<T> currentNode = firstNode;
            ListNode<T> iteratorNode = firstNode;
            for (; iteratorNode != null && iteratorNode.Next != null;
                iteratorNode = iteratorNode.Next)
            {
                if (currentNode.Next == null ||
                    currentNode.Next.Next == null) return iteratorNode;
                if (currentNode.Next == iteratorNode ||
                    currentNode.Next.Next == iteratorNode) return null;
                currentNode = currentNode.Next.Next;
            }
            return firstNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> currentNode = firstNode;
            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    public class TreeNode<T>
    {
        public T Value;
        public List<TreeNode<T>> Parents;
        public List<TreeNode<T>> Childrens;
        public bool HasParent;

        public TreeNode(T value)
        {
            Value = value;
            Childrens = new List<TreeNode<T>>();
            Parents = new List<TreeNode<T>>();
        }

    }


    public class Tree<T>
    {
        public static TreeNode<T> Root;
        public Tree(T value)
        {
            Root = new TreeNode<T>(value);
        }

        public TreeNode<T> AddChildren(TreeNode<T> child)
        {
            child.HasParent = true;
            Root.Childrens.Add(child);
            return child;
        }

        public TreeNode<T> AddParent(TreeNode<T> parent)
        {
            Root.Parents.Add(parent);
            return parent;
        }

        public TreeNode<T> GetChild(int index)
        {
            return Root.Childrens[index];
        }
    }

    public class TopoCycle
    {
        private readonly Stack<int> _stack;

        public TopoCycle()
        {
            _stack = new Stack<int>();
        }

        public bool CheckCycle(int[,] adjacencyMatrix, int source)
        {
            var numberOfNodes = 5;
            var topologicalSort = new int[numberOfNodes + 1];
            var pos = 1;
            var visited = new int[numberOfNodes + 1];
            var i = source;

            visited[source] = 1;
            _stack.Push(source);

            while (_stack.Count != 0)
            {
                var element = _stack.Peek();
                while (i <= numberOfNodes)
                {
                    if (adjacencyMatrix[element, i] == 1 && visited[i] == 1)
                    {
                        if (_stack.Contains(i))
                        {
                            Console.WriteLine("The Graph Contains a cycle");
                            return true;
                        }
                    }

                    if (adjacencyMatrix[element, i] == 1 && visited[i] == 0)
                    {
                        _stack.Push(i);
                        visited[i] = 1;
                        element = i;
                        i = 1;
                        continue;
                    }
                    i++;
                }
                var j = _stack.Pop();
                topologicalSort[pos++] = j;
                i = ++j;
            }
            Console.WriteLine("The Graph does not Contain cycle");
            return false;
        }
    }
}
