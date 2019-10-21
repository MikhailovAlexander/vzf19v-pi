using System;

namespace Lab_3_Mikhailov
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, an, sn, se, an_prev;
            int n = new int();
            sn = se = 0;
            for (x = 0.1; x <= 1; x += 0.1 )//Перебирает значения переменной х
            {
                y = (1 + x * x) * Math.Atan(x) / 2.0 - x / 2.0;                    ;
                Console.Write($"\nЗначение X = {x:f1} ");
                Console.Write($"Точное значение функции Y = {y:f10}");//Вывод точного значения функции
                for (n = 1; n <= 30; n++)//Вычисление частичной n-й суммы ряда
                {
                    an = Math.Pow(-1, n + 1) * Math.Pow(x, 2 * n + 1) / 
                        (4 * Math.Pow(n, 2) - 1);//Вычисление n-го члена ряда
                    sn += an; //Вычисление n-й частичной суммы
                }
                Console.Write($" SN = {sn:f10}");
                //Вывод n-й частичной суммы ряда (n задано)
                sn = 0;
                an = 0;
                an_prev = 0;
                n = 1;
                do//Вычисление n-й частичной суммы заданной точности
                {
                    an_prev = an;
                    an = Math.Pow(-1, n + 1) * Math.Pow(x, 2 * n + 1) /
                        (4 * Math.Pow(n, 2) - 1);
                    se += an;
                    n++;
                }
                while (Math.Abs(an_prev - an) > 0.0001);
                Console.Write($" SE = {se:f10}"); 
                //Вывод n-й частичной суммы ряда(заданной точности) 
                se = 0;
             }
            Console.WriteLine("\nPress any key");
            Console.ReadKey();
        }
    }
}