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
        private const int defaultSize = 10;
        private int size = defaultSize;
        private int numNodes = 0;
        private Node[] nodeArray;
        private List<Edge> graphEdgeList;
        private bool[,] edgeMatrix;

        //Constructor
        public Graph()
        {
            this.graphEdgeList = new List<Edge>();
            this.nodeArray = new Node[defaultSize];
            edgeMatrix = new bool[defaultSize, defaultSize];
        }

        //Public Methods
        public void AddNode(string name)
        {
            //checks to see if the array is full
            //adds node with no edge value to none and visited to false
            if (numNodes >= nodeArray.Length)
            {
                DoubleNodeArray();
            }
            Node newNode = new Node(name, false, null);
            this.nodeArray[numNodes++] = newNode;
        }

        public Node RemoveNode(string name)
        {
            //use find method to locate index of node desired for removal
                //if not -1
                    //store Node in temp
                    //iterate through the Node's edges
                        /* pass in edges to FindEdge method, use this to 
                        find index in edgelist class */
                        //use index to remove edge in class list
                    //mark index of node as null
                //else throw exception
            int removeAtIndex = FindNode(name);
            if (removeAtIndex != -1)
            {
                Node temp = nodeArray[removeAtIndex];
                Edge nodeEdges = temp.GetEdges;
                while (nodeEdges != null)
                {
                    int edgeRemoveIndex = FindEdge(nodeEdges);
                    if (edgeRemoveIndex != -1)
                    {
                        graphEdgeList.RemoveAt(edgeRemoveIndex);
                    }
                }
                nodeArray[removeAtIndex] = null;
                return temp;
            }
            else
            {
                throw new ArgumentException("Arguement invalid, please enter valid node identifier");
            }
        }

        public bool AddEdge(string startingName, string endingName)
        {
            //if the user is bad and makes a circular path from a node to itself
            if (startingName == endingName)
                return false;
            int startingIndex = FindNode(startingName);
            int endingIndex = FindNode(endingName);

            //if one of the names do not exist
            if (startingIndex == -1 || endingIndex == -1)
                return false;

            //matrix needs to be doubled if the number of nodes
            if(numNodes >= size)
            {
                DoubleMatrixArray();
            }

            //set links in edgeMatrix
            edgeMatrix[startingIndex, endingIndex] = true;
            edgeMatrix[endingIndex, startingIndex] = true;

            //making new edges
            Edge firstNodeEdge = new Edge(endingIndex);
            Edge secondNodeEdge = new Edge(startingIndex);

            //Adding new edges to their respective nodes
            nodeArray[startingIndex].AddEdge(firstNodeEdge);
            nodeArray[endingIndex].AddEdge(secondNodeEdge);

            //Add edges to the graph class's edge list
            graphEdgeList.Add(firstNodeEdge);
            graphEdgeList.Add(secondNodeEdge);
            return true;
        }

        public string BreadthTraverse(string name)
        {
            //validate
            if(name != "")
            {
                Queue<Node> nodeQ = new Queue<Node>();
                string outputStream = "";
                int nodeLocationIndex = FindNode(name);
                if(nodeLocationIndex != -1)
                {
                    nodeQ.Enqueue(nodeArray[nodeLocationIndex]);
                    nodeArray[nodeLocationIndex].Visited = true;
                    while(nodeQ.Count != 0)
                    {
                        Node poppedNode = nodeQ.Dequeue();
                        Edge poppedEdges = poppedNode.GetEdges;
                        while(poppedEdges != null)
                        {
                            Node nextNode = nodeArray[poppedEdges.EndPoint];
                            if(nextNode.Visited != true)
                            {
                                outputStream += nextNode.Name;
                                nextNode.Visited = true;
                                nodeQ.Enqueue(nextNode);
                            }
                            poppedEdges = poppedEdges.Next;
                        }
                    }
                    ResetFalse();
                    return outputStream;
                }
                else
                {
                    throw new ArgumentException("Please enter a valid graph node identifier");
                }
            }
            else
            {
                throw new ArgumentException("Please input a valid non-empty arguement");
            }
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
                Edge temp = nodeArray[i].GetEdges;
                while(temp != null)
                {
                    buffer += nodeArray[temp.EndPoint].Name;
                    buffer += " ";
                    temp = temp.Next;
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
            //finds the node in array and returns index
            for (int i = 0; i < numNodes; i++)
            {
                if(nodeArray[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        private int FindEdge(Edge edge)
        {
            //finds the edge in list and returns index
            for (int i = 0; i < numNodes; i++)
            {
                if (this.graphEdgeList[i] == edge)
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

        private void DoubleNodeArray()
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

        private void DoubleMatrixArray()
        {
            //double default size
            //create new array with new size
            //iterate through old array with nested for loops
                //stop when iterator reaches the end of old column size
                //iterate row counter and repeat until done
            int newSize = (size * 2);
            bool[,] newEdgeMatrix = new bool[newSize, newSize];
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; i++)
                {
                    newEdgeMatrix[i,j] = this.edgeMatrix[i,j];
                }
            }
            size = newSize;
            this.edgeMatrix = newEdgeMatrix;
        }
    }
}
