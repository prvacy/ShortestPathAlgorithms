using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using Pathfinding.GraphSources;
using System.IO;

using Pathfinding.Models;

namespace PathfindingTest
{
    [TestClass]
    public class CheckGraphGenerating
    {


        //Graph illustration: graph.png
        [TestMethod]
        public void CheckEdgesCount_XmlGenerated()
        {
            var path = @"../../../testGraph.xml";
            var graph = XmlSource.GetGraphFromXml(path);
            Assert.AreEqual(graph.Edges.Count, 7);
        }

        [TestMethod]
        public void CheckVerticesCount_XmlGenerated()
        {
            var path = @"../../../testGraph.xml";
            var graph = XmlSource.GetGraphFromXml(path);

            Assert.AreEqual(graph.Vertices.Count, 6);
        }

        [TestMethod]
        public void Test_Graph_HashSets()
        {
            var hV = new HashSet<IVertex<string>>();
            var vertex = new Vertex<string>() { Data = "a" };
            hV.Add(vertex);
            hV.Add(vertex);
            Assert.AreEqual(hV.Count, 1);

            var hE = new HashSet<IEdge<string>>();
            var edge = new Edge<string>() { Distance = 3.4, StartNode = vertex, EndNode = vertex };//TODO: check if edge starts and ends atS one node???
            hE.Add(edge);
            hE.Add(edge);
            Assert.AreEqual(hE.Count, 1);
        }
    }

}
