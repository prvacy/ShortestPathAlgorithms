using Pathfinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pathfinding.Algoritms
{
    public static class Dijkstra
    {
        public static IEnumerable<IEdge<T>> FindShortestPath<T>(this IGraph<T> graph, IVertex<T> startVertex, IVertex<T> endVertex)
        {
            
            foreach (Vertex<T> vertex in graph.Vertices)
            {
                vertex.Distance = double.PositiveInfinity;
            }
            (startVertex as Vertex<T>).Distance = 0;

            var nodesToParse = new List<IVertex<T>>() { startVertex };


            for (int i = 0; i < nodesToParse.Count; i++)
            {
                var node = nodesToParse[i] as Vertex<T>;
                if (!node.IsParsed)
                {
                    var edges = graph.Edges.Where(e => e.StartNode == node && !node.IsParsed);
                    SetVertexShortestEdge(node, edges);
                    nodesToParse.AddRange(edges.Select(e => e.EndNode));
                    node.IsParsed = true;
                }
            }

            var currNode = endVertex as Vertex<T>;
            var result = new List<IEdge<T>>();
            while(currNode.ShortestEdge != null)
            {
                var sEdge = currNode.ShortestEdge;
                result.Add(sEdge);
                currNode = sEdge.StartNode as Vertex<T>;
            }

            return result;
        }

        private static void SetVertexShortestEdge<T>(Vertex<T> node, IEnumerable<IEdge<T>> edges)
        {
            foreach (Edge<T> edge in edges)
            {
                Vertex<T> endNode = edge.EndNode as Vertex<T>;
                var tryNewDist = edge.Distance + node.Distance;
                if (tryNewDist < endNode.Distance)
                {
                    endNode.Distance = tryNewDist;
                    endNode.ShortestEdge = edge;
                }
            }
        }

        private static void SetVertexShortestEdgeParallel<T>(Vertex<T> node, IEnumerable<IEdge<T>> edges)
        {
            edges.AsParallel().ForAll((edge) =>
            {
                Vertex<T> endNode = edge.EndNode as Vertex<T>;
                var tryNewDist = edge.Distance + node.Distance;
                if (tryNewDist < endNode.Distance)
                {
                    endNode.Distance = tryNewDist;
                    endNode.ShortestEdge = edge;                  
                }
            });
     
        }



    }
}
