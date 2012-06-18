using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CycleDetection
{
    public class TarjanCycleDetect
    {
        private List<List<Vertex>> stronglyConnectedComponents;
        private Stack<Vertex> stack;
        private int index;

        public List<List<Vertex>> DetectCycle(DepGraph g)
        {
            stronglyConnectedComponents = new List<List<Vertex>>();
            index = 0;
            stack = new Stack<Vertex>();
            foreach (Vertex v in g.Vertices)
            {
                if (v.Index < 0)
                {
                    StrongConnect(v);
                }
            }
            return stronglyConnectedComponents;
        }

        private void StrongConnect(Vertex v)
        {
            v.Index = index;
            v.LowLink = index;
            index++;
            stack.Push(v);

            foreach (Vertex w in v.Dependencies)
            {
                if (w.Index < 0)
                {
                    StrongConnect(w);
                    v.LowLink = Math.Min(v.LowLink, w.LowLink);
                }
                else if (stack.Contains(w))
                {
                    v.LowLink = Math.Min(v.LowLink, w.Index);
                }
            }

            if (v.LowLink == v.Index)
            {
                List<Vertex> scc = new List<Vertex>();
                Vertex w;
                do
                {
                    w = stack.Pop();
                    scc.Add(w);
                } while (v != w);
                stronglyConnectedComponents.Add(scc);
            }

        }
    }
}
