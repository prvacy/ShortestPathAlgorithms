using System;

using Pathfinding.Models;
using Pathfinding.Algoritms;
using System.Collections.Generic;
using System.Linq;

namespace Aviacompany
{
    class Program
    {
        static void Main(string[] args)
        {
            var gr = new Graph<string>();

            var a = new Vertex<string>();//
            var b = new Vertex<string>();// a -> b -> c
            var c = new Vertex<string>();//            

            var e = new Edge<string>();
            e.StartNode = a;
            e.EndNode = b;
            e.Distance = 1;

            var e2 = new Edge<string>();
            e2.StartNode = b;
            e2.EndNode = c;
            e.Distance = 2;

            gr.Vertices.AddRange(new[] { a, b, c });
            gr.Edges.AddRange(new[] { e, e2 });
            gr.FindShortestPath(a, b);
            Console.WriteLine();
        }
    }
}
