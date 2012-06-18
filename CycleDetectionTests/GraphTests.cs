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
        public void SingleVertex()
        {
            var graph = new Graph();
            graph.Vertices.Add(new Vertex());
            var detector = new CycleDetector();
            var cycles = detector.DetectCycle(graph);
            Assert.AreEqual(1, cycles.Count);
        }

        [TestMethod]
        public void Linear2()
        {
            var graph = new Graph();
            var vA = new Vertex();
            var vB = new Vertex();
            vA.Dependencies.Add(vB);
            graph.Vertices.Add(vA);
            graph.Vertices.Add(vB);
            var detector = new CycleDetector();
            var cycles = detector.DetectCycle(graph);
            Assert.AreEqual(2, cycles.Count);
        }

        [TestMethod]
        public void Linear3()
        {
            var graph = new Graph();
            var vA = new Vertex();
            var vB = new Vertex();
            var vC = new Vertex();
            vA.Dependencies.Add(vB);
            vB.Dependencies.Add(vC);
            graph.Vertices.Add(vA);
            graph.Vertices.Add(vB);
            graph.Vertices.Add(vC);
            var detector = new CycleDetector();
            var cycles = detector.DetectCycle(graph);
            Assert.AreEqual(3, cycles.Count);
        }

        [TestMethod]
        public void Cycle2()
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
            Assert.AreEqual(1, cycles.Count);
        }

        [TestMethod]
        public void Cycle3()
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
            Assert.AreEqual(1, cycles.Count);
        }

        [TestMethod]
        public void TwoIsolated3Cycles()
        {
            var graph = new Graph();
            var vA1 = new Vertex();
            var vB1 = new Vertex();
            var vC1 = new Vertex();
            vA1.Dependencies.Add(vB1);
            vB1.Dependencies.Add(vC1);
            vC1.Dependencies.Add(vA1);
            graph.Vertices.Add(vA1);
            graph.Vertices.Add(vB1);
            graph.Vertices.Add(vC1);

            var vA2 = new Vertex();
            var vB2 = new Vertex();
            var vC2 = new Vertex();
            vA2.Dependencies.Add(vB2);
            vB2.Dependencies.Add(vC2);
            vC2.Dependencies.Add(vA2);
            graph.Vertices.Add(vA2);
            graph.Vertices.Add(vB2);
            graph.Vertices.Add(vC2);

            var detector = new CycleDetector();
            var cycles = detector.DetectCycle(graph);
            Assert.AreEqual(2, cycles.Count);
        }
    }
}
