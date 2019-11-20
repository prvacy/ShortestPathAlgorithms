using Pathfinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pathfinding.Algoritms
{
    public static class Dijkstra
    {
        public static IEdge<T> FindShortestPath<T>(this IGraph<T> graph, IVertex<T> startVertex, IVertex<T> endVertex)
        {

            foreach (Vertex<T> vertex in graph.Vertices)
            {
                vertex.Distance = double.PositiveInfinity;
            }
            (startVertex as Vertex<T>).Distance = 0;

            var nodesToParse = new List<IVertex<T>>() { startVertex };
            //do
            //{
            //    foreach (Vertex<T> node in nodesToParse)
            //    {
            //        var edges = graph.Edges.Where(e => e.StartNode == node && !node.IsParsed);
            //        nodesToParse.AddRange(edges.Select(e => e.EndNode));
            //        node.IsParsed = true;
                    
            //    }
                
            //}
            //while (currNode != endVertex);

            for (int i = 0; i < nodesToParse.Count; i++)
            {
                var node = nodesToParse[i] as Vertex<T>;
                var edges = graph.Edges.Where(e => e.StartNode == node && !node.IsParsed);
                FindShortestEdge(node, edges);

                nodesToParse.AddRange(edges.Select(e => e.EndNode));          
                node.IsParsed = true;
            }

            

            return (endVertex as Vertex<T>).ShortestEdge;
        }

        private static void FindShortestEdge<T>(Vertex<T> currNode, IEnumerable<IEdge<T>> edges)
        {

            foreach (Edge<T> edge in edges)
            {
                Vertex<T> endNode = edge.EndNode as Vertex<T>;
                var tryNewDist = edge.Distance + currNode.Distance;
                if ((tryNewDist) < endNode.Distance)
                {
                    endNode.Distance = tryNewDist;
                    endNode.ShortestEdge = edge;
                }
            }

            
        }


    }
}
