using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Models
{
    public interface IGraph<T>
    {
        HashSet<IVertex<T>> Vertices { get; set; }
        HashSet<IEdge<T>> Edges { get; set; }

    }
}
