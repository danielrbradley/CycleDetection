using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CycleDetection
{
    public class Graph<T>
    {
        public Graph()
        {
            this.Vertices = new List<Vertex<T>>();
        }

        public Graph(IEnumerable<Vertex<T>> vertices)
        {
            this.Vertices = vertices.ToList();
        }

        public ICollection<Vertex<T>> Vertices { get; set; }
    }
}
