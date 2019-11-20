using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Models
{
    public interface IEdge<T>
    {
        IVertex<T> StartNode { get; set; }
        IVertex<T> EndNode { get; set; }
        double Distance { get; set; }
    }
}
