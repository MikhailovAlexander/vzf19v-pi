using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWorks;

namespace LabWork7Var7ListTree
{
    class LinkedListDouble
    {
        public NodeDouble Head { get; set; }
        public int Length
        {
            get
            {
                if (Head == null) return 0;
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
            if (Head == null)
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

        public double Top()
        {
            if(Head == null)
                throw new Exception(
                    $"Извлечение первого элемента невозможно. Список пуст.");
            double value = Head.Value;
            Head = Head.Next;
            return value;
        }

        public double Bottom()
        {
            if (Head == null)
                throw new Exception(
                    $"Извлечение последнего элемента невозможно. Список пуст.");
            if(Head.Next == null)
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
            if (Head == null)
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
            if (Head == null) return "Список пуст";
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
            if (Head == null)
                Console.WriteLine("Список пуст");
            else Console.WriteLine(this.ToString());
        }

        public static void Menu()
        {
            Console.WriteLine("\nРабота с односвязными списками");
            var list = new LinkedListDouble();
            string operations = "Операции со списком:"
                + "\n\t1 Создать пустой список"
                + "\n\t2 Создать список заданной длины со случайными элементами"
                + "\n\t3 Вывести список"
                + "\n\t4 Вывести длину списка"
                + "\n\t5 Добавить элемент в начало списка"
                + "\n\t6 Добавить элемент в конец списка"
                + "\n\t7 Добавить элемент в заданную позицию"
                + "\n\t8 Извлечь первый элемент"
                + "\n\t9 Извлечь последний элемент"
                + "\n\t10 Извлечь элемент в заданной позиции"
                + "\n\t11 Добавить в список после каждого элемента с отрицательным " 
                + "значением элемент равный 0"
                + "\n\t12 Повтор меню";
            Console.WriteLine(operations);
            int number = -1;
            while (number != 0)
            {
                number = LabMethods.GetInt("Введите номер операции. Для выхода введите 0, "
                    + "для повтора меню 11", min: -1, max: 12);
                switch (number)
                {
                    case 0: break;
                    case 1:
                        list = new LinkedListDouble(); break;
                    case 2:
                        list = GetListWithRandomElements();
                        list.Print();
                        break;
                    case 3: list.Print(); break;
                    case 4:
                        Console.WriteLine($"Длина списка = {list.Length}");
                        break;
                    case 5:
                        list.Add(LabMethods.GetDouble("Введите вещественное значение элемента: "));
                        list.Print();
                        break;
                    case 6:
                        list.AppEnd(LabMethods.GetDouble("Введите вещественное значение элемента: "));
                        list.Print();
                        break;
                    case 7:
                        InsertInList(list);
                        list.Print();
                        break;
                    case 8:
                        ListTop(list);
                        list.Print();
                        break;
                    case 9:
                        ListBottom(list);
                        list.Print();
                        break;
                    case 10:
                        ExtractFromList(list);
                        list.Print();
                        break;
                    case 11:
                        InsertZeros(list);
                        list.Print();
                        break;
                    case 12:
                        Console.WriteLine(operations);
                        break;
                }
            }
        }

        private static void InsertZeros(LinkedListDouble list)
        {
            if (list.Head == null) return;
            NodeDouble currentNode = list.Head;
            do
            {
                if (currentNode.Value < 0)
                {
                    NodeDouble tmp = currentNode.Next;
                    currentNode.Next = new NodeDouble(0);
                    currentNode.Next.Next = tmp;
                    currentNode = currentNode.Next;
                }
                else currentNode = currentNode.Next;
            } while (currentNode != null);
        }

        private static void ExtractFromList(LinkedListDouble list)
        {
            int position = LabMethods.GetInt(
                "Введите номер позиции для извлечения элемента: ",
                min: 0);
            try
            {
                Console.WriteLine($"[{list.Extract(position)}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ListBottom(LinkedListDouble list)
        {
            try
            {
                Console.WriteLine($"[{list.Bottom()}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ListTop(LinkedListDouble list)
        {
            try
            {
                Console.WriteLine($"[{list.Top()}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void InsertInList(LinkedListDouble list)
        {
            int position = LabMethods.GetInt(
                "Введите номер позиции для вставки элемента: ",
                min: 0);
            try
            {
                list.Add(
                    LabMethods.GetDouble("Введите вещественное значение элемента: "),
                    position);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static LinkedListDouble GetListWithRandomElements()
        {
            int size = LabMethods.GetInt("Введите длину списка", min:0);
            double[] elements = new double[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
                elements[i] = rnd.NextDouble() + rnd.Next(-1,1);
            return MakeLinkedListDouble(elements);
        }
    }
}
