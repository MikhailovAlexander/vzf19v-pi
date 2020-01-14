using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWorks
{
    class LabIntMatrix
    {
        public int[,] matrix;
        public int RawCount
        {
            get { return matrix.GetLength(0); }
        }

        public int ColumnCount

        {
            get { return matrix.GetLength(1); }
        }

        public LabIntMatrix(int raws, int columns)
        {
            if (raws <= 0|| columns <= 0) throw new Exception(
                "Значение размерности матрицы не может быть меньше 1");
            matrix = new int[raws, columns];
        }

        public void SetRandomElements(int min = int.MinValue,
            int max = int.MaxValue)
        {
            if (max < min) throw new Exception(
                "Максимальное значение элемента не может быть меньше минимального");
            Random random = new Random();
            for (int raw = 0; raw < RawCount; raw++)
            {
                for(int column = 0; column < ColumnCount; column++)
                {
                    matrix[raw, column] = random.Next(min, max);
                }
            }
        }

        public void PrintMatrix()
        {
            Console.WriteLine($"Целочисленная матрица размером {RawCount}*{ColumnCount}");
            for (int raw = 0; raw < RawCount; raw++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    Console.Write($"[{matrix[raw, column],4}] ");
                }
                Console.WriteLine("");
            }
        }

        public void RemoveEvenRaws()
        {
            int[,] tmpMatrix = new int[RawCount / 2, ColumnCount];
            int tmpRaw = 0;
            for (int raw = 0; raw < RawCount; raw++)
            {
                if (raw % 2 == 0) continue;
                for (int column = 0; column < ColumnCount; column++)
                {
                    tmpMatrix[tmpRaw, column] = matrix[raw, column];
                }
                tmpRaw++;
            }
            matrix = tmpMatrix;
        }

        public static void MatrixMenu()
        {
            Console.WriteLine("\nРабота с двумерными массивами");
            var matrix = GetMatrixWithRandomElements();
            matrix.SetRandomElements(min: -100, max: 100);
            Console.WriteLine($"Матрица размером {matrix.RawCount}*{matrix.ColumnCount} заполненa случайными числами");
            matrix.PrintMatrix();
            string operations = "Операции с массивом:"
                + "\n\t1 Распечатать матрицу"
                + "\n\t2 Удалить строки с четным индексом"
                + "\n\t3 Создать новую матрицу"
                + "\n\t4 Заполнить матрицу с консоли"
                + "\n\t5 Повтор меню";
            Console.WriteLine(operations);
            int number = -1;
            while (number != 0)
            {
                number = LabMethods.GetInt("Введите номер операции. Для выхода введите 0, "
                    + "для повтора меню 5", min: -1, max: 10);
                switch (number)
                {
                    case 0: break;
                    case 1: matrix.PrintMatrix(); break;
                    case 2:
                        matrix.RemoveEvenRaws();
                        matrix.PrintMatrix();
                        break;
                    case 3:
                        matrix = GetMatrixWithRandomElements();
                        matrix.PrintMatrix();
                        break;
                    case 4:
                        matrix.SetElements();
                        matrix.PrintMatrix();
                        break;
                    case 5: Console.WriteLine(operations); break;
                }
            }
        }

        public void SetElements()
        {
            for (int raw = 0; raw < RawCount; raw++)
            {
                Console.WriteLine($"Строка №{raw + 1}");
                for (int column = 0; column < ColumnCount; column++)
                {
                    matrix[raw, column] = LabMethods.GetInt(
                        $"Введите целочисленное значение элемента №{column + 1}");
                }
            }
        }

        public  static LabIntMatrix GetMatrixWithRandomElements()
        {
            int raws = LabMethods.GetInt(
    "Введите целочисленное количество строк матрицы: ", min: 0);
            int columns = LabMethods.GetInt(
                "Введите целочисленное количество столбцов матрицы: ", min: 0);
            var matrix = new LabIntMatrix(raws, columns);
            matrix.SetRandomElements(min: -100, max: 100);
            return matrix;
        }        
    }
}
