using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGraphLibrary
{
    public class Node
    {
        //class fields
        private string name;
        private bool visited;
        private List<Edge> edges;

        //constructor
        public Node(string name, bool visited, Edge edges)
        {
            this.name = name;
            this.visited = visited;
            this.edges.Add(edges);
        }

        //properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public bool Visited
        {
            get
            {
                return this.visited;
            }
            set
            {
                this.visited = value;
            }
        }

        public List<Edge> GetEdges
        {
            get
            {
                return this.edges;
            }
        }

        public void AddEdge(Edge edge)
        {
            this.edges.Add(edge);
        }

        public Edge RemoveEdge(Edge destinationNode)
        {
            Edge temp = destinationNode;
            this.edges.Remove(destinationNode);
            return temp;
        }
    }
}
