using System;
using LabWorks;

namespace LabWork4Var15
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayMenu();
        }

        static void ArrayMenu()
        {
            Console.WriteLine("Лабораторная работа №4\nРабота с одномерными массивами");
            var arr = GetIntArrayWithRandom();
            string operations = "Операции с массивом:"
                + "\n1 Вывести массив строкой"
                + "\n2 Вывести меню"
                + "\n3 Заполнить массив целочисленной последовательностью от нуля до размера массива"
                + "\n4 Заполнить массив случайными числами"
                + "\n5 Удалить элементы с четными индексами"
                + "\n6 Вставить в массив N элементов начиная с K"
                + "\n7 Перевернуть массив"
                + "\n8 Найти первый индекс элемента с заданным значением"
                + "\n9 Отсортировать массив методом простого включения"
                + "\n10 Создать новый массив заданного размера";
            Console.WriteLine(operations);
            int number = -1;
            while (number != 0)
            {
                number = LabMethods.GetInt("Введите номер операции. Для выхода введите 0", min: -1, max: 10);
                switch (number)
                {
                    case 0: break;
                    case 1: arr.PrintArrayInLine(); break;
                    case 2: Console.WriteLine(operations); break;
                    case 3:
                        arr.SetElementsInRange();
                        arr.PrintArrayInLine();
                        break;
                    case 4:
                        arr.SetRandomElements(min: -100, max: 100);
                        arr.PrintArrayInLine();
                        break;
                    case 5:
                        arr.RemoveElementsWithEvenIndex();
                        arr.PrintArrayInLine();
                        break;
                    case 6:
                        int[] elemensForIns = GetElementsForInsert();
                        int index = LabMethods.GetInt(
                            $"Введите индекс элемента для вставки от 0 до {arr.Length}: ",
                            min: -1, max: arr.Length);
                        try
                        {
                            arr.InsertElementsBegFromK(elemensForIns, index);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(
                                $"Операцию невозможно выполнить. Ошибка: {ex.Message}");
                        }
                        arr.PrintArrayInLine();
                        break;
                    case 7:
                        arr.Reverse();
                        arr.PrintArrayInLine();
                        break;
                    case 8:
                        SearchElementByValue(arr);
                        break;
                    case 9:
                        arr.InsertionSort();
                        arr.PrintArrayInLine();
                        break;
                    case 10:
                        arr = GetIntArrayWithRandom();
                        break;
                        ;
                }
            }
        }

        static LabIntArray GetIntArrayWithRandom()
        {
            var arr = new LabIntArray(1);
            int arrayLength = LabMethods.GetInt(
               "Введите целочисленный неотрицательный размер массива: ", min: 0);
            try
            {
                arr = new LabIntArray(arrayLength);
                arr.SetRandomElements(min: -100, max: 100);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Операцию невозможно выполнить. Ошибка: {ex.Message}");
            }
            Console.WriteLine($"Массив длиной {arrayLength} заполнен случайными числами");
            arr.PrintArrayInLine();
            return arr;
        }

        static int[] GetElementsForInsert()
        {
            int size = LabMethods.GetInt(
                           "Введите целое количество элементов для вставки > 0: ", min: 0);
            int[] elemensForIns = new int[size];
            for (int i = 0; i < size; i++)
            {
                elemensForIns[i] = LabMethods.GetInt("Введите целое значение элемента: ");
            }
            return elemensForIns;
        }
        static void SearchElementByValue(LabIntArray arr)
        {
            int value = LabMethods.GetInt("Введите значение для поиска: ");
            int result = arr.FindFirstIndexByValue(value);
            string answer = result == -1 ? "Элемент не найден" : $"Индекс первого элемента {result}";
            Console.WriteLine(answer);
        }

    }
}
