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

            var nodesToParse = new Queue<IVertex<T>>();
            nodesToParse.Enqueue(startVertex as Vertex<T>);


            while(nodesToParse.Count > 0)
            {
                var node = nodesToParse.Dequeue() as Vertex<T>;
                if (!node.IsParsed)
                {
                    var edges = graph.Edges.Where(e => e.StartNode == node && !node.IsParsed);
                    TrySetNewDistance(node, edges);
                    foreach (var childNode in edges.Select(e => e.EndNode))
                    {
                        nodesToParse.Enqueue(childNode);
                    }

                    node.IsParsed = true;
                }
            }

            var lastNode = endVertex as Vertex<T>;
            var result = new List<IEdge<T>>();
            while(lastNode.ShortestEdge != null)
            {
                var sEdge = lastNode.ShortestEdge;
                result.Add(sEdge);
                lastNode = sEdge.StartNode as Vertex<T>;
            }

            result.Reverse();
            return result;
        }

        /// <summary>
        /// Try set new distance for <paramref name="nodeToParse"/> childs.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodeToParse">Node to parse.</param>
        /// <param name="nodeEdges">Node child edges.</param>
        private static void TrySetNewDistance<T>(Vertex<T> nodeToParse, IEnumerable<IEdge<T>> nodeEdges)
        {
            foreach (Edge<T> edge in nodeEdges)
            {
                Vertex<T> endNode = edge.EndNode as Vertex<T>;
                var tryNewDist = edge.Distance + nodeToParse.Distance;
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
