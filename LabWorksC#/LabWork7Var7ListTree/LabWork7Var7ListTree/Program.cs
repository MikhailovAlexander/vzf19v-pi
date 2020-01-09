using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LabWork7Var7ListTree
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }

        public static void ShowMenu()
        {
            Console.WriteLine("\nРабота со списками и деревьями");
            var tree = new TreeString();
            string operations = "Выберите меню:"
                + "\n\t1 Меню работы со списками"
                + "\n\t2 Меню работы с двусвязными списками"
                + "\n\t3 Меню работы с деревьями";
            int number = -1;
            while (number != 0)
            {
                Console.WriteLine(operations);
                number = Menu.GetInt("Введите номер операции. Для выхода введите 0, "
                    + "для повтора меню 11", min: -1, max: 5);
                switch (number)
                {
                    case 0: break;
                    case 1:
                        LinkedListDoubleMenu.Show();
                        break;
                    case 2:
                        BiLinkedListIntMenu.Show();
                        break;
                    case 3:
                        TreeStringMenu.Show();
                        break;
                }
            }
        }
    }
}
