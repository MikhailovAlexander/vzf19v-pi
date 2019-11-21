using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        delegate void SomeTask();
        static void Main(string[] args)
        {
            SomeTask func = Task3;
            TaskLoop(func, "Задание 3", "Операции с тремя числами");

        }

        static void TaskLoop(SomeTask func,string name, string definition)
		//Зацикливание выполнения задания
        {
            string input="";
            Console.WriteLine("\n"+name+"\n"+ definition);
            do
            {
                func();
                Console.WriteLine(
                    $"Вы хотите продолжить выполнение \"{name}\"?"
                    + "\nДля выхода введите N");
                input = Console.ReadLine();
            } while (input != "N");
        }

        static void Task3()
        {
            int a, b, c, max, min;
            int countNegative=0;
            double average;
            a = GetInt("Введите значение числа а:");
            b = GetInt("Введите значение числа b:");
            c = GetInt("Введите значение числа c:");
            if (a > b) max = a;
            else max = b;
            if (max < c) max = c;
            Console.WriteLine($"\nmax = {max}");
            if (a < b) min = a;
            else min = b;
            if (min > c) min = c;
            Console.WriteLine($"\nmin = {min}");
            average = (a + b + c) / 3.0;
            Console.WriteLine($"\naverage = {average}");
            if (a > 0) countNegative++;
            if (b > 0) countNegative++;
            if (c > 0) countNegative++;
            Console.WriteLine(
                $"\nКоличество отрицательных чисел = {countNegative}");
        }

        static void Task2()
        {
            double x = GetDouble("Введите значение Х");
            if (x > 0)
            {
                double r = (1 + x * x) / Math.Sqrt(x - 5);
                Console.WriteLine($"R = {r}");
            }
            else Console.WriteLine(
                "При данном значении Х вычисление выражения невозможно");
        }

        static void Task1()
        {
            double x = GetDouble("Введите значение координаты Х");
            double y = GetDouble("Введите значение координаты Y");
            bool isDotInside = (y >= 0) && (x * x + y * y <= 4) 
                || y < 0 && y >= -1 && x >= -2 && x <= 2;
            if (isDotInside)
                Console.WriteLine("Точка входит в указанную область");
            else Console.WriteLine("Точка не входит в указанную область");
        }

        static double GetDouble(string invite)
        {
            double x = 0;
            string strInput = "";
            do
            {
                Console.WriteLine(invite);
                strInput = Console.ReadLine();
                if (!Double.TryParse(strInput, out x))
                {
                    Console.WriteLine("Ошибка! Введено не действительное число!");
                }
            } while (!Double.TryParse(strInput, out x));
            return x;
        }

        static int GetInt(string invite)
        {
            int x = 0;
            string strInput = "";
            do
            {
                Console.WriteLine(invite);
                strInput = Console.ReadLine();
                if (!int.TryParse(strInput, out x))
                {
                    Console.WriteLine("Ошибка! Введено не целое число!");
                }
            } while (!int.TryParse(strInput, out x));
            return x;
        }
    }
}
