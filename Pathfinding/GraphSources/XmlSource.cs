using System;
using System.Collections.Generic;
using System.Text;
using Pathfinding.Models;

using System.Xml;

namespace Pathfinding.GraphSources
{
    public static class XmlSource
    {
        public static IGraph<string> GetGraphFromXml(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            var root = xml.DocumentElement;

            var edges = new List<IEdge<string>>();
            var vertices = new List<IVertex<string>>();
            var vertNames = new HashSet<string>();

            foreach (XmlNode node in root)
            {
                var edge = new Edge<string>();
                //TODO: maybe tryparse and error check
                edge.Distance = double.Parse(node.Attributes["distance"].Value);

                var first = node.FirstChild.InnerText;
                var last = node.LastChild.InnerText;

                IVertex<string> firstV, lastV;

                void addVertex(out IVertex<string> vertex, string data)
                {
                    if (vertNames.Add(data))
                    {
                        vertex = new Vertex<string>() { Data = data };
                        vertices.Add(vertex);
                    }
                    else
                    {
                        vertex = vertices.Find(v => v.Data == data);
                    }
                }

                addVertex(out firstV, first);
                addVertex(out lastV, last);

                edge.StartNode = firstV;
                edge.EndNode = lastV;
                edges.Add(edge);
            }

            var graph = new Graph<string>();
            graph.Vertices = vertices;
            graph.Edges = edges;
            return graph;
        }
    }
}
