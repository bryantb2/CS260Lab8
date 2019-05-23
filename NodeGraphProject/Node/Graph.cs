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
        private Edge[][] edgeMatrix;

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

        public void AddEdge(string startingName, string endingName)
        {

        }

        public string DisplayMatrix()
        {
            return "";
        }

        public string DisplayEdges()
        {
            return "";
        }

        public string ListNodes()
        {
            return "";
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
