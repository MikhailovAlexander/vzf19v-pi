using System;

namespace LabWorks
{
    class LabIntArray
    {
        int[] array;
        public int Length
        {
            get { return array.Length; }
        }

        public LabIntArray(int n)
        {
            if (n <= 0) throw new Exception(
                "Значение длины массива не может быть меньше 1");            
            array = new int[n];            
        }

        public void SetRandomElements(int min = int.MinValue,
            int max = int.MaxValue)
        {
            if (max < min) throw new Exception(
                "Максимальное значение элемента не может быть меньше минимального");
            Random random = new Random();
            for (int i = 0; i < Length; i++)
            {
                array[i] = random.Next(min, max);
            }
        }

        public void SetElementsInRange()
        {
            for (int i = 0; i < Length; i++)
            {
                array[i] = i;
            }
        }

        public void PrintArray()
        {
            if (Length == 0) Console.WriteLine("Массив не имеет элементов");
            foreach (int x in array) Console.WriteLine($"[{x,4}]");
        }

        public void PrintArrayInLine()
        {
            if (Length == 0) Console.WriteLine("Массив не имеет элементов");
            foreach (int x in array) Console.Write($"[{x,4}] ");
            Console.WriteLine("");
        }

        public void RemoveElementsWithEvenIndex()
        {
            int[] newArray = new int[Length / 2];
            int newIndex = 0;
            for(int i = 0; i < Length; i++)
            {
                if(i % 2 != 0)
                {
                    newArray[newIndex++] = array[i];
                }
            }
            array = newArray;
        }
        /// <summary>
        /// Добавление элементов в массив начиная с индекса К
        /// </summary>
        /// <param name="elementsForIns">Элементы для вставки</param>
        /// <param name="k">Индекс от 0 до длины массива, 
        /// начиная с которго вставляются элементы</param>
        public void InsertElementsBegFromK(int[] elementsForIns, int k)
        {
            if (k < 0 || k > Length) throw new Exception(
                $"В массиве длиной {Length} нет элемента с индексом {k}");
            int[] newArray = new int[Length + elementsForIns.Length];
            for (int i = 0; i < newArray.Length; i++)
            {
                if (i < k)
                {
                    newArray[i] = array[i];
                }
                else if(i >= k && i < k + elementsForIns.Length)
                {
                    newArray[i] = elementsForIns[i - k];
                }
                else if(i >= k + elementsForIns.Length)
                {
                    newArray[i] = array[i - elementsForIns.Length];
                }
            }
            array = newArray;
        }

        public void Reverse()
        {
            for (int i = 0; i < Length/2; i++)
            {
                int tmp = array[i];
                array[i] = array[(Length-1) - i];
                array[(Length - 1) - i] = tmp;
            }
        }
        /// <summary>
        /// Поиск первого индекса элемента с заданным значением
        /// </summary>
        /// <param name="value">Значение для поиска</param>
        /// <returns>First index or -1 if index is not found</returns>
        public int FindFirstIndexByValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if(array[i] == value) return i;
            }
            return -1;
        }
        /// <summary>
        /// Сортировка массива методом простой вставки
        /// </summary>
        public void InsertionSort()
        {
            for (int i = 1; i < Length; i++)
            {
                int j = i;
                while(j > 0 && array[j] < array[j -1])
                {
                    LabMethods.Swap<int>(ref array[j], ref array[j - 1]);
                    j--;
                }
            }
        }
    }
}
