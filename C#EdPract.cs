using System;

namespace ClassWork1210
{
    class Program
    {
        delegate void SomeTask();
        static void Main(string[] args)
        {
           // SomeTask func = EdPracTask1;
            //TaskLoop(func, "Задание 1", "Вхождение точки в область");

            SomeTask func = EdPracTask3;
            TaskLoop(func, "Задание 3", "Работа с матрицами");
        }

        static void EdPracTask3()
        {
            Console.WriteLine("Задание 393в.\nВывести последовательность из n чисел");
            int n = GetInt(
                "Введите целочисленное неотрицателное значение порядка матрицы: ", min:1);
            int[,] A = GetIntRandSquareMatrix(n, -10, 100);
            PrintMatrix(A);
            int b = 0;
            bool rawHasNegative = false;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                b = 0;
                rawHasNegative = false;
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (rawHasNegative) b += A[i, j];
                    else if(A[i, j] < 0) rawHasNegative = true;
                }
                if (!rawHasNegative) b = 100;
                Console.WriteLine($"b{i} = {b}");
            }
        }

        static void PrintMatrix(int[,] A)
        {
            if(A.GetLength(0) == 0 || A.GetLength(1) == 0)
            {
                Console.WriteLine("Одна из размерности массива нулевая!");
                return;
            }
            if(A.GetLength(0) == A.GetLength(1))
                Console.WriteLine($"Квадратная матрица порядка {A.GetLength(0)}");
            for (int i = 0; i < A.GetLength(0); i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < A.GetLength(1); j++)
                    Console.Write($"[{A[i, j],4}] ");
            }
            Console.WriteLine("");
        }

        static int[,] GetIntRandSquareMatrix(
            int n, int min = int.MinValue, int max = int.MaxValue)
        {
            if(n < 0) throw new Exception("Размер матрицы не может быть отрицательным");
            if(max<min) throw new Exception(
                "Максимальное значение элемента не может быть меньше минимального");
            if (n == 0) return new int[0, 0];
            int[,] A = new int[n, n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    A[i, j] = random.Next(min, max);
            }
            return A;
        }

        static void EdPracTask1()
        {
            Console.WriteLine("Задание 60а.\nВычислить значение переменной u, "
                +"в зависимости от вхождения точки с координатами X,Y в заданную область");
            double x, y, u;
            string answer = " не";
            x = GetDouble("Введите действительное значение координаты Х: ");
            y = GetDouble("Введите действительное значение координаты Y: ");
            if (y >= 0 && y * y + x * x >= 1 && y * y + x * x <= 4)
            {
                answer = "";
                u = 0;
            }
            else u = x;
            Console.WriteLine(
                $"Точка с указанными координатами{answer} входит в заданную область, u = {u}");
        }

        static void TaskLoop(SomeTask func, string name, string definition)
        {
            string input = "";
            Console.WriteLine("\n" + name + "\n" + definition);
            do
            {
                func();
                Console.WriteLine(
                    $"Вы хотите продолжить выполнение \"{name}\"?"
                    + "\nДля выхода введите N");
                input = Console.ReadLine();
            } while (input != "N");
        }
               
        static int GetInt(string invite, int min = int.MinValue,
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
