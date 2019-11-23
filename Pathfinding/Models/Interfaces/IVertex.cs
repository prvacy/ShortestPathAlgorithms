using System;
using System.Collections.Generic;
using System.Text;

namespace Pathfinding.Models
{
    public interface IVertex<T> 
    {
        T Data { get; set; }

        //TODO: think about this methods
        //public bool Equals(object obj);
        //public int GetHashCode();
    }
}
