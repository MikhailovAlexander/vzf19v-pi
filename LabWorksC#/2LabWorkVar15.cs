using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork1610
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1_15();
            Task2_20();
            Task3_49();
            Console.ReadLine();
        }

        static void Task1_15()
        {
            Console.WriteLine("Первое задание. Задача №15." +
                "\nПодсчет количества элелементов, кратных первому\n");
            int firstElement, currentElement, counter, quantity;
            firstElement = 0;
            counter = 0;
            quantity = GetInt(
                "Введите положительное количество элементов последовательности", min: 1);
            while (firstElement == 0)
			//Первый элемент ненулевой, для возможности деления на него
            {
                firstElement = GetInt("Введите ненулевое значение элемента №1");
            }
            for (int i = 2; i <= quantity; i++)
            {
                currentElement = GetInt($"Введите целочисленное значение элемента №{i}");
                if (currentElement % firstElement == 0) counter++;
            }
            Console.WriteLine(
                $"Значение первого элемента последовательности = {firstElement}"
                + $"\nКоличество элементов, кратных первому = {counter}"
                + "(кроме собственно первого)\n");
        }

        static void Task2_20()
        {
            Console.WriteLine("Второе задание. Задача №20." +
                "\nПодсчет суммы элементов, с четными номерами\n");
            int currentElement, summ, n;
            summ = 0;
            n = 1;
            bool final = false;
            while (!final)
            {
                currentElement = GetInt(
                $"Введите целочисленное значение элемента №{n}"
                + "\nДля завершения введите 0");
                if (currentElement == 0)
                {
                    n -= 2;
                    final = true;
                }
                if (n % 2 == 0) summ += currentElement;
                n++;
            }

            Console.WriteLine(
                 $"Введено {n} элементов"
                 + $"\nСумма элементов с четными номерами = {summ}\n");
        }

        static void Task3_49()
        {
            Console.WriteLine("Третье задание. Задача №49." +
                "\nСформировать n чисел Фибоначчи \n");
            int quantity, currentNumber, previousNumber;
            quantity = GetInt("Введите количество чисел не менее 3", min: 3);
            currentNumber = 1;
            previousNumber = 1;
            Console.Write("[1], [1]");
			//Вывод 1-го и 2-го элементов последовательности
            for (int i = 3; i <= quantity; i++)
            {
                int tmp = currentNumber;
                Console.Write($", [{currentNumber += previousNumber}]");
                previousNumber = tmp;
            }
            Console.WriteLine("");
        }

        static int GetInt(string invite, int min = int.MinValue,
            int max = int.MaxValue)
		//Получение целого числа в заданом диапазоне с консоли
        {
            int x=0;
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
                if (x < min)
                {
                    Console.WriteLine(
                        $"Ошибка ввода! Введено число меньше допустимого значения {min}");
                    continue;
                }
                if (x > max)
                {
                    Console.WriteLine(
                        $"Ошибка ввода! Введено число больше допустимого значения {min}");
                    continue;
                }
                isChecked = true;
            }
            return x;
        }
    }
}
