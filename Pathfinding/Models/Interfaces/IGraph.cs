using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Models
{
    public interface IGraph<T>
    {
        List<IVertex<T>> Vertices { get; set; }
        List<IEdge<T>> Edges { get; set; }

    }
}
