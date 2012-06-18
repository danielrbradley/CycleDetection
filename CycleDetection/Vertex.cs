using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CycleDetection
{
    public class Vertex
    {
        public Vertex()
        {
            this.Dependencies = new List<Vertex>();
        }

        public Vertex(IEnumerable<Vertex> dependencies)
        {
            this.Dependencies = dependencies.ToList();
        }

        public int Index { get; set; }

        public int LowLink { get; set; }

        public ICollection<Vertex> Dependencies { get; set; }
    }
}
