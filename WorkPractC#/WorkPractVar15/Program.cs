using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPractVar15
{
    class Program
    {
        delegate void SomeTask();
        static void Main(string[] args)
        {
            SomeTask func = TestBlockSort;
            TaskLoop(func, "Задание 1", "Блочная сортировка целочисленного массива");

            func = TestMergeSort;
            TaskLoop(func, "Задание 2", "Сортировка целочисленного массива слиянием");
        }

        static void TestBlockSort()
        {
            int[] array = GetArray();
            int numberOfBlocks = GetInt(
                $"Введите количество блоков для сортировки от 1 до {array.Length}",
                min: 0, max: array.Length);
            array = ArraySortMethods.BlockSort(array, numberOfBlocks, debug: false);
            PrintArray(array);
        }

        static void TestMergeSort()
        {
            int[] array = GetArray();
            Console.WriteLine("Отсортированный массив");
            PrintArray(ArraySortMethods.MergeSort(array));
        }

        static int[] GetArray()
        {
            int[] array = new int[0];
            Console.WriteLine("Чтобы ввести элементы вручную введите 1,"
               + " для случайной генерации введите любой другой символ");
            string answer = Console.ReadLine();
            if (answer == "1") array = GetIntArrayWithInput();
            else array = GetIntArrayWithRandom(-100, 100);
            PrintArray(array);
            return array;
        }

        static int[] GetIntArrayWithInput()
        {
            int arrayLength = GetInt(
               "Введите целочисленный неотрицательный размер массива: ", min: -1);
            int[] array = new int[arrayLength];
            for (int i = 0; i < array.Length; i++)
                array[i] = GetInt(
                    "Введите целочисленный значение элемента массива: ");
            return array;
        }

        static int[] GetIntArrayWithRandom(int min = -100, int max = 100)
        {
            Random rnd = new Random();
            int arrayLength = GetInt(
               "Введите целочисленный неотрицательный размер массива: ", min: -1);
            int[] array = new int[arrayLength];
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(min, max);
            return array;
        }

        static void PrintArray(int[] array)
        {
            if (array.Length == 0) Console.WriteLine("Массив не имеет элементов");
            foreach (int x in array) Console.Write($"[{x,4}] ");
            Console.WriteLine();
        }

        /// <summary>
        /// Функция для многократного выполнения подпрограмм
        /// </summary>
        /// <param name="func">Подпрограмма для выполнения</param>
        /// <param name="name">Заголовок для вывода в консоль</param>
        /// <param name="definition">Описание для вывода в консоль</param>
        static void TaskLoop(SomeTask func, string name, string definition)
        {
            string input = "";
            Console.WriteLine(String.Join("\n", "", name, definition));
            do
            {
                func();
                Console.WriteLine(
                    $"\nВы хотите продолжить выполнение \"{name}\"?"
                    + "\nДля выхода введите N");
                input = Console.ReadLine();
            } while (input != "N");
        }

        /// <summary>
        /// Получение целого числа в заданном диапазоне с консоли
        /// min не включается
        /// </summary>
        /// <param name="invite">Приглашение ко вводу</param>
        /// <param name="min">Минимальное значение (не включается)</param>
        /// <param name="max">Максимальное значение</param>
        /// <returns>Целое число в заданном диапазоне</returns>
        public static int GetInt(string invite, int min = int.MinValue,
            int max = int.MaxValue)
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

    }
}
