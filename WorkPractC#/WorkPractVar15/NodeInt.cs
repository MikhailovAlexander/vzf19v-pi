using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPractVar15
{
    class NodeInt
    {
        public int Value { get; set; }
        public NodeInt Next { get; set; }

        public NodeInt(int value)
        {
            Value = value;
            Next = null;
        }

        public NodeInt(int value, NodeInt next)
        {
            Value = value;
            Next = next;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
