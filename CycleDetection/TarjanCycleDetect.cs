using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CycleDetection
{
    public class TarjanCycleDetect
    {
        private static List<List<Vertex>> StronglyConnectedComponents;
        private static Stack<Vertex> S;
        private static int index;
        private static DepGraph dg;
        public static List<List<Vertex>> DetectCycle(DepGraph g)
        {
            StronglyConnectedComponents = new List<List<Vertex>>();
            index = 0;
            S = new Stack<Vertex>();
            dg = g;
            foreach (Vertex v in g.Vertices)
            {
                if (v.Index < 0)
                {
                    strongconnect(v);
                }
            }
            return StronglyConnectedComponents;
        }

        private static void strongconnect(Vertex v)
        {
            v.Index = index;
            v.LowLink = index;
            index++;
            S.Push(v);

            foreach (Vertex w in v.Dependencies)
            {
                if (w.Index < 0)
                {
                    strongconnect(w);
                    v.LowLink = Math.Min(v.LowLink, w.LowLink);
                }
                else if (S.Contains(w))
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
                    w = S.Pop();
                    scc.Add(w);
                } while (v != w);
                StronglyConnectedComponents.Add(scc);
            }

        }
    }
}
