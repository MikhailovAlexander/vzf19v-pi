using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWorks
{
    class LabIntJagArray
    {
        int[][] jagArray;

        public int RawCount
        {
            get { return jagArray.GetLength(0); }
        }

        public int ColumnCount(int rawIndex)
        {
            return jagArray[rawIndex].Length; 
        }

        public LabIntJagArray()
        {
            jagArray = new int[1][];
            jagArray[0] = new int[1];
        }

        public LabIntJagArray(int rawCount, int[] columnsCount)
        {
            if (columnsCount.Length != rawCount)
                throw new Exception(
                    "Ошибка! Количество строк не совпадает с количеством указанных размеров");
            jagArray = new int[rawCount][];
            for(int i = 0; i < rawCount; i++)
            {
                jagArray[i] = new int[columnsCount[i]];
            }
        }

        public void SetRandomElements(int min = int.MinValue,
            int max = int.MaxValue)
        {
            if (max < min) throw new Exception(
                "Максимальное значение элемента не может быть меньше минимального");
            Random random = new Random();
            for (int i = 0; i < RawCount; i++)
            {
                for (int j = 0; j < ColumnCount(i); j++)
                {
                    jagArray[i][j] = random.Next(min, max);
                }
            }
        }

        public void Print()
        {
            if (RawCount == 0) Console.WriteLine("Рваный массив не имеет строк");
            for (int i = 0; i < RawCount; i++)
            {
                if (ColumnCount(i) == 0) Console.Write(
                    $"Строка {i} не имеет элементов");
                for (int j = 0; j < ColumnCount(i); j++)
                {
                    Console.Write($"[{jagArray[i][j],4}] ");
                }
                Console.WriteLine("");
            }
        }

        public void AppEndRaw(int newRawLength)
        {
            if (newRawLength < 0) throw new Exception(
                 "Длина строки не может быть отрицательной");
            int[][] tmpArray = new int[RawCount + 1][];
            for(int i = 0; i < RawCount; i++)
            {
                tmpArray[i] = new int[ColumnCount(i)];
                for(int j = 0; j < ColumnCount(i); j++)
                {
                    tmpArray[i][j] = jagArray[i][j];
                }
                tmpArray[RawCount] = new int[newRawLength];
            }
            jagArray = tmpArray;
        }

        public void SetRandomElementsToRaw(int rawIndex, int min = int.MinValue,
            int max = int.MaxValue)
        {
            if (max < min) throw new Exception(
                "Максимальное значение элемента не может быть меньше минимального");
            if (rawIndex >= RawCount) throw new Exception(
                 $"Массив длиной {RawCount} не имеет строки с индексом {rawIndex}");
            Random random = new Random();
            for (int i = 0; i < ColumnCount(rawIndex); i++)
            {
                jagArray[rawIndex][i] = random.Next(min, max);
            }
        }

        public void AppEndRandomElementToRaws(int min = int.MinValue,
            int max = int.MaxValue)
        {
            if (max < min) throw new Exception(
                "Максимальное значение элемента не может быть меньше минимального");
            int[][] tmpArray = new int[RawCount][];
            Random random = new Random();
            for (int i = 0; i < RawCount; i++)
            {
                tmpArray[i] = new int[ColumnCount(i) + 1];
                for (int j = 0; j < ColumnCount(i); j++)
                {
                    tmpArray[i][j] = jagArray[i][j];
                }
                tmpArray[i][ColumnCount(i)] = random.Next(min, max);
            }
            jagArray = tmpArray;
        }

        public void RemoveRawsWithEvenNumbers()
        {
            int newRawCount = RawCount / 2 + 1 * (RawCount % 2);
            int[][] newJajArray = new int[newRawCount][];
            int newIndex = 0;
            for(int i = 0; i < RawCount; i++)
            {
                if (i % 2 == 0) newJajArray[newIndex++] = jagArray[i];
            }
            jagArray = newJajArray;
        }

        public int RemoveRawsWithTwoZero()
        {
            int countRawsWithZero = 0;
            bool[] rawsToRemove = new bool[RawCount];
            int zeroCounter = 0;
            for(int i = 0; i < RawCount; i++)
            {
                zeroCounter = 0;
                foreach (int element in jagArray[i])
                    if (element == 0) zeroCounter++;
                if(zeroCounter > 1)
                {
                    countRawsWithZero++;
                    rawsToRemove[i] = true;
                }
            }
            int[][] tmpJagArray = new int[RawCount - countRawsWithZero][];
            int newRawIndex = 0;
            for (int i = 0; i < RawCount; i++)
            {
                if (!rawsToRemove[i])
                    tmpJagArray[newRawIndex++] = jagArray[i];
            }
            jagArray = tmpJagArray;
            return countRawsWithZero;
        }

        public static void JagArrayMenu()
        {
            Console.WriteLine("\nРабота с рваными массивами");
            var jagArr = GetJagArrayWithRandomColumns();
            jagArr.Print();
            string operations = "Операции с рваными массивами:"
                + "\n\t1 Распечатать"
                + "\n\t2 Удалить строки с четным номером"
                + "\n\t3 Создать рваный массив со строками заданной длины"
                + "\n\t4 Добавить строку случайной длины в конец массива"
                + "\n\t5 Добавить строку заданной длины в конец массива"
                + "\n\t6 Добавить в конец каждой строки случайный элемент"
                + "\n\t7 Удалить все строки содержащие не менее двух нулей"
                + "\n\t8 Повторить меню";
            Console.WriteLine(operations);
            int number = -1;
            while (number != 0)
            {
                number = LabMethods.GetInt("Введите номер операции. Для выхода введите 0, "
                    + "для повтора меню 8", min: -1, max: 10);
                switch (number)
                {
                    case 0: break;
                    case 1: jagArr.Print(); break;
                    case 2:
                        if (jagArr.RawCount <= 1) Console.WriteLine(
                            "Массив не имеет строк с четным номером");
                        else jagArr.RemoveRawsWithEvenNumbers();
                        jagArr.Print();
                        break;
                    case 3:
                        jagArr = GetJagArrayWithRandomElements();
                        jagArr.Print();
                        break;
                    case 4:
                        AppEndRandomLengthRaw(ref jagArr);
                        jagArr.SetRandomElementsToRaw(jagArr.RawCount - 1,
                            min: -100, max: 100);
                        jagArr.Print();
                        break;
                    case 5:
                        AppEndRaw(ref jagArr);
                        jagArr.SetRandomElementsToRaw(jagArr.RawCount - 1,
                            min: -100, max: 100);
                        jagArr.Print();
                        break;
                    case 6:
                        jagArr.AppEndRandomElementToRaws(min: -100, max: 100);
                        jagArr.Print();
                        break;
                    case 7:
                        int countRemovedRaws = jagArr.RemoveRawsWithTwoZero();
                        jagArr.Print();
                        Console.WriteLine
                            ($"\nУдалено {countRemovedRaws} строк, содержащих не менее двух нулей");
                        break;
                    case 8: Console.WriteLine(operations); break;
                }
            }
        }

        public static void AppEndRaw(ref LabIntJagArray jagArr)
        {
            int length = LabMethods.GetInt(
                "Введите целочисленную длину строки: ", min: 0);
            jagArr.AppEndRaw(length);
        }

        public static void AppEndRandomLengthRaw(ref LabIntJagArray jagArr)
        {
            int maxLength = LabMethods.GetInt(
                "Введите целочисленную максимальную длину строки: ", min: 0);
            Random rnd = new Random();
            jagArr.AppEndRaw(rnd.Next(0, maxLength));            
        }

        public static LabIntJagArray GetJagArrayWithRandomElements()
        {
            int raws = LabMethods.GetInt(
    "Введите целочисленное количество строк рваного массива: ", min: 0);
            int[] columnsCount = new int[raws];
            for(int i = 0; i < raws; i++)
            {
                columnsCount[i] = LabMethods.GetInt(
                    $"Введите целочисленное количество столбцов {i} строки массива: ", 
                    min: 0);
            }
            var jagArr = new LabIntJagArray(raws, columnsCount);
            jagArr.SetRandomElements(min: -5, max: 5);
            return jagArr;
        }

        public static LabIntJagArray GetJagArrayWithRandomColumns()
        {
            Console.WriteLine("Создание рваного массива со строками случайной длины");
            int raws = LabMethods.GetInt(
                "Введите целочисленное количество строк рваного массива: ", min: 0);
            int maxLength = LabMethods.GetInt(
                "Введите целочисленную максимальную длину строк: ", min: 0);
            int[] columnsCount = new int[raws];
            Random rnd = new Random();
            for (int i = 0; i < raws; i++)
            {
                columnsCount[i] = rnd.Next(maxLength + 1);
            }
            var jagArr = new LabIntJagArray(raws, columnsCount);
            jagArr.SetRandomElements(min: -5, max: 5);
            return jagArr;
        }
    }
}
