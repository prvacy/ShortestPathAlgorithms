
using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Models
{
    public class Graph<T> : IGraph<T>
    {
        public List<IVertex<T>> Vertices { get; set; } = new List<IVertex<T>>();
        public List<IEdge<T>> Edges { get; set; } = new List<IEdge<T>>();


    }


}
