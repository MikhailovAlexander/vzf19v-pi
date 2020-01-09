using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork7Var7ListTree
{
    /// <summary>
    /// Класс для вывода консоль бинарного дерева со строковыми элементами
    /// </summary>
    class TreePrinter
    {
        /// <summary>
        /// Вложенный класс, элементы которого повторяют структуру выводимого дерева
        /// </summary>
        private class PrinterNode
        {
            private string text;
            PrinterNode Parent, Left, Right;
            string Text
            {
                get { return text; }
                set { text = $"[{value}] "; }
            }
            private readonly int level;
            int Size { get { return text.Length; } }
            int StartPosition { get; set; }
            int EndPosition {
                get
                {
                    if (StartPosition == -1) return -1; 
                    return StartPosition + Size;
                }
            }
            int Midle
            {
                get
                {
                    if (StartPosition == -1) return -1;
                    return StartPosition + Size/2;
                }
            }
            bool HasLeft { get { return Left != null; } }
            bool HasRight { get { return Right  != null; } }
            public int Levels { get { return CountLevels(); } }

            /// <summary>
            /// Рекурсивное создание элементов принтера
            /// </summary>
            /// <param name="tree">Элемент дерева</param>
            /// <param name="parent">Предок создаваемого элемента</param>
            /// <param name="level">Уровень создаваемого элемента</param>
            public PrinterNode(TreeString tree, PrinterNode parent = null, int level = 0)
            {
                if (parent != null)
                    Parent = parent;
                this.level = level;
                Text = tree.Value;
                if (tree.HasLeft)
                    this.Left = new PrinterNode(tree.Left, this, level + 1);
                if (tree.HasRight)
                    this.Right = new PrinterNode(tree.Right, this, level + 1);
                StartPosition = -1;
            }
            /// <summary>
            /// Рекурсивный подсчет количества уровней дерева
            /// </summary>
            /// <returns></returns>
            private int CountLevels()
            {
                int maxLevel = 0;
                CountRecursive(this);
                return maxLevel;

                void CountRecursive(PrinterNode currentKnot, int currentlevel = 0)
                {
                    currentlevel++;
                    if (currentlevel > maxLevel) maxLevel = currentlevel;
                    if (currentKnot.HasLeft) CountRecursive(currentKnot.Left, currentlevel);
                    if (currentKnot.HasRight) CountRecursive(currentKnot.Right, currentlevel);
                }
            }
            /// <summary>
            /// Установление отступа от левого края для каждого элемента дерева
            /// </summary>
            /// <param name="leftBorder">Левая граница</param>
            /// <returns></returns>
            public int SetPositions(int leftBorder = 0)
            {
                StartPosition = leftBorder;
                if (HasLeft)
                    StartPosition = Max(StartPosition, Left.SetPositions(leftBorder) - Size / 2);
                if (HasRight)
                    return Max(EndPosition, Right.SetPositions(Midle));
                return EndPosition + 1;
            }
            /// <summary>
            /// Рекурсивный вывод элемента дерева в консоль
            /// </summary>
            /// <param name="cursorTop">Положение курсора на начало вывода дерева</param>
            public void Print(int cursorTop)
            {
                try
                {
                    string edge = String.Empty;
                    Console.SetCursorPosition(StartPosition, cursorTop + level * 2);
                    Console.Write(Text);
                    if (HasLeft)
                    {
                        edge = $"┌{new String('─', Max(0, this.Midle - Left.Midle - 3))}┘";
                        Console.SetCursorPosition(Left.Midle, cursorTop + level * 2 + 1);
                        Console.Write(edge);
                        Left.Print(cursorTop);
                    }
                    if (HasRight)
                    {
                        edge = $"└{new String('─', Max(0, Right.Midle - this.Midle - 3))}┐";
                        Console.SetCursorPosition(Midle, cursorTop + level * 2 + 1);
                        Console.Write(edge);
                        Right.Print(cursorTop);
                    }
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Console.Write("!!Ошибка!!");
                    Console.SetCursorPosition(0, Console.CursorTop + this.Levels * 2);
                    Console.Write("Ошибка! Дерево не может быть выведено полностью, не хватает размера буфера");
                }
            }
            int Min(int a, int b) { return a < b ? a : b; }
            int Max(int a, int b) { return a > b ? a : b; }
        }

        private PrinterNode root;
        public bool IsEmpty { get { return root == null; } }

        public TreePrinter(TreeString tree)
        {
            root = new PrinterNode(tree);
        }
        /// <summary>
        /// Публичный метод для вывода всего дерева в консоль
        /// </summary>
        public void Print()
        {
            if(IsEmpty)
            {
                Console.WriteLine("Дерево пусто");
                return;
            }
            Console.BufferWidth = Console.BufferWidth * 2;
            root.SetPositions();
            Console.WriteLine("Вывод бинарного дерева:");
            int cursorTopCurrent = Console.CursorTop;
            root.Print(cursorTopCurrent + 1);
            Console.SetCursorPosition(0, cursorTopCurrent + root.Levels * 2 + 2);
            Console.BufferWidth = Console.BufferWidth/2;
        }
    }
}
