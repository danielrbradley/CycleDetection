using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleDetection.Tests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void EmptyGraph()
        {
            Graph graph = new Graph();
            var detector = new CycleDetector();
            var cycles = detector.DetectCycle(graph);
            Assert.AreEqual(0, cycles.Count);
        }
    }
}
