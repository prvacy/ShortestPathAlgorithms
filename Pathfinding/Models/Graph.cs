
using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Models
{
    public class Graph<T> : IGraph<T>
    {
        //TODO: write ctors
        public HashSet<IVertex<T>> Vertices { get; set; } = new HashSet<IVertex<T>>();
        public HashSet<IEdge<T>> Edges { get; set; } = new HashSet<IEdge<T>>();

    }


}
