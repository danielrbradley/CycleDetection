using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CycleDetection
{
    public class Graph
    {
        public Graph()
        {
            this.Vertices = new List<Vertex>();
        }

        public Graph(IEnumerable<Vertex> vertices)
        {
            this.Vertices = vertices.ToList();
        }

        public ICollection<Vertex> Vertices { get; set; }
    }
}
