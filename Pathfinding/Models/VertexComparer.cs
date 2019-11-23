using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Models
{
    //TODO: delete
    /// <summary>
    /// Archived class 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VertexComparer<T> : IEqualityComparer<IVertex<T>>
    {
        /// <summary>
        /// Compares vertices using <see cref="Vertex{T}.Data"/> property.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(IVertex<T> x, IVertex<T> y)
        {
            return x.Equals(y.Data);
        }

        /// <summary>
        /// Generates hashcode using <see cref="Vertex{T}.Data"/> property.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(IVertex<T> obj)
        {
            return obj.Data.GetHashCode();
        }
    }
}
