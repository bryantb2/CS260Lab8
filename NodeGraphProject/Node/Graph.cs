using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGraphLibrary
{
    public class Graph
    {
        //Class fields
        private int numNodes = 0;
        private Node[] nodeArray;
        private Edge[] edgeList;
        private bool[,] edgeMatrix;

        //Constructor
        public Graph()
        {

        }

        //Public Methods
        public void AddNode(string name)
        {
            //checks to see if the array is full
            //adds node with no edge value to none and visited to false
            if (numNodes >= nodeArray.Length)
            {
                DoubleArray();
            }
            Node newNode = new Node(name, false, null);
            this.nodeArray[numNodes++] = newNode;
        }

        public bool AddEdge(string startingName, string endingName)
        {
            //if the user is bad and makes a circular path from a node to itself
            if (startingName == endingName)
                return false;
            int startingIndex = FindNode(startingName);
            int endingIndex = FindNode(endingName);

            //if both names do not exist
            if (startingIndex == -1 || endingIndex == -1)
                return false;
            //set links in edgeMatrix
            edgeMatrix[startingIndex, endingIndex] = true;
            edgeMatrix[endingIndex, startingIndex] = true;

            //making new edges, adding them to each of the nodes
            Edge beginningEdge = new Edge(endingIndex);
            Edge endingEdge = new Edge(startingIndex);
            nodeArray[startingIndex]
            return true;
        }

        public string BreadthTraverse(string name)
        {
            //validate
            if(name != "")
            {
                Queue<Node> nodeQ = new Queue<Node>();
                string outputStream = "";
                int nodeLocation = FindNode(name);
                if(nodeLocation <)



            }
            else
            {
                throw new ArgumentException("Please input a valid non-empty arguement");
            }
            return "";
        }

        public string DepthFirst()
        {
            return "";
        }

        public string DisplayMatrix()
        {
            string buffer = "";
            //header destination line
            for(int i = 0; i < numNodes; i++)
            {
                buffer += nodeArray[i].Name;
                for(int j= 0; j < numNodes; j++)
                {
                    buffer += edgeMatrix[i,j];
                }
            }
            return buffer;
        }

        public string DisplayEdges()
        {
            string buffer = "";
            for(int i = 0; i <numNodes; i++)
            {
                //displaying node names
                buffer += nodeArray[i].Name;
                buffer += "-";
                //go down list of edges to concatenate
                List<Edge> temp = nodeArray[i].GetEdges;
                for(int j = 0; j < temp.Count; i++)
                {
                    buffer += nodeArray[temp[j].EndPoint].Name;
                    buffer += " ";
                }
                buffer += "\n";
            }
            return buffer;
        }

        public string ListNodes()
        {
            string nodeList = "";
            for(int i = 0; i<numNodes;i++)
            {
                nodeList += nodeArray[i].Name;
                nodeList += " ";
            }
            return nodeList;
        }

        //Private Methods
        private int FindNode(string name)
        {
            //finds the node in list and returns index
            for (int i = 0; i < numNodes; i++)
            {
                if(nodeArray[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        private void ResetFalse()
        {
            //sets the visited property of each node to false
            for(int i = 0; i<numNodes; i++)
            {
                nodeArray[i].Visited = false;
            }
        }

        private void DoubleArray()
        {
            int newSize = (this.nodeArray.Length * 2);
            int oldSize = this.nodeArray.Length;
            Node[] newArray = new Node[newSize];
            for(int i = 0; i < oldSize; i++)
            {
                newArray[i] = nodeArray[i];
            }
            this.nodeArray = newArray;
        }
    }
}
