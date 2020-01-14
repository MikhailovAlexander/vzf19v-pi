using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWorks
{
    class LabIntArray
    {
        int[] array;
        public int Length
        {
            get { return array.Length; }
        }

        public LabIntArray(int n)
        {
            if (n <= 0) throw new Exception(
                "Значение длины массива не может быть меньше 1");            
            array = new int[n];            
        }

        public void SetRandomElements(int min = int.MinValue,
            int max = int.MaxValue)
        {
            if (max < min) throw new Exception(
                "Максимальное значение элемента не может быть меньше минимального");
            Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                array[i] = random.Next(min, max);
            }
        }

        public void SetElementsInRange()
        {
            for (int i = 0; i < Length; i++)
            {
                array[i] = i;
            }
        }

        public void PrintArray()
        {
            if (Length == 0) Console.WriteLine("Массив не имеет элементов");
            foreach (int x in array) Console.WriteLine($"[{x,4}]");
        }

        public void PrintArrayInLine()
        {
            if (Length == 0) Console.WriteLine("Массив не имеет элементов");
            foreach (int x in array) Console.Write($"[{x,4}] ");
            Console.WriteLine("");
        }

        public void RemoveElementsWithEvenIndex()
        {
            int[] newArray = new int[Length / 2];
            int newIndex = 0;
            for(int i = 0; i < Length; i++)
            {
                if(i % 2 != 0)
                {
                    newArray[newIndex++] = array[i];
                }
            }
            array = newArray;
        }
        /// <summary>
        /// Добавление элементов в массив начиная с индекса К
        /// </summary>
        /// <param name="elementsForIns">Элементы для вставки</param>
        /// <param name="k">Индекс от 0 до длины массива, 
        /// начиная с которго вставляются элементы</param>
        public void InsertElementsBegFromK(int k, params int[] elementsForIns)
        {
            if (k < 0 || k > Length) throw new Exception(
                $"В массиве длиной {Length} нет элемента с индексом {k}");
            int[] newArray = new int[Length + elementsForIns.Length];
            for (int i = 0; i < newArray.Length; i++)
            {
                if (i < k)
                {
                    newArray[i] = array[i];
                }
                else if(i >= k && i < k + elementsForIns.Length)
                {
                    newArray[i] = elementsForIns[i - k];
                }
                else if(i >= k + elementsForIns.Length)
                {
                    newArray[i] = array[i - elementsForIns.Length];
                }
            }
            array = newArray;
        }

        public void Reverse()
        {
            for (int i = 0; i < Length/2; i++)
            {
                int tmp = array[i];
                array[i] = array[(Length-1) - i];
                array[(Length - 1) - i] = tmp;
            }
        }
        /// <summary>
        /// Поиск первого индекса элемента с заданным значением
        /// </summary>
        /// <param name="value">Значение для поиска</param>
        /// <returns>First index or -1 if index is not found</returns>
        public int FindFirstIndexByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if(array[i] == value) return i;
            }
            return -1;
        }
        /// <summary>
        /// Сортировка массива методом простой вставки
        /// </summary>
        public void InsertionSort()
        {
            for (int i = 1; i < Length; i++)
            {
                int j = i;
                while(j > 0 && array[j] < array[j -1])
                {
                    LabMethods.Swap<int>(ref array[j], ref array[j - 1]);
                    j--;
                }
            }
        }

        public static void ArrayMenu()
        {
            Console.WriteLine("\nРабота с одномерными массивами");
            var arr = GetIntArrayWithRandom();
            string operations = "Операции с массивом:"
                + "\n\t1 Вывести массив строкой"
                + "\n\t2 Повторить меню"
                + "\n\t3 Заполнить массив целочисленной последовательностью от нуля до размера массива"
                + "\n\t4 Заполнить массив случайными числами"
                + "\n\t5 Удалить элементы с четными индексами"
                + "\n\t6 Вставить в массив N элементов начиная с K"
                + "\n\t7 Перевернуть массив"
                + "\n\t8 Найти первый индекс элемента с заданным значением"
                + "\n\t9 Отсортировать массив методом простого включения"
                + "\n\t10 Создать новый массив заданного размера";
            Console.WriteLine(operations);
            int number = -1;
            while (number != 0)
            {
                number = LabMethods.GetInt("Введите номер операции. Для выхода введите 0, "
                    + "для повтора меню 2", min: -1, max: 10);
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
                        arr.SetRandomElements(min: -10, max: 10);
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
                            arr.InsertElementsBegFromK(index, elemensForIns);
                        }
                        catch (Exception ex)
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

        public static LabIntArray GetIntArrayWithRandom()
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

        public static int[] GetElementsForInsert()
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
        public static void SearchElementByValue(LabIntArray arr)
        {
            int value = LabMethods.GetInt("Введите значение для поиска: ");
            int result = arr.FindFirstIndexByValue(value);
            string answer = result == -1 ? "Элемент не найден" : $"Индекс первого элемента {result}";
            Console.WriteLine(answer);
        }
    }
}
