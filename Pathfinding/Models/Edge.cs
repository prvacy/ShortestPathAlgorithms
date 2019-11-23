
using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Models
{
    public class Edge<T> : IEdge<T>
    {
        //TODO: write ctors
        public IVertex<T> StartNode { get; set; }
        public IVertex<T> EndNode { get; set; }
        public double Distance { get; set; }

        /// <summary>
        /// Compares edges using <see cref="StartNode"/>, <see cref="EndNode"/>, <see cref="Distance"/> properties.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var edge = obj as IEdge<T>;
            return StartNode.Equals(edge.StartNode)
                && EndNode.Equals(edge.EndNode)
                && Distance.Equals(edge.Distance);
        }

        /// <summary>
        /// Generates hashcode using <see cref="StartNode"/>, <see cref="EndNode"/>, <see cref="Distance"/> properties.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (StartNode?.GetHashCode() ?? 0)
                + (EndNode?.GetHashCode() ?? 0) 
                + Distance.GetHashCode(); 
        }
    }
}
