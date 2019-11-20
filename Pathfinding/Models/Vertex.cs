using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Models
{
    public class Vertex<T> : IVertex<T>
    {
        public T Data { get; set; }
        protected internal double Distance { get; set; }
        protected internal IEdge<T> ShortestEdge { get; set; }
        protected internal bool IsParsed { get; set; }

        //public void SetNeighbourVertex()
        //{

        //}
    }
}
