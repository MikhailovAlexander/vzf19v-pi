using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork1210
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
        }
        
        static void Task1()
        {
            Console.WriteLine("Задание №1\n");
            string answer = "";
            do
            {
                Calculations();
                Console.WriteLine(
                    "\nВы хотите продолжить выполнение задания 1?"
                    +"\nДля выхода введите N, для продолжения любой другой символ");
                answer = Console.ReadLine();
            } while (answer != "N");
        }

        static void Calculations()
        {
            int m = GetInt("Введите целое число m");
            int n = GetInt("Введите целое число n");

            if (m - 1 == 0) Console.WriteLine("n++ / --m нельзя вычислить");
            else Console.WriteLine($"m={m}, n={n}, n++ / --m = {n++ / --m}");

            if (m == 0) Console.WriteLine("n-- > n / m++ нельзя вычислить");
            else Console.WriteLine($"m={m}, n={n}, n-- > n / m++ = {(bool)(n-- > n / m++)}");

            Console.WriteLine($"m={m}, n={n}, m<n++ = {(bool)(m < n++)}");

            double x = GetDouble("Введите вещественное число Х");
            double resultX = 1 + x * Math.Pow(Math.Cos(x), 2) + Math.Pow(Math.Sin(x), 3);
            Console.WriteLine($"x={x}, выражение 1 + xcos^2(x) + sin^3(x) = {resultX}");
        }

        static void Task2()
        {
            Console.WriteLine("\nЗадание №2\n");
            CheckDot();
            string answer = "Y";
            while (answer == "Y")
            {
                Console.WriteLine("\nВы хотите продолжить выполнение задания 2? Введите Y/N");
                answer = Console.ReadLine();
                if (answer == "Y") CheckDot();
                else if (answer == "N") break;
                else
                {
                    Console.WriteLine("Введено некорректное значение ответа!");
                    answer = "Y";
                }
            }
        }

        static void CheckDot()
        {
            double x = GetDouble("Введите значение координаты Х");
            double y = GetDouble("Введите значение координаты Y");
            bool isDotInArea = Math.Sqrt(x * x + y * y) <= 1f && (x <= 0 || y <= 0);
            Console.WriteLine(isDotInArea ?
                "Точка, с указанными координатами входит в заданную область" :
                "Точка, с указанными координатами не входит в заданную область");
        }
        
        static void Task3()
        {
            Console.WriteLine("\nЗадание №3\n");
            float a = 10f;
            float b = 0.01f;
            float resultF = 
                ((float)Math.Pow((a-b),4)-((float)Math.Pow(a,4)-4*(float)Math.Pow(a,3)*b))
                /(6*(float)Math.Pow(a,2)*(float)Math.Pow(b,2)-4*a*(float)Math.Pow(b,3)
                +(float)Math.Pow(b,4));

            double aD = 10;
            double bD = 0.01;
            double resultD = 
                (Math.Pow((aD-bD),4)-(Math.Pow(aD,4)-4*Math.Pow(aD,3)* bD))
                /(6*Math.Pow(aD,2)*Math.Pow(bD,2)-4*aD*Math.Pow(bD,3)+Math.Pow(bD,4));

            Console.WriteLine($"Вычисления с типом float, результат: {resultF}"
                +$"\nВычисления с типом double, результат: {resultD}");
            Console.ReadKey();
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
    }
}
