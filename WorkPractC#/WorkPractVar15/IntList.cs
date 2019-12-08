using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPractVar15
{
    class IntList
    {
        private NodeInt head;
        public NodeInt Head { get { return head; } }
        public bool IsEmpty { get { return head == null; } }

        public IntList()
        {
            head = null;
        }

        public int InsertInOrder(int value)
        {
            int compareCount = 0;
            if (IsEmpty)
            {
                head = new NodeInt(value);
                return 1;
            }
            if (value <= head.Value)
            {
                head = new NodeInt(value, head);
                return 1;
            }
            NodeInt currentNode = head;
            while (currentNode.Next != null && value > currentNode.Next.Value)
            {
                currentNode = currentNode.Next;
                compareCount++;
            }
            currentNode.Next = new NodeInt(value, currentNode.Next);
            return compareCount;
        }

        public int Top()
        {
            int tmp = head.Value;
            head = head.Next;
            return tmp;
        }

        public override string ToString()
        {
            if (IsEmpty) return "Список пуст";
            NodeInt currentNode = Head;
            StringBuilder listString = new StringBuilder($"[{Head.ToString()}]");
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                listString.AppendFormat($" [{currentNode.ToString()}]");
            }
            return listString.ToString();
        }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

    }
}
