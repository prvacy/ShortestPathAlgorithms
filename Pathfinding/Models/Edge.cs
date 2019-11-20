
using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Models
{
    public class Edge<T> : IEdge<T>
    {
        public IVertex<T> StartNode { get; set; }
        public IVertex<T> EndNode { get; set; }
        public double Distance { get; set; }
    }
}
