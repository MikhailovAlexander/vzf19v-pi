using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork7Var7ListTree
{
    class BiLinkedListInt
    {
        private BiNodeInt head;
        public BiNodeInt Head {
            get { return head; }
            set
            {
                head = value;
                if(!IsEmpty)
                    head.Previous = null;
            }

    }
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
                var currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                    length++;
                }
                return length;
            }
        }

        public BiLinkedListInt()
        {
            Head = null;
        }

        public BiLinkedListInt(int value)
        {
            Head = new BiNodeInt(value);
        }

        BiNodeInt GetEnd()
        {
            if (IsEmpty)
                throw new Exception("Список пуст");
            var currentNode = Head;
            while (currentNode.Next != null)
                currentNode = currentNode.Next;
            return currentNode;
        }

        public void Add(int value)
        {
            if(IsEmpty) Head = new BiNodeInt(value);
            else Head = new BiNodeInt(value, Head);
        }

        public void Add(int value, int indexForInsert)
        {
            if (indexForInsert < 1)
                throw new Exception(
                    $"Позиция для вставки не может быть меньше 1.");
            if (indexForInsert == 1)
            {
                Add(value);
                return;
            }
            if (IsEmpty)
            {
                throw new Exception(
                    $"Добавление элемента в позицию {indexForInsert} невозможно. Список пуст.");
            }
            if (indexForInsert > Length + 1)
                throw new Exception(
                    $"Добавление элемента в позицию {indexForInsert} невозможно." +
                    $" Длина списка {Length}.");
            var currentNode = Head;
            int currentIndex = 1;
            while (currentNode.Next != null && currentIndex < indexForInsert - 1)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }
            if (currentIndex == indexForInsert - 1)
            {
                currentNode.Next = new BiNodeInt(currentNode, value, currentNode.Next);
            }
            else throw new Exception(
                    $"Добавление элемента в позицию {indexForInsert} невозможно.");
        }

        public void AppEnd(int value)
        {
            var endOfList = GetEnd();
            endOfList.Next = new BiNodeInt(endOfList, value);
        }

        public int Top()
        {
            if(IsEmpty)
                throw new Exception("Список пуст");
            int value = Head.Value;
            Head = Head.Next;
            return value;
        }

        public int Bottom()
        {
            var endOfList = GetEnd();
            if (endOfList.Previous == null)
                return Top();
            else
            {
                int value = endOfList.Value;
                endOfList.Previous.Next = null;
                return value;
            }
        }

        public int Extract(int position)
        {
            if(position < 1)
                throw new Exception("Индекс элемента не может быть меньше 1");
            if (position == 1)
                return Top();
            int currentIndex = 2;
            var currentNode = Head.Next;
            while(currentIndex < position && currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }
            if(currentIndex == position)
            {
                int value = currentNode.Value;
                currentNode.Previous.Next = currentNode.Next;
                if (currentNode.Next != null)
                    currentNode.Next.Previous = currentNode.Previous;
                return value;
            }
            throw new Exception($"Элемента с номером {position} не существует");
        }

        public override string ToString()
        {
            if (IsEmpty) return "Список пуст";
            var currentNode = Head;
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
