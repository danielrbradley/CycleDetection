using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CycleDetection
{
    /// <summary>
    /// Implementation of the Tarjan stronly connected components algorithm.
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Tarjan's_strongly_connected_components_algorithm"/>
    /// <seealso cref="http://stackoverflow.com/questions/261573/best-algorithm-for-detecting-cycles-in-a-directed-graph"/>
    public class CycleDetector<T>
    {
        private List<List<Vertex<T>>> stronglyConnectedComponents;
        private Stack<Vertex<T>> stack;
        private int index;

        /// <summary>
        /// Calculates the sets of strongly connected vertices.
        /// </summary>
        /// <param name="graph">Graph to detect cycles within.</param>
        /// <returns>Set of strongly connected components (sets of vertices)</returns>
        public List<List<Vertex<T>>> DetectCycle(IEnumerable<Vertex<T>> graph)
        {
            stronglyConnectedComponents = new List<List<Vertex<T>>>();
            index = 0;
            stack = new Stack<Vertex<T>>();
            foreach (var v in graph)
            {
                if (v.Index < 0)
                {
                    StrongConnect(v);
                }
            }
            return stronglyConnectedComponents;
        }

        private void StrongConnect(Vertex<T> v)
        {
            v.Index = index;
            v.LowLink = index;
            index++;
            stack.Push(v);

            foreach (Vertex<T> w in v.Dependencies)
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
                List<Vertex<T>> scc = new List<Vertex<T>>();
                Vertex<T> w;
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
