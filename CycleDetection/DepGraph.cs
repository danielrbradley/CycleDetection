using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CycleDetection
{
    public class DepGraph
    {
        public DepGraph()
        {
            this.Vertices = new List<Vertex>();
        }

        public DepGraph(IEnumerable<Vertex> vertices)
        {
            this.Vertices = vertices.ToList();
        }

        public ICollection<Vertex> Vertices { get; set; }
    }
}
