using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGraphLibrary
{
    public class Edge
    {
        //class fields
        private int endIndex;
        private int weight;
        private Edge next;
        private const int EMPTY = -1;
        
        //constructor
        public Edge(int endIndex, Edge next, int weight = EMPTY)
        {
            this.endIndex = endIndex;
            this.next = next;
            this.weight = weight;
        }

        //properties
        public int EndPoint
        {
            get
            {
                return this.endIndex;
            }
            set
            {
                this.endIndex = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }

        public Edge Next
        {
            get
            {
                return this.next;
            }
            set
            {
                this.next = value;
            }
        }
    }
}
