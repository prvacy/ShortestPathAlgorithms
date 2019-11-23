using System;
using System.Collections.Generic;
using System.Text;
using Pathfinding.Models;

using System.Xml;
using System.Linq;

namespace Pathfinding.GraphSources
{
    public static class XmlSource
    {
        public static IGraph<string> GetGraphFromXml(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            var root = xml.DocumentElement;

            var graph = new Graph<string>(); 
            var edges = graph.Edges;
            var vertices = graph.Vertices;


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
                    var vert = new Vertex<string>() { Data = data };
                    if (vertices.Add(vert))
                    {
                        vertex = vert; 

                    }
                    else
                    {
                        vertex = vertices.Where(v => v.Data == data).First();//TODO: trygetvalue
                    }

                }

                addVertex(out firstV, first);
                addVertex(out lastV, last);

                edge.StartNode = firstV;
                edge.EndNode = lastV;
                edges.Add(edge);
            }

            return graph;
        }


    }
}
