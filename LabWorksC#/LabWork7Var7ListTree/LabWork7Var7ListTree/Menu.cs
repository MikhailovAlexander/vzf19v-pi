using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LabWork7Var7ListTree
{
    class Menu
    {
        public static Random rnd;

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

        /// <summary>
        /// Получение действительного числа в заданном диапазоне с консоли
        /// min не включается
        /// </summary>
        /// <param name="invite">Приглашение ко вводу</param>
        /// <param name="min">Минимальное значение (не включается)</param>
        /// <param name="max">Максимальное значение</param>
        /// <returns>Действительное число в заданном диапазоне</returns>
        public static double GetDouble(string invite, double min = Double.MinValue,
            double max = Double.MaxValue)
        {
            double x = 0;
            string input = "";
            bool isChecked = false;
            while (!isChecked)
            {
                Console.WriteLine(invite);
                input = Console.ReadLine();
                if (!Double.TryParse(input, out x))
                {
                    Console.WriteLine("Ошибка ввода! Введено не действительное число");
                    continue;
                }
                if (x <= min)
                {
                    Console.WriteLine(
                        $"Ошибка ввода! Введено число <= допустимого значения {min}");
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
        /// <summary>
        /// Обмен двух переменных переданных по ссылке
        /// </summary>
        /// <typeparam name="T">Тип переменных</typeparam>
        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        int Min(int a, int b) { return a < b ? a : b; }
        int Max(int a, int b) { return a > b ? a : b; }

        public void PrintArray<T>(T[] array)
        {
            if (array.Length == 0) Console.WriteLine("Массив не имеет элементов");
            foreach (T x in array) Console.Write($"[{x.ToString()}] ");
            Console.WriteLine("");
        }

        public void PrintMatrix<T>(T[,] matrix)
        {
            if(matrix.Length == 0) Console.WriteLine($"Массив не имеет элементов");
            for (int raw = 0; raw < matrix.GetLength(0); raw++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                    Console.Write($"[{matrix[raw, column].ToString()}] ");
                Console.WriteLine("");
            }
        }

        public void PrintJagArray<T>(T[][] jagArray)
        {
            if (jagArray.Length == 0) Console.WriteLine("Рваный массив не имеет строк");
            for (int i = 0; i < jagArray.Length; i++)
            {
                if (jagArray[i].Length == 0) Console.Write($"Строка {i} не имеет элементов");
                for (int j = 0; j < jagArray[i].Length; j++)
                    Console.Write($"[{jagArray[i][j],4}] ");
                Console.WriteLine("");
            }
        }

        public static string[] ExtractWords(string input)
        {
            var matches = Regex.Matches(input, @"\b[А-яA-z]+\b");
            string[] words = new string[matches.Count];
            int index = 0;
            foreach (var word in matches)
                words[index++] = word.ToString();
            return words;
        }

        public static string[] GetWords(string invite)
        {
            Console.WriteLine(invite);
            return ExtractWords(Console.ReadLine());
        }
    }
}
