using System;
using System.Text.RegularExpressions;

namespace LabWorks
{
    class Program
    {
        public static void Main()
        {
            Lab6Menu();
        }

        static void Lab5Menu()
        {
            Console.WriteLine("Лабораторная работа №5\nРабота с различными видами массивов");
            string operations = "\nВыбор типа массива:"
                + "\n\t1 Одномерные массивы"
                + "\n\t2 Двумерные массивы"
                + "\n\t3 Рваные массивы"
                + "\n\t4 Повторить меню";
            Console.WriteLine(operations);
            int number = -1;
            while (number != 0)
            {
                number = LabMethods.GetInt("Введите номер операции. Для выхода введите 0, "
                    + "для повтора меню 4", min: -1, max: 10);
                switch (number)
                {
                    case 0: break;
                    case 1: LabIntArray.ArrayMenu(); break;
                    case 2: LabIntMatrix.MatrixMenu(); break;
                    case 3: LabIntJagArray.JagArrayMenu(); break;
                    case 4: Console.WriteLine(operations); break;
                }
            }
        }

        static void Lab6Menu()
        {
            Console.WriteLine("Лабораторная работа №6\nРабота с массивами и строками");
            string operations = "\nВыбор типа массива:"
                + "\n\t1 Одномерные массивы"
                + "\n\t2 Двумерные массивы"
                + "\n\t3 Рваные массивы"
                + "\n\t4 Работа со строками"
                + "\n\t5 Повторить меню";
            Console.WriteLine(operations);
            int number = -1;
            while (number != 0)
            {
                number = LabMethods.GetInt("Введите номер операции. Для выхода введите 0, "
                    + "для повтора меню 5", min: -1, max: 10);
                switch (number)
                {
                    case 0: break;
                    case 1: LabIntArray.ArrayMenu(); break;
                    case 2: LabIntMatrix.MatrixMenu(); break;
                    case 3:LabIntJagArray.JagArrayMenu(); break;
                    case 4: WorkWithStringMenu(); break;
                    case 5: Console.WriteLine(operations); break;
                }
            }
        }

        static void WorkWithStringMenu()
        {
            Console.WriteLine("\nРабота со строками");
            string operations = "\nВыбор операции:"
                + "\n\t1 Ввод строки с консоли"
                + "\n\t2 Вывести строку"
                + "\n\t3 Удалить слова начинающиеся и заканчивающиеся одной буквой"
                + "\n\t4 Повторить меню";
            Console.WriteLine(operations);
            int number = -1;
            string input = "";
            while (number != 0)
            {
                number = LabMethods.GetInt("Введите номер операции. Для выхода введите 0, "
                    + "для повтора меню 4", min: -1, max: 10);
                switch (number)
                {
                    case 0: break;
                    case 1:
                        Console.WriteLine("Введите строку");
                        input = Console.ReadLine();
                        break;
                    case 2:
                        PrintString(input);
                        break;
                    case 3:
                        input = RemoveWordsBegEndSameChar(input);
                        PrintString(input);
                        break;
                    case 4: Console.WriteLine(operations); break;
                }
            }
        }

         static string RemoveWordsBegEndSameChar(string input)
        {
            string pattern = @"\b([А-я])([А-я])*(\1)\b|\b[А-я]\b";
            return Regex.Replace(input, pattern, String.Empty, RegexOptions.IgnoreCase);
        }

        static void PrintString(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
                Console.WriteLine("Строка не содержит символов (без учета пробелов)");
            else Console.WriteLine("\n" + input + "\n");
        }
    }
}
