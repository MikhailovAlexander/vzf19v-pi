using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork7Var7ListTree
{
    class TreeStringMenu : Menu
    {
        public static void Show()
        {
            Console.WriteLine("\nРабота с деревьями");
            var tree = new TreeString();
            string operations = "Операции с деревьями:"
                + "\n\t1 Создать пустое дерево"
                + "\n\t2 Создать дерево с заданым значением"
                + "\n\t3 Вывести дерево в консоль боком"
                + "\n\t4 Добавить элемент в дерево (упорядочено)"
                + "\n\t5 Подсчет количества элементов начинающихся с заданного символа"
                + "\n\t6 Вывести количество элементов в дереве"
                + "\n\t7 Вывести количество уровней в дереве"
                + "\n\t8 Создать дерево из слов из заданой строки (упорядочено)"
                + "\n\t9 Создать идеальное дерево из слов из заданой строки(не упорядоченно)"
                + "\n\t10 Вывести дерево сверху вниз (красиво)"
                + "\n\t11 Повтор меню";
            Console.WriteLine(operations);
            int number = -1;
            while (number != 0)
            {
                number = GetInt("Введите номер операции. Для выхода введите 0, "
                    + "для повтора меню 11", min: -1, max: 12);
                switch (number)
                {
                    case 0: break;
                    case 1:
                        tree = new TreeString(); break;
                    case 2:
                        Console.Write("\tВведите строку для добавления в дерево:\n\t");
                        tree = new TreeString(Console.ReadLine());
                        tree.Show();
                        break;
                    case 3: tree.Show(); break;
                    case 4:
                        Console.Write("\tВведите строку для добавления в дерево:\n\t");
                        tree.Add(Console.ReadLine());
                        tree.Show();
                        break;
                    case 5:
                        CountCompare(tree);
                        break;
                    case 6:
                        Console.WriteLine($"Количество элементов в дереве {tree.Count}");
                        break;
                    case 7:
                        Console.WriteLine($"Количество уровней в дереве {tree.Levels}"); ;
                        break;
                    case 8:
                        tree = GetTreeFromString();
                        tree.Show();
                        break;
                    case 9:
                        tree = GetIdealTreeFromString();
                        tree.Show();
                        break;
                    case 10:
                        var printer = new TreePrinter(tree);
                        printer.Print();
                        break;
                    case 11:
                        Console.WriteLine(operations);
                        break;
                }
            }
        }

        private static TreeString GetIdealTreeFromString()
        {
            var tempArray = GetWords("Введите строку из слов").Distinct();
            string[] words = new string[tempArray.Count()];
            if (words.Length == 0) return new TreeString();
            int index = 0;
            foreach (var word in tempArray)
                words[index++] = word.ToString();
            return TreeString.IdealTree(words);
        }

        private static TreeString GetTreeFromString()
        {
            var  words = GetWords("Введите строку из слов").Distinct();
            TreeString tree = new TreeString();
            foreach (var word in words)
                tree.Add(word);
            return tree;
        }

        private static void CountCompare(TreeString tree)
        {
            Console.WriteLine(
                "Введите символ для поиска:");
            string charToSearch = Console.ReadKey().KeyChar.ToString();
            int counter = 0;
            Count(tree);
            Console.WriteLine($"\nКоличество элементов начинающихся с заданного символа = {counter}");

            void Count(TreeString _tree)
            {
                if (_tree.Value.StartsWith(charToSearch))
                {
                    counter++;
                }
                if (_tree.Left != null)
                    Count(_tree.Left);
                if (_tree.Right != null)
                    Count(_tree.Right);
            }
        }
    }
}
