using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using Pathfinding.GraphSources;
using System.IO;

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
    }

}
