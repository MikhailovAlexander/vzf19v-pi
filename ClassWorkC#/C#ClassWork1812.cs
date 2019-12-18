using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork1812
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("\nРабота с массивами");
            int[] array = new int[0];
            string operations = "Операции с массивами:"
                + "\n\t1 Создать массив заданной длины со случайными элементами"
                + "\n\t2 Вывести массив"
                + "\n\t3 Удалить минимальный элемент"
                + "\n\t4 Найти количество четных чисел между первым минимумом и посленим максимумом"
                + "\n\t5 Поменять минимум с максимумом"
                + "\n\t6 Отсортировать по возрастанию четные элементы"
                + "\n\t7 Удалить элементы меньшие чем средний"
                + "\n\t8 Удалить первый четный элемент"
                + "\n\t9 Повтор меню";
            Console.WriteLine(operations);
            int number = -1;
            while (number != 0)
            {
                number = GetInt("Введите номер операции. Для выхода введите 0, "
                    + "для повтора меню 9", min: -1, max: 10);
                switch (number)
                {
                    case 0: break;
                    case 1:
                        array = GetArrayWithRandom(-100, 100); 
                        PrintArray(array);
                        break;
                    case 2:
                        PrintArray(array);
                        break;
                    case 3: RemoveMinElement(ref array);
                        PrintArray(array);
                        break;
                    case 4:
                        CountEvenBetweenMinMax(array);
                        PrintArray(array);
                        break;
                    case 5:
                        MinMaxReplace(array);
                        PrintArray(array);
                        break;
                    case 6:
                        SortEvenElements(array);
                        PrintArray(array);
                        break;
                    case 7:
                        RemoveLessThanAVG(ref array);
                        PrintArray(array);
                        break;
                    case 8:
                        RemoveFirstEven(ref array);
                        PrintArray(array);
                        break;
                    case 9:
                        Console.WriteLine(operations);
                        break;
                }
            }
        }

        static void RemoveFirstEven(ref int[] array)
        {
            bool hasEven = false;
            foreach (int x in array)
            {
                if(x % 2 == 0)
                {
                    hasEven = true;
                    break;
                }
            }
            if (!hasEven) return;
            int[] tmpArray = new int[array.Length - 1];
            int index = 0;
            bool findEven = false;
            foreach (int x in array)
            {
                if (!findEven && (x % 2 == 0))
                    findEven = true;
                else
                    tmpArray[index++] = x;
            }
            array = tmpArray;
        }

        static void RemoveLessThanAVG(ref int[] array)
        {
            if(array.Length == 0)
            {
                Console.WriteLine("Массив не имеет элементов");
                return;
            }
            int sum = 0;
            int lessThanAVG = 0;
            foreach (int x in array)
                sum += x;
            float average = (float)sum / array.Length;
            foreach (int x in array)
                if ((float)x < average) lessThanAVG++;
            int[] tmpArray = new int[array.Length - lessThanAVG];
            int index = 0;
            foreach (int x in array)
            {
                if ((float)x >= average)
                    tmpArray[index++] = x;
            }
            array = tmpArray;
            Console.WriteLine($"Среднее арифметическое элементов массива = {average}" +
                $"\n Количество элементов меньших чем среднее = {lessThanAVG}");
        }

        static void SortEvenElements(int[] array)
        {
            bool IsSorted = false;
            while (!IsSorted)
            {
                IsSorted = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && NextEvenIndex(i) != -1)
                    {
                        if(array[i] > array[NextEvenIndex(i)])
                        {
                            Swap(ref array[i], ref array[NextEvenIndex(i)]);
                            IsSorted = false;
                        }
                    }
                }
            }

            int NextEvenIndex(int currentIndex)
            {
                int nextEven = -1;
                if (currentIndex == array.Length - 1)
                    return nextEven;
                if (array[currentIndex + 1] % 2 == 0)
                    return currentIndex + 1;
                else return NextEvenIndex(currentIndex + 1);
            }
        }

        static void MinMaxReplace(int[] array)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (int x in array)
            {
                if (x < min)
                    min = x;
                if (x > max)
                    max = x;
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == min)
                {
                    array[i] = max;
                    continue;
                }
                if (array[i] == max)
                    array[i] = min;
            }
            Console.WriteLine($"min = {min}, max = {max}");
        }

        static void CountEvenBetweenMinMax(int[] array)
        {
            int min = int.MaxValue;
            int firstMinIndex = 0;
            int max = int.MinValue;
            int lastMaxIndex = array.Length - 1;
            int evenCount = 0;

            for(int i = 0; i < array.Length;i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    firstMinIndex = i;
                }
                if (array[i] >= max)
                {
                    max = array[i];
                    lastMaxIndex = i;
                }
            }

            for (int i = Min(firstMinIndex + 1, lastMaxIndex + 1); 
                i < Max(firstMinIndex, lastMaxIndex); i++)
                if(array[i] % 2 == 0) evenCount++;

            Console.WriteLine($"Индекс первого минимального элемента = {firstMinIndex}" +
                $"\nИндекс последнего максимального элемента = {lastMaxIndex}" +
                $"\nКоличество четных чисел между минимальным и максимальным элементами = {evenCount}");

            int Max(int a, int b)
            {
                if (a > b) return a;
                return b;
            }

            int Min(int a, int b)
            {
                if (a < b) return a;
                return b;
            }
        }

        static void RemoveMinElement(ref int[] array)
        {
            int min = int.MaxValue;
            int minCounter = 0;
            foreach (int x in array)
            {
                if(x < min)
                {
                    min = x;
                }
            }
            foreach (int x in array)
            {
                if (x == min)
                {
                    minCounter++;
                }
            }
            int[] tmpArray = new int[array.Length - minCounter];
            int index = 0;
            foreach (int x in array)
            {
                if (x != min && index < tmpArray.Length)
                    tmpArray[index++] = x;
            }
            array = tmpArray;
        }

        static void PrintArray(int[] array)
        {
            foreach (int x in array)
                Console.Write($"[{x, 4}]");
            Console.WriteLine();
        }

        static int[] GetArrayWithRandom(int min = int.MinValue,
            int max = int.MaxValue)
        {
            int size = GetInt("Введите целочисленный размер массива больше 0", min: 0);
            Random rnd = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
                array[i] = rnd.Next(min, max);
            return array;
        }

        static int GetInt(string invite, int min = int.MinValue,
            int max = int.MaxValue)
        //Получение целого числа в заданном диапазоне с консоли
        //min не включается
        {
            int x = 0;
            bool isChecked = false;
            while (!isChecked)
            {
                Console.WriteLine(invite);
                string input = Console.ReadLine();
                if (!int.TryParse(input, out x))
                {
                    Console.WriteLine("Ошибка ввода! Введено не целое число");
                    continue;
                }
                if (x <= min)
                {
                    Console.WriteLine(
                        $"Ошибка ввода! Введено число меньше допустимого значения {min + 1}");
                    continue;
                }
                if (x > max)
                {
                    Console.WriteLine(
                        $"Ошибка ввода! Введено число больше допустимого значения {max}");
                    continue;
                }
                isChecked = true;
            }
            return x;
        }

        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}
