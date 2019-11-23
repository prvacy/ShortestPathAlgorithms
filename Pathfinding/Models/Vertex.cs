using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Models
{
    public class Vertex<T> : IVertex<T> 
    {
        //TODO: write ctors
        public T Data { get; set; }


        protected internal double Distance { get; set; }
        protected internal IEdge<T> ShortestEdge { get; set; }
        protected internal bool IsParsed { get; set; }


        /// <summary>
        /// Compares vertices using <see cref="Data"/> property.
        /// </summary>
        public override bool Equals(object obj)
        {
            return this.Data.Equals((obj as IVertex<T>).Data);
        }


        /// <summary>
        /// Generates hashcode using <see cref="Data"/> property.
        /// </summary>
        public override int GetHashCode()//TODO: exception if data is null
        {
            return Data.GetHashCode();
        }

        //public void SetNeighbourVertex()
        //{

        //}
    }
}
