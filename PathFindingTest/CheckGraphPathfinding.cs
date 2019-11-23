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
            var a = new VertexT<string>() { Data="a"};
            var b = new Vertex<string>() { Data = "b"};
            var result = GenerateResult(a, b, new[] { new Edge<string>(), new Edge<string>() });
            Assert.IsNull(a.aShortest);
        }

        [TestMethod]
        public void Is_FindedPath_Shortest()
        {
            var a = new Vertex<string>() { Data = "a" };
            var d = new Vertex<string>() { Data = "d" };

            var ab = new Edge<string>() {  };
            var bd = new Edge<string>() { };
            var expectedPath = new List<IEdge<string>> { ab, bd };

            var actualPath = GenerateResult(a, d, expectedPath);

            CollectionAssert.AreEqual(expectedPath, actualPath.Reverse().ToList());
        }

        //TODO: correct mistakes

        [TestMethod]
        public void Is_FindedPath_Shortest_Xml()
        {
            var path = @"../../../testGraph.xml";
            var graph = XmlSource.GetGraphFromXml(path);

            IVertex<string> kyiv;
            graph.Vertices.TryGetValue(new Vertex<string>() { Data = "Kyiv" }, out kyiv);//TODO: Write hashset Find or something like this

            IVertex<string> tokyo;
            graph.Vertices.TryGetValue(new Vertex<string>() { Data = "Tokyo" }, out tokyo);

            IVertex<string> lviv;
            graph.Vertices.TryGetValue(new Vertex<string>() { Data = "Lviv" }, out lviv);


            IEdge<string> kl;
            graph.Edges.TryGetValue(new Edge<string>() { StartNode = kyiv, EndNode = lviv, Distance = 3 }, out kl);

            IEdge<string> lt;
            graph.Edges.TryGetValue(new Edge<string>() { StartNode = lviv, EndNode = tokyo, Distance = 1 }, out lt);
            var expPath = new List<IEdge<string>>() { kl, lt };

            var actualPath = graph.FindShortestPath(kyiv, tokyo).Reverse().ToList();
            CollectionAssert.AreEqual(expPath, actualPath);
        }

        private IEnumerable<IEdge<string>> GenerateResult(IVertex<string> start, IVertex<string> end, IEnumerable<IEdge<string>> path)
        {
            var gr = new Graph<string>();
            //     b
            //   ↗   ↘
            // a       d
            //   ↘   ↗  
            //     c
            var a = start;               
            var b = new Vertex<string>() { Data = "b"};
            var c = new Vertex<string>() { Data = "c"};     
            var d = end;                 

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

            var vertices = new HashSet<IVertex<string>>(new[] { a, b, c, d });
            gr.Vertices = vertices;

            var edges = new HashSet<IEdge<string>>(new[] { ab, ac, bd, cd });
            gr.Edges = edges;

            var result = gr.FindShortestPath(a, d);
            return result;
        }


    }
}
