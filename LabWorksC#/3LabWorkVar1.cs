using System;

namespace Lab_3_Mikhailov
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, an, sn, se, an_prev;
            int n = new int();
            sn = se = 1;
            for (x = 0.1; x <= 1; x += 0.1)//Перебирает значения переменной х
            {
                y = Math.Pow(3, x);
                Console.Write("\nX = {0} ", x);
                Console.Write(" Y = " + y);//Вывод точного значения функции
                for (n = 1; n <= 10; n++)//Вычисление частичной n-й суммы ряда
                {
                    an = (Math.Pow(Math.Log(3), n) * Math.Pow(x, n)) / Fact(n);
                    //Вычисление n-го члена ряда
                    sn += an; //Вычисление n-й частичной суммы
                }
                Console.Write(" SN = {0}", sn);
                //Вывод n-й частичной суммы ряда (n задано)
                sn = se = n = 1;
                an = an_prev = 0;
                do//Вычисление n-й частичной суммы заданной точности
                {
                    an_prev = an;
                    an = (Math.Pow(Math.Log(3), n) * Math.Pow(x, n)) / Fact(n);
                    se += an;
                    n += 1;
                }
                while (Math.Abs(an_prev - an) > 0.0001);
                Console.Write(" SE = {0}", se);
                //Вывод n-й частичной суммы ряда(заданной точности) 
                se = 1;
            }
            Console.WriteLine("\nPress any key");
            Console.ReadKey();
        }
        public static long Fact(int n) //Вычисление факториала числа
        {
            long fact = 1;
            for (int i = 2; i <= n; i++)
            {
                fact *= i;
            }
            return fact;
        }
    }
}