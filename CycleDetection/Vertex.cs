using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CycleDetection
{
    public abstract class Vertex
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

    public class Vertex<T> : Vertex
    {
        public Vertex()
            : base()
        {
        }

        public Vertex(T value)
            : base()
        {
            this.Value = value;
        }

        public Vertex(IEnumerable<Vertex> dependencies)
            : base(dependencies)
        {
        }

        public Vertex(T value, IEnumerable<Vertex> dependencies)
            : base(dependencies)
        {
            this.Value = value;
        }

        public T Value { get; set; }
    }
}
