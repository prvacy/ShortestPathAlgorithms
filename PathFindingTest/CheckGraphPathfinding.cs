using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pathfinding.Algoritms;
using Pathfinding.Models;

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
            var result = GenerateResult(a, b);
            Assert.IsNull(a.aShortest);
        }

        [TestMethod]
        public void Is_FindedPath_Shortest()
        {
            var a = new Vertex<string>();
            var b = new Vertex<string>();
            var result = GenerateResult(a, b);
            Assert.AreEqual(result, 2);
        }

        private double GenerateResult(IVertex<string> start, IVertex<string> end)
        {
            var gr = new Graph<string>();
                                         //     b
            var a = start;               //   ↗   ↘
            var b = new Vertex<string>();// a       d
            var c = new Vertex<string>();//   ↘   ↗       
            var d = end;                 //     c

            //a -> b 1
            var ab = new Edge<string>();
            ab.StartNode = a;
            ab.EndNode = b;
            ab.Distance = 1;

            //a -> c 4
            var ac = new Edge<string>();
            ac.StartNode = a;
            ac.EndNode = c;
            ac.Distance = 4;

            //b -> d 2
            var bd = new Edge<string>();
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

            var result = gr.FindShortestPath(a, d).Distance;
            return result;
        }
    }
}
