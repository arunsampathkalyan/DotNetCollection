using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace AdjacencyMatrix
{
    public class Edge
    {
        public int Weigth;
        public Vertex Parent;
        public Vertex Child;
    }

    public class Graph
    {
        public HashSet<Vertex> AllVertices = new HashSet<Vertex>();

        public Vertex CreateVertex(string name)
        {
            var vertex = new Vertex(name);
            var added = AllVertices.Add(vertex);
            return added ? vertex : null;
        }

        public Vertex GetVertex(string name)
        {
            return AllVertices.Where(v => v.Name.Equals(name)).FirstOrDefault();
        }

        public int[,] CreateAdjacencyMatrix()
        {
            var adj = new int[AllVertices.Count, AllVertices.Count];
            var allVertices = AllVertices.ToList();

            for (var i = 0; i < allVertices.Count; i++)
            {
                var v1 = allVertices[i];

                for (var j = 0; j < allVertices.Count; j++)
                {
                    var v2 = allVertices[j];

                    var arc = v1.Edges.FirstOrDefault(a => a.Child == v2);

                    if (arc != null)
                    {
                        adj[i, j] = arc.Weigth;
                    }
                }
            }
            return adj;
        }

        //public static IEnumerable<Vertex> FindAllConnectedParents(Graph graph, Vertex temp, List<Vertex> neighbors)
        //{
        //    foreach (var neighbor in temp.Edges)
        //    {
        //        yield return neighbor.Child;
        //        foreach (var vertex in FindAllParents(graph, neighbor.Child, neighbors))
        //        {
        //            yield return vertex;
        //        }
        //    }
        //}

    }

    public class Vertex : IEquatable<Vertex>
    {
        public string Name;

        public List<Edge> Edges = new List<Edge>();

        public bool IsVisited { set; get; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public bool Equals(Vertex other)
        {
            return Name.Equals(other.Name);
        }

        public Vertex(string name)
        {
            Name = name;
        }

        public Vertex AddEdge(Vertex child)
        {
            Edges.Add(new Edge
            {
                Parent = this,
                Child = child,
                Weigth = 1
            });
            return this;
        }

        public void RemoveEdge(Vertex child)
        {
            var removeReference = Edges.Where(r => r.Child.Equals(child)).FirstOrDefault();
            Edges.Remove(removeReference);
        }
    }

    public class DocumentReference
    {
        public string ReferenceId { get; set; }
        public string SectionPath { get; set; }
        public int SectionVersion { get; set; }
        public string RefToSectionPath { get; set; }
        public int RefToSectionVersion { get; set; }
    }

    class MainProgram
    {
        readonly static Collection<DocumentReference> References = new Collection<DocumentReference>
                                                   {
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefL\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefK\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1},
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefM\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefN\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1},
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefC\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefB\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1},
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefB\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefA\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1},
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefD\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefB\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1},
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefE\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefD\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1},
                                                       new DocumentReference {SectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefB\COMPOSITION / INFORMATION ON INGREDIENTS\Composition", RefToSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefF\COMPOSITION / INFORMATION ON INGREDIENTS\Composition",SectionVersion = 1,RefToSectionVersion = 1}
                                                   };

        static void Main(string[] args)
        {
            var graph = new Graph();
            var currentSectionPath = @"W\Base\ChemAdvisor\EHSAT\Customer\ChemADVISOR\SDS\SDS\EHSAT_RefE\COMPOSITION / INFORMATION ON INGREDIENTS\Composition";
            var currentSectionVersion = 1;
            var cyclicDocumentReferences = GetCyclicDocumentReferences(graph, currentSectionPath, currentSectionVersion);

        }

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

        public static List<string> GetCyclicDocumentReferences(Graph graph, string currentSectionPath, int currentSectionVersion)
        {
            CreateVertices(graph);
            foreach (var selectedReference in References)
            {
                var selectedVertex = graph.GetVertex(GetSDSTopLevelNodePath(selectedReference.SectionPath.Substring(2)) + "|" + selectedReference.SectionVersion);
                selectedVertex.AddEdge(graph.GetVertex(GetSDSTopLevelNodePath(selectedReference.RefToSectionPath.Substring(2)) + "|" + selectedReference.RefToSectionVersion));
            }

            var selectVertex = graph.GetVertex(GetSDSTopLevelNodePath(currentSectionPath.Substring(2)) + "|" + currentSectionVersion);
            var excludeDocuments = new List<string>();

            var neighbors = new List<Vertex>();
           // var neighborss=  Graph.FindAllConnected(graph, selectVertex, neighbors);

            foreach (var node in graph.AllVertices)
            {
                if (!node.Name.Equals(selectVertex.Name))
                {
                    selectVertex.AddEdge(graph.GetVertex(node.Name));
                    int[,] adjacencyMatrix = graph.CreateAdjacencyMatrix();
                    Console.WriteLine("{0} -> {1}", selectVertex.Name, node.Name);
                    //var iscycleCreated = (new CycleAlgorithm()).TopologicalSort(adjacencyMatrix, 0, graph.AllVertices.Count);
                    var visited = new int[graph.AllVertices.Count];
                    var iscycleCreated = (new CycleAlgorithm()).Dfs(adjacencyMatrix);
                    if (iscycleCreated)
                    {
                        excludeDocuments.Add(node.Name);
                    }
                    selectVertex.RemoveEdge(graph.GetVertex(node.Name));
                }
            }
            return excludeDocuments;
        }

        public static void CreateVertices(Graph graph)
        {
            foreach (var documentReference in References)
            {
                graph.CreateVertex(GetSDSTopLevelNodePath(documentReference.SectionPath.Substring(2)) + "|" + documentReference.SectionVersion);
                graph.CreateVertex(GetSDSTopLevelNodePath(documentReference.RefToSectionPath.Substring(2)) + "|" + documentReference.RefToSectionVersion);
            }
        }
    }

    public class CycleAlgorithm
    {
        private readonly Stack<int> _stack;

        public CycleAlgorithm()
        {
            _stack = new Stack<int>();
        }

        public bool TopologicalSort(int[,] adjacencyMatrix, int source, int numberOfNodes)
        {
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

        public bool Dfs(int[,] adjacencyMatrix)
        {
            var length = adjacencyMatrix.GetLength(0);
            var isVisited = false;
            var visited = new int[length];
            visited[5] = 1;
            _stack.Push(5);

            while (_stack.Count() != 0)
            {
                var source = _stack.Peek();
                var destination = 0;
                isVisited = false;

                while (destination < length)
                {
                    if (adjacencyMatrix[source, destination] == 1 && visited[destination] == 1)
                    {
                        if (_stack.Contains(destination))
                        {
                            Console.WriteLine("Dfs : The Graph contains cycle");
                            return true;
                        }
                    }

                    if (adjacencyMatrix[source, destination] == 1 && visited[destination] == 0)
                    {
                        _stack.Push(destination);
                        visited[destination] = 1;
                        adjacencyMatrix[source, destination] = 0;
                        source = destination;
                        destination = 0;
                        continue;
                    }

                    destination++;
                }
                var pop = _stack.Pop();

                //if (_stack.Count() == 0)
                //{
                //    visited[pop] = 1;
                //    for (var i = 0; i < visited.Length; i++)
                //    {
                //        if (visited[i] == 0)
                //        {
                //            _stack.Push(i);
                //            isVisited = true;
                //            break;
                //        }
                //    }
                //}
            }
            Console.WriteLine("DFS : The Graph does not Contain cycle");
            return false;
        }

        public bool DfsCycle(int[,] adjacencyMatrix, int[] visited, int startIndex)
        {
            var length = adjacencyMatrix.GetLength(0);
            visited[startIndex] = 1;
            _stack.Push(startIndex);

            while (_stack.Count() != 0)
            {
                var source = _stack.Peek();
                var destination = source;

                while (destination < length)
                {
                    if (adjacencyMatrix[source, destination] == 1 && visited[destination] == 1)
                    {
                        if (_stack.Contains(destination))
                        {
                            return true;
                        }
                    }

                    if (adjacencyMatrix[source, destination] == 1 && visited[destination] == 0)
                    {
                        _stack.Push(destination);
                        visited[destination] = 1;
                        adjacencyMatrix[source, destination] = 0;
                        source = destination;
                        destination = 0;
                        continue;
                    }

                    destination++;
                }
                var pop = _stack.Pop();

                if (_stack.Count() == 0)
                {
                    visited[pop] = 1;
                    for (var i = 0; i < visited.Length; i++)
                    {
                        if (visited[i] == 0)
                        {
                            DfsCycle(adjacencyMatrix, visited, i);
                            break;
                        }
                    }
                }
            }
            return false;
        }
    }
}
