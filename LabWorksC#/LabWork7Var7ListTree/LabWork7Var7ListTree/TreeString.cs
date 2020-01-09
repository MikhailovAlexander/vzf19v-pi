using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork7Var7ListTree
{
    class TreeString
    {
        private TreeString left;
        private TreeString right;
        private TreeString parent;
        private string value;

        public string Value
        {
            get { return value; }
        }
        public TreeString Left
        {
            get { return left; }
        }
        public TreeString Right
        {
            get { return right; }
        }
        public TreeString Parent
        {
            get { return parent; }
        }
        public bool IsEmpty
        {
            get { return Value == null; }
        }
        public bool IsRoot
        {
            get { return parent == null; }
        }
        public bool IsLeaf
        {
            get { return left == null && right == null; }
        }
        public bool HasLeft
        {
            get { return !(left == null); }
        }
        public bool HasRight
        {
            get { return !(right == null); }
        }
        public int Count
        {
            get { return CountElements(); }
        }
        public int Levels
        {
            get { return CountLevels(); }
        }

        public TreeString()
        {
            value = null;
            parent = null;
            left = null;
            right = null;
        }

        public TreeString(string value)
        {
            this.value = value;
            parent = null;
            left = null;
            right = null;
        }

        private TreeString(TreeString parent, string value)
        {
            this.value = value;
            this.parent = parent;
            left = null;
            right = null;
        }
        /// <summary>
        /// Создание левого элемента с заданным значением
        /// </summary>
        /// <param name="value">значение для добавления</param>
        /// <returns></returns>
        private TreeString AddLeft(string value)
        {
            left = new TreeString(this, value);
            return Left;
        }
        /// <summary>
        /// Создание правого элемента с заданным значением
        /// </summary>
        /// <param name="value">значение для добавления</param>
        /// <returns></returns>
        private TreeString AddRight(string value)
        {
            right = new TreeString(this, value);
            return Right;
        }
        /// <summary>
        /// Добавление дерева в качестве левого элемента
        /// </summary>
        /// <param name="tree">дерево для добавления</param>
        private void AddLeft(TreeString tree)
        {
            left = tree;
            left.parent = this;
        }
        /// <summary>
        /// Добавление дерева в качестве правого элемента
        /// </summary>
        /// <param name="tree">дерево для добавления</param>
        private void AddRight(TreeString tree)
        {
            right = tree;
            right.parent = this;
        }
        /// <summary>
        /// Поиск значения в дереве
        /// </summary>
        /// <param name="value">значение для поиска</param>
        /// <returns>элемент содержащий заданное значение либо null</returns>
        public TreeString Find(string value)
        {
            if (IsEmpty) return null;
            if (Value == value) return this;
            if (IsLeaf) return null;
            else if (Value.CompareTo(value) > 0)
                return Left?.Find(value);
            else return Right?.Find(value);
        }
        /// <summary>
        /// Проверка наличия элемента в дереве
        /// </summary>
        /// <param name="value">значение для проверки</param>
        /// <returns></returns>
        public bool Has(string value)
        {
            return Find(value) != null;
        }
        /// <summary>
        /// Вывод дерева в консоль(боком)
        /// </summary>
        /// <param name="tab">отступ для формирования иерархии</param>
        public void Show(int tab = 0)
        {
            if(IsEmpty)
            {
                Console.WriteLine("Дерево не имеет элементов");
                return;
            }
            Left?.Show(tab + 3);
            Console.WriteLine(new string(' ', tab) + Value.ToString());
            Right?.Show(tab + 3);
        }
        /// <summary>
        /// Добавление нового элемента с заданным значением(упорядоченное)
        /// </summary>
        /// <param name="newValue">значение для добавления</param>
        /// <returns>возвращает новый элемент илм существующий(если значение имеется в дереве)</returns>
        public TreeString Add(string newValue)
        {
            if (IsEmpty)
            {
                this.value = newValue;
                return this;
            }
            bool isFind = false;
            TreeString currentKnot = this;
            TreeString previousKnot = this.Parent;
            while (currentKnot != null && !isFind)
            {
                previousKnot = currentKnot;
                if (newValue == currentKnot.Value) isFind = true;
                else if (currentKnot.Value.CompareTo(newValue) > 0)
                    currentKnot = currentKnot.Left;
                else currentKnot = currentKnot.Right;
            }
            if (isFind) return currentKnot;
            if (previousKnot.Value.CompareTo(newValue) > 0)
                return previousKnot.AddLeft(newValue); 
            else return previousKnot.AddRight(newValue);
        }
        /// <summary>
        /// Создание идеального дереваб не упорядоченного
        /// </summary>
        /// <param name="values">массив строк для добавления</param>
        /// <returns></returns>
        public static TreeString IdealTree(params string[] values)
        {
            if (values.Length == 0) return null;
            int sizeLeft = values.Length / 2;
            int sizeRight = values.Length - sizeLeft - 1;
            TreeString currentKnot = new TreeString(values[0]);
            if (sizeLeft > 0)
            {
                string[] leftArray = new string[sizeLeft];
                Array.Copy(values, 1, leftArray, 0, sizeLeft);
                currentKnot.left = IdealTree(leftArray);
                currentKnot.left.parent = currentKnot;
            }
            if(sizeRight > 0)
            {
                string[] rightArray = new string[sizeRight];
                Array.Copy(values, sizeLeft + 1, rightArray, 0, sizeRight);
                currentKnot.right = IdealTree(rightArray);
                currentKnot.right.parent = currentKnot;
            }
            return currentKnot;
        }
        /// <summary>
        /// Рекурсивный подсчет количества элементов дерева
        /// </summary>
        private int CountElements()
        {
            int counter = 0;
            CountRecursive(this);
            return counter;

            void CountRecursive(TreeString currentKnot)
            {
                counter++;
                if (currentKnot.HasLeft) CountRecursive(currentKnot.Left);
                if (currentKnot.HasRight) CountRecursive(currentKnot.Right);
            }
        }
        /// <summary>
        /// Рекурсивный подсчет количества уровней дерева
        /// </summary>
        /// <returns></returns>
        private int CountLevels()
        {
            int maxLevel = 0;
            CountRecursive(this, 0);
            return maxLevel;

            void CountRecursive(TreeString currentKnot, int currentlevel)
            {
                currentlevel++;
                if (currentlevel > maxLevel) maxLevel = currentlevel;
                if (currentKnot.HasLeft) CountRecursive(currentKnot.Left, currentlevel);
                if (currentKnot.HasRight) CountRecursive(currentKnot.Right, currentlevel);
            }
        }
        /// <summary>
        /// Конвертация дерева в рваный массив, отсутствующие элементы представлены пустыми строками
        /// </summary>
        public string[][] ToJagArray()
        {
            if (IsEmpty) return new string[0][];
            string[][] array = new string[Levels][];
            for(int i = 0; i  <array.Length; i++)
            {
                array[i] = new string[(int)Math.Pow(2,i)];
                for (int j = 0; j < array[i].Length; j++)
                    array[i][j] = String.Empty;
            }

            RecursCopyToArray(this, 0, 0);
            return array;

            void RecursCopyToArray(TreeString currentKnot, int level, int position)
            {
                array[level][position] = currentKnot.value;
                if (currentKnot.HasLeft) RecursCopyToArray(currentKnot.left, level+1, position*2);
                if (currentKnot.HasRight) RecursCopyToArray(currentKnot.right, level+1, position*2 + 1);
            }            
        }
    }
}
