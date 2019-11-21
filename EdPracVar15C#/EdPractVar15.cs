using System;

namespace ClassWork1210
{
    class Program
    {
        delegate void SomeTask();
        static void Main(string[] args)
        {
            SomeTask func = EdPracTask1;
            TaskLoop(func, "Задание 1", "Вхождение точки в область");

            func = EdPracTask2;
            TaskLoop(func, "Задание 2", "Приближенное вычисление корня");
            
            func = EdPracTask3;
            TaskLoop(func, "Задание 3", "Работа с матрицами");
            
            func = EdPracTask4;
            TaskLoop(func, "Задание 4", "Рекурсия");
        }

        static void EdPracTask1()
        {
            Console.WriteLine("Задание 60а.\nВычислить значение переменной u, "
                + "в зависимости от вхождения точки с координатами X,Y в заданную область");
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
        
        static void EdPracTask2()
        {
            string f = "(4 + x^2)(e^x - e^-x) = 18";
            Console.WriteLine(
                $"Задание 726д.\nВычислить корень уравнения {f} с заданной точностью");
            double x1 = 1.2;
            double x2 = 1.3;
            double eps = GetDouble(
                "Введите действительное положительное значение точности <= 1: ",
                min: 0, max: 1);
            do
            {
                double tmp = x2;
                x2 = (x1 - ((x2 - x1) * F(x1)) / (F(x2) - F(x1)));
                x1 = tmp;
            } while (Math.Abs(x2 - x1) > eps);
            Console.WriteLine($"Корень уравнения {f} вычисленный с точностью {eps} = {x2}");
        }

        static double F(double x)
        //Вычисление значения функции
        {
            return (4 + x * x) * (Math.Pow(Math.E, x) - Math.Pow(Math.E, -x)) - 18;
        }

        static void EdPracTask3()
        {
            Console.WriteLine("Задание 393в.\nВывести последовательность из n чисел");
            int n = GetInt(
                "Введите целочисленное неотрицателное значение порядка матрицы: ", min: 0);
            int[,] A = new int[n, n];
            Console.WriteLine("Чтобы ввести элементы вручную введите 1,"
               + " для случайной генерации введите любой другой символ");
            string answer = Console.ReadLine();
            if (answer == "1") A = GetIntSquareMatrix(n);
            else A = GetIntRandSquareMatrix(n, -10, 100);
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
                    else if (A[i, j] < 0) rawHasNegative = true;
                }
                if (!rawHasNegative) b = 100;
                Console.WriteLine($"b{i + 1} = {b}");
            }
        }

        static void PrintMatrix(int[,] A)
        //Вывод матрицы в консоль
        {
            if (A.GetLength(0) == 0 || A.GetLength(1) == 0)
            {
                Console.WriteLine("Одна из размерности массива нулевая!");
                return;
            }
            if (A.GetLength(0) == A.GetLength(1))
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
        //Получение квадратной матрицы порядка n, со случайными целыми
        //элементами из заданного диапазона
        {
            if (n < 0) throw new Exception("Размер матрицы не может быть отрицательным");
            if (max < min) throw new Exception(
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

        static int[,] GetIntSquareMatrix(int n)
        //Получение квадратной матрицы порядка n
        {
            if (n < 0) throw new Exception("Размер матрицы не может быть отрицательным");
            if (n == 0) return new int[0, 0];
            int[,] A = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Строка №{i + 1}");
                for (int j = 0; j < n; j++)
                    A[i, j] = GetInt($"Введите целочисленное значение элемента №{j + 1}");
            }
            return A;
        }

        static void EdPracTask4()
        {
            Console.WriteLine(
                "Задание 7.\nВывести последовательность чисел, используя рекурсию");
            int n = GetInt("Введите количество чисел > 3", min: 3);
            double a1 = GetDouble("Введите действительное число а1: ");
            double a2 = GetDouble("Введите действительное число а2: ");
            double a3 = GetDouble("Введите действительное число а3: ");
            Console.WriteLine($"Вывод последовательности из {n} чисел начиная с четвертого");
            Print_n_Numbers(a1, a2, a3, n, n);
            double a4 = GetNextNumber(a1, a2, a3);
            double m = GetDouble($"Введите действительное число m > {a4},"
                + "для ограничения значения очередного числа по модулю");
            Console.WriteLine($"Вывод последовательности чисел не превышающих по модулю {m}");
            int j = PrintNumbersLessThan_M(a1, a2, a3, m);
            Console.WriteLine(
                $"Последовательность длиной j = {j}, j {GetResultOfCompare(j, n)} n");
        }

        static string GetResultOfCompare(int a, int b)
        //Возвращает в виде строки результат сравнения двух чисел 
        {
            string result = "";
            result = a > b ? "больше" : "меньше";
			if (a == b) result = "равно";
            return result;
        }

        static double GetNextNumber(double a1, double a2, double a3)
        //Получение очередного числа последовательности
        {
            return (3 / 2.0) * a3 - (2 / 3.0) * a2 - (1 / 3.0) * a1;
        }

        static void Print_n_Numbers(double a1, double a2, double a3, int n, int quantity)
        //Вывод заданного количества членов последовательности
        {
            if (n > 3)
            {
                double currentNumber = GetNextNumber(a1, a2, a3);
                Console.WriteLine($"[{quantity - n + 4,2}]" + currentNumber);
                Print_n_Numbers(a2, a3, currentNumber, n - 1, quantity);
            }
        }

        static int PrintNumbersLessThan_M(double a1, double a2, double a3,
            double m, int count = 3)
        //Вывод последовательности чисел, не превышающих по модулю заданное
        //Возвращает количество чисел
        {
            double currentNumber = GetNextNumber(a1, a2, a3);
            int j = count + 1;

            if (Math.Abs(currentNumber) <= m)
            {
                Console.WriteLine($"[{j,2}] {currentNumber}");
                j = PrintNumbersLessThan_M(a2, a3, currentNumber, m, count: j);
            }
            else
            {
                Console.WriteLine($"Очередное число |{currentNumber}| > m");
                j--;
            }
            return j;
        }

        static void TaskLoop(SomeTask func, string name, string definition)
        //Функция для многократного выполнения заданий
        {
            string input = "";
            Console.WriteLine("\n" + name + "\n" + definition);
            do
            {
                func();
                Console.WriteLine(
                    $"\nВы хотите продолжить выполнение \"{name}\"?"
                    + "\nДля выхода введите N");
                input = Console.ReadLine();
            } while (input != "N");
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
                        $"Ошибка ввода! Введено число меньше допустимого значения {min+1}");
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

        static double GetDouble(string invite, double min = Double.MinValue,
            double max = Double.MaxValue)
        //Получение действительного числа в заданном диапазоне с консоли
        //min не включается
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
    }
}
