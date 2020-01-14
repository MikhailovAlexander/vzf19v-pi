using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWorks
{
    class LabMethods
    {
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
    }
}
