using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork0712
{
    class Program
    {
        delegate void SomeTask();
        static void Main(string[] args)
        {
            SomeTask func = GetRandomArray;
            TaskLoop(func, "Задание 1", "Массив неповторяющихся элементов");

            func = SoccerTable;
            TaskLoop(func, "Задание 2", "Результаты игры футбольной команды");

            func = SignChangeCount;
            TaskLoop(func, "Задание 3", "Подсчитать количество смены знаков элементов массива");

            func = WindDirection;
            TaskLoop(func, "Задание 4", "Определить расположение жилого комплекса");

            func = ChineseCalendar;
            TaskLoop(func, "Задание 5", "Восточный календарь");
        }

        static void GetRandomArray()
        {
            Random rnd = new Random();
            int[] array = new int[20];
            int currentNumber = rnd.Next(-100, 100);
            Console.WriteLine("Массив из 20 неповторяющихся рандомных элементов");
            for (int i = 0; i < 20; i++)
            {
                do { currentNumber = rnd.Next(-100, 100); }
                    while (Array.IndexOf(array, currentNumber) != -1);
                array[i] = currentNumber;
                Console.Write($"[{array[i],3}] ");
            }
            Console.WriteLine();
        }

        static void SoccerTable()
        {
            int[,] table = new int[2, 22];
            Console.WriteLine("Таблица забитых и пропущенных мячей команды");
            PrintHead();
            PrintLine();
            Random rnd = new Random();
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if(i == 0) Console.Write("Забитые мячи     ");
                else Console.Write("Пропущенные мячи ");
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = rnd.Next(0, 11);
                    Console.Write($"|{table[i, j],2}");
                }
                Console.WriteLine("|");
                PrintLine();
            }
            Console.WriteLine("Результаты игр команды");
            string result = String.Empty;
            int drawnCount = 0;
            int winCount = 0;
            int looseCount = 0;
            int diffOver3Count = 0;
            int score = 0;
            for (int i = 0; i < table.GetLength(1); i++)
            {
                if (Math.Abs(table[0, i] - table[1, i]) >= 3)
                    diffOver3Count++;
                if (table[0, i] == table[1, i])
                {
                    result = "ничья";
                    drawnCount++;
                    score++;
                }
                else if (table[0, i] > table[1, i])
                {
                    result = "выигрыш";
                    winCount++;
                    score += 3;
                }
                else
                {
                    result = "проигрыш";
                    looseCount++;
                }
                Console.WriteLine($"\tРезультаты игры {i + 1} : {result}");
            }
            Console.WriteLine($"\nКоличество выигрышей команды: {winCount}" +
                $"\nКоличество проигрышей: {looseCount}" +
                $"\nКоличество ничьих команды: {drawnCount}" +
                $"\nКоличество игр с разностью забитых и пропущеных мячей >= 3: {diffOver3Count}" +
                $"\nКоличество очков команды: {score}");

            void PrintLine()
            {
                Console.Write("-----------------");
                for (int i = 0; i < table.GetLength(1); i++)
                    Console.Write("+--");
                Console.WriteLine("+");
            }
            void PrintHead()
            {
                PrintLine();
                Console.Write("Номер игры       ");
                for (int i = 0; i < table.GetLength(1); i++)
                    Console.Write($"|{i + 1,2}");
                Console.WriteLine("|");
            }
           
        }

        static void SignChangeCount()
        {
            int size = GetInt("Введите целый положительный размер массива", min: 0);
            int[] array = new int[size];
            Random rnd = new Random();
            int currentNumber = rnd.Next(0, 100);
            array[0] = currentNumber;
            int signChangeCount = 0;
            Console.Write(
                $"Целочисленный массив со случайными элементами:\n[{array[0],4}] ");
            for (int i = 1; i < size; i++)
            {
                do { currentNumber = rnd.Next(-100, 100); }
                while (currentNumber == 0);
                array[i] = rnd.Next(-100, 100);
                Console.Write($"[{array[i],4}] ");
                if (array[i] * array[i - 1] < 0)
                    signChangeCount++;
            }
            Console.WriteLine(
                $"\nПри просмотре массива элементы меняют знак {signChangeCount} раз");
        }

        static void WindDirection()
        {
            Dictionary<int, string> windDirectionName = new Dictionary<int, string>
            {
                [1] = "северный",
                [2] = "южный",
                [3] = "восточный",
                [4] = "западный",
                [5] = "северо-западный",
                [6] = "северо-восточный",
                [7] = "юго-западный",
                [8] = "юго-восточный",
            };
            int[] windArray = new int[365];
            int[] windFrequency = new int[8];
            Random rnd = new Random();
            Console.WriteLine("Наблюдения ветра в течение года:");
            for(int i = 0; i < 365; i++)
            {
                windArray[i] = rnd.Next(1,9);
                Console.Write($"[{windArray[i]}] ");
                windFrequency[windArray[i] - 1]++;
            }

            int maxValue = 0;
            List<int> maxValueDirections = new List<int>();

            Console.WriteLine("\nНаправления ветра в течение года:");
            for (int i = 0; i < windFrequency.Length; i++)
            {
                if(windFrequency[i] > maxValue)
                {
                    maxValue = windFrequency[i];
                    maxValueDirections.Clear();
                    maxValueDirections.Add(i + 1);
                }
                else if (windFrequency[i] == maxValue)
                {
                    maxValueDirections.Add(i + 1);
                }
                Console.WriteLine($"\t{windDirectionName[i + 1]}: {windFrequency[i]} дн.");
            }
            
            Console.WriteLine("Направления ветра c максимальным количеством ветренных дней:");
            foreach (int value in maxValueDirections)
                Console.WriteLine($"\t{windDirectionName[value]}: {windFrequency[value - 1]} дн.");
            Console.WriteLine(
                "Жилой комплекс стоит расположить с одной из максимально-ветренных сторон от " +
                "комбината.\nP.S. Чтобы ветер дул с комплекса на комбинат.");
        }

        static void ChineseCalendar()
        {
            int year = GetInt("Введите год нашей эры", min: 0) - 4;
            Dictionary<int, string> animals = new Dictionary<int, string>
            {
                [0] = "Крыса",
                [1] = "Корова",
                [2] = "Тигр",
                [3] = "Заяц",
                [4] = "Дракон",
                [5] = "Змея",
                [6] = "Лошадь",
                [7] = "Овца",
                [8] = "Обезьяна",
                [9] = "Петух",
                [10] = "Собака",
                [11] = "Свинья"
            };
            Dictionary<int, string> colors = new Dictionary<int, string>
            {
                [0] = "Зеленый",
                [1] = "Зеленый",
                [2] = "Красный",
                [3] = "Красный",
                [4] = "Желтый",
                [5] = "Желтый",
                [6] = "Белый",
                [7] = "Белый",
                [8] = "Черный",
                [9] = "Черный",
            };
            string yearColor = colors[year % 10];
            string yearAnimal = animals[year % 12];

            Console.WriteLine($"Год: {year + 4}, животное: {yearAnimal}, цвет: {yearColor}.");
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
    }
}
