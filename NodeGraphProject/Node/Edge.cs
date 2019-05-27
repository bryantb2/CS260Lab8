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
        private Edge next;
        private const int EMPTY = -1;
        
        //constructor
        public Edge(int endIndex)
        {
            this.endIndex = endIndex;
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
