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
            var graph = new Graph();
            var detector = new CycleDetector();
            var cycles = detector.DetectCycle(graph);
            Assert.AreEqual(0, cycles.Count);
        }

        [TestMethod]
        public void SingleVertexGraph()
        {
            var graph = new Graph();
            graph.Vertices.Add(new Vertex());
            var detector = new CycleDetector();
            var cycles = detector.DetectCycle(graph);
            Assert.AreEqual(0, cycles.Count);
        }

        [TestMethod]
        public void K2NoSimple()
        {
            var graph = new Graph();
            var vA = new Vertex();
            var vB = new Vertex();
            vA.Dependencies.Add(vB);
            graph.Vertices.Add(vA);
            graph.Vertices.Add(vB);
            var detector = new CycleDetector();
            var cycles = detector.DetectCycle(graph);
            Assert.AreEqual(0, cycles.Count);
        }

        [TestMethod]
        public void K2Cycle()
        {
            var graph = new Graph();
            var vA = new Vertex();
            var vB = new Vertex();
            vA.Dependencies.Add(vB);
            vB.Dependencies.Add(vA);
            graph.Vertices.Add(vA);
            graph.Vertices.Add(vB);
            var detector = new CycleDetector();
            var cycles = detector.DetectCycle(graph);
            Assert.AreNotEqual(0, cycles.Count);
        }

        [TestMethod]
        public void C3()
        {
            var graph = new Graph();
            var vA = new Vertex();
            var vB = new Vertex();
            var vC = new Vertex();
            vA.Dependencies.Add(vB);
            vB.Dependencies.Add(vC);
            vC.Dependencies.Add(vA);
            graph.Vertices.Add(vA);
            graph.Vertices.Add(vB);
            graph.Vertices.Add(vC);
            var detector = new CycleDetector();
            var cycles = detector.DetectCycle(graph);
            Assert.AreNotEqual(0, cycles.Count);
        }
    }
}
