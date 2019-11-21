using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pathfinding.Algoritms;
using Pathfinding.GraphSources;
using Pathfinding.Models;
using System.Collections.Generic;
using System.Linq;

namespace PathFindingTest
{
    internal class VertexT<T> : Vertex<T>
    {
        internal IEdge<T> aShortest;
        public VertexT()
        {
            aShortest = ShortestEdge;
        }
    }

    [TestClass]
    public class CheckGraphPathfinding
    {

        [TestMethod]
        public void Check_StartVertex_HasNo_ShortestPath()
        {
            var a = new VertexT<string>();
            var b = new Vertex<string>();
            var result = GenerateResult(a, b, new[] { new Edge<string>(), new Edge<string>() });
            Assert.IsNull(a.aShortest);
        }

        [TestMethod]
        public void Is_FindedPath_Shortest()
        {
            var a = new Vertex<string>();
            var b = new Vertex<string>();
            var ab = new Edge<string>();
            var bd = new Edge<string>();
            var expectedPath = new List<IEdge<string>> { ab, bd };

            var actualPath = GenerateResult(a, b, expectedPath);

            CollectionAssert.AreEqual(expectedPath, actualPath.Reverse().ToList());
        }

        [TestMethod]
        public void Is_FindedPath_Shortest_Xml()
        {
            var path = @"../../../testGraph.xml";
            var graph = XmlSource.GetGraphFromXml(path);

            var kyiv = graph.Vertices.Find(v => v.Data == "Kyiv");
            var tokyo = graph.Vertices.Find(v => v.Data == "Tokyo");

            var lviv = graph.Vertices.Find(v => v.Data == "Lviv");

            
            var expPath = new List<IEdge<string>>()
            {
                graph.Edges.Find(e => e.StartNode == kyiv && e.EndNode == lviv),
                graph.Edges.Find(e => e.StartNode == lviv && e.EndNode == tokyo)
            };

            var actualPath = graph.FindShortestPath(kyiv, tokyo).Reverse().ToList();
            CollectionAssert.AreEqual(expPath, actualPath);
        }

        private IEnumerable<IEdge<string>> GenerateResult(IVertex<string> start, IVertex<string> end, IEnumerable<IEdge<string>> path)
        {
            var gr = new Graph<string>();
            //     b
            var a = start;               //   ↗   ↘
            var b = new Vertex<string>();// a       d
            var c = new Vertex<string>();//   ↘   ↗       
            var d = end;                 //     c

            //a -> b 1
            var ab = path.First();
            ab.StartNode = a;
            ab.EndNode = b;
            ab.Distance = 1;

            //a -> c 4
            var ac = new Edge<string>();
            ac.StartNode = a;
            ac.EndNode = c;
            ac.Distance = 4;

            //b -> d 2
            var bd = path.Last();
            bd.StartNode = b;
            bd.EndNode = d;
            bd.Distance = 2;

            //c -> d 1
            var cd = new Edge<string>();
            cd.StartNode = c;
            cd.EndNode = d;
            cd.Distance = 1;

            gr.Vertices.AddRange(new[] { a, b, c, d });
            gr.Edges.AddRange(new[] { ab, ac, bd, cd });

            var result = gr.FindShortestPath(a, d);
            return result;
        }


    }
}
