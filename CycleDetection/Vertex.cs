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
            this.Index = -1;
        }

        public Vertex(IEnumerable<Vertex> dependencies)
        {
            this.Dependencies = dependencies.ToList();
            this.Index = -1;
        }

        internal int Index { get; set; }

        internal int LowLink { get; set; }

        public ICollection<Vertex> Dependencies { get; set; }
    }
}
