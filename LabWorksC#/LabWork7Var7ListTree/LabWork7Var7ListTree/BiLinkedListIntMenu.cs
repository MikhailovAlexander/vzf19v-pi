﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork7Var7ListTree
{
    class BiLinkedListIntMenu:Menu
    {
        public static void Show()
        {
            Console.WriteLine("\nРабота с  двусвязными списками");
            var list = new BiLinkedListInt();
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
                number = GetInt("Введите номер операции. Для выхода введите 0, "
                    + "для повтора меню 11", min: -1, max: 12);
                switch (number)
                {
                    case 0: break;
                    case 1:
                        list = new BiLinkedListInt(); break;
                    case 2:
                        list = GetListWithRandomElements();
                        list.Print();
                        break;
                    case 3: list.Print(); break;
                    case 4:
                        Console.WriteLine($"Длина списка = {list.Length}");
                        break;
                    case 5:
                        list.Add(GetInt("Введите целочисленное значение элемента: "));
                        list.Print();
                        break;
                    case 6:
                        list.AppEnd(GetInt("Введите целочисленное значение элемента: "));
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
                        ;
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

        private static void ExtractFromList(BiLinkedListInt list)
        {
            int position = GetInt(
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

        private static void ListBottom(BiLinkedListInt list)
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

        private static void ListTop(BiLinkedListInt list)
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

        private static void InsertInList(BiLinkedListInt list)
        {
            int position = GetInt(
                "Введите номер позиции для вставки элемента: ",
                min: 0);
            try
            {
                list.Add(
                    GetInt("Введите целочисленное значение элемента: "),
                    position);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static BiLinkedListInt GetListWithRandomElements()
        {
            var list = new BiLinkedListInt();
            int size = GetInt("Введите длину списка", min: 0);
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
                list.Add(rnd.Next(-100, 100));
            return list;
        }
    }
}
