using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CycleDetection
{
    public class Vertex
    {
        public int Index { get; set; }

        public int LowLink { get; set; }

        public IEnumerable<Vertex> Dependencies { get; set; }
    }
}
