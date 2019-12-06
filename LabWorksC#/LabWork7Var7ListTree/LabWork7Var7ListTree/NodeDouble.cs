using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork7Var7ListTree
{
    class NodeDouble
    {
        public double Value { get; set; }
        public NodeDouble Next { get; set; }

        public NodeDouble()
        {
            Value = 0;
            Next = null;
        }

        public NodeDouble(double value)
        {
            Value = value;
            Next = null;
        }

        public override string ToString()
        {
            return $"[{Value.ToString()}]";
        }
    }
}
