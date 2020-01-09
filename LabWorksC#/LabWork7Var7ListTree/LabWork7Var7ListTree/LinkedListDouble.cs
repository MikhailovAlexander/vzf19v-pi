using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork7Var7ListTree
{
    class LinkedListDouble
    {
        public NodeDouble Head { get; set; }
        public bool IsEmpty
        {
            get { return Head == null; }
        }
        public int Length
        {
            get
            {
                if (IsEmpty) return 0;
                int length = 1;
                NodeDouble currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                    length++;
                }
                return length;
            }
        }

        public LinkedListDouble()
        {
            Head = null;
        }

        public LinkedListDouble(double value)
        {
            Head = new NodeDouble(value);
        }

        public static LinkedListDouble MakeLinkedListDouble(double value)
        {
            return new LinkedListDouble(value);
        }

        public static LinkedListDouble MakeLinkedListDouble(params double[] values)
        {
            if (values.Length == 0)
                return new LinkedListDouble();
            var list =  new LinkedListDouble(values[0]);
            var currentNode = list.Head;
            for(int i = 1; i < values.Length; i++)
            {
                currentNode.Next = new NodeDouble(values[i]);
                currentNode = currentNode.Next;
            }
            return list;
        }

        NodeDouble GetEnd()
        {
            if (IsEmpty)
                throw new Exception("Список пуст");
            NodeDouble currentNode = Head;
            while (currentNode.Next != null)
                currentNode = currentNode.Next;
            return currentNode;
        }

        public void AppEnd(double value)
        {
            NodeDouble endOfList = GetEnd();
            endOfList.Next = new NodeDouble(value);
        }

        public void Add(double value)
        {
            var newStart = new NodeDouble(value);
            newStart.Next = Head;
            Head = newStart;
        }

        public void Add(double value, int indexForInsert)
        {
            if(indexForInsert < 1)
                throw new Exception(
                    $"Позиция для вставки не может быть меньше 1.");
            if (indexForInsert == 1)
            {
                NodeDouble tmp = Head;
                Head = new NodeDouble(value);
                Head.Next = tmp;
                return;
            }
            if (IsEmpty)
            {
                throw new Exception(
                    $"Добавление элемента в позицию {indexForInsert} невозможно. Список пуст.");
            }
            if(indexForInsert > Length + 1)
                throw new Exception(
                    $"Добавление элемента в позицию {indexForInsert} невозможно." +
                    $" Длина списка {Length}.");
            NodeDouble currentNode = Head;
            int currentIndex = 1;
            while (currentNode.Next != null && currentIndex < indexForInsert - 1)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }
            if(currentIndex == indexForInsert - 1)
            {
                NodeDouble tail = currentNode.Next;
                currentNode.Next = new NodeDouble(value);
                currentNode.Next.Next = tail;
            }
            else throw new Exception(
                    $"Добавление элемента в позицию {indexForInsert} невозможно.");
        }

        /// <summary>
        /// ghjkljhghjkl
        /// </summary>
        /// <returns></returns>
        public double Top()
        {
            if(IsEmpty)
                throw new Exception(
                    $"Извлечение первого элемента невозможно. Список пуст.");
            double value = Head.Value;
            Head = Head.Next;
            return value;
        }

        public double Bottom()
        {
            if (IsEmpty)
                throw new Exception(
                    $"Извлечение последнего элемента невозможно. Список пуст.");
            if (IsEmpty)
            {
                double value = Head.Value;
                Head = null;
                return value;
            }
            NodeDouble currentNode = Head;
            NodeDouble previousNode = null;
            while (currentNode.Next != null)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }
            previousNode.Next = null;
            return currentNode.Value;
        }

        public double Extract(int position)
        {
            if (position < 1)
                throw new Exception(
                    $"Позиция для извлечения не может быть меньше 1.");
            if (IsEmpty)
            {
                throw new Exception(
                    $"Извлечение элемента в невозможно. Список пуст.");
            }
            if (position == 1)
            {
                return this.Top();
            }
            NodeDouble currentNode = Head;
            int currentIndex = 1;
            while (currentNode.Next != null && currentIndex < position - 1)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }
            if (currentIndex == position - 1 && currentNode.Next != null)
            {
                double value = currentNode.Next.Value;
                currentNode.Next = currentNode.Next.Next;
                return value;
            }
            else throw new Exception(
                    $"Извлечение элемента в невозможно.");
        }

        public override string ToString()
        {
            if (IsEmpty) return "Список пуст";
            NodeDouble currentNode = Head;
            StringBuilder listString = new StringBuilder(Head.ToString());
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                listString.AppendFormat($" {currentNode.ToString()}");
            }
            return listString.ToString();
        }

        public void Print()
        {
            if (IsEmpty)
                Console.WriteLine("Список пуст");
            else Console.WriteLine(this.ToString());
        }

        
    }
}
