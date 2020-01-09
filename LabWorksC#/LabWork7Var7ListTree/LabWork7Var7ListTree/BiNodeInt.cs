using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork7Var7ListTree
{
    class BiNodeInt
    {
        public int Value { get; set; }
        public BiNodeInt Next { get; set; }
        public BiNodeInt Previous { get; set; }

        public BiNodeInt()
        {
            Value = 0;
            Next = null;
            Previous = null;
        }

        public BiNodeInt(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

        public BiNodeInt(int value, BiNodeInt next)
        {
            Value = value;
            Next = next;
            if(next != null)
                next.Previous = this;
            Previous = null;
        }

        public BiNodeInt(BiNodeInt previous, int value)
        {
            Value = value;
            Next = null;
            Previous = previous;
        }

        public BiNodeInt(BiNodeInt previous, int value, BiNodeInt next)
        {
            Value = value;
            Next = next;
            if (next != null)
                next.Previous = this;
            Previous = previous;
        }

        public override string ToString()
        {
            return $"[{Value.ToString()}]";
        }
    }
}
