using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPractVar15
{
    class ArraySortMethods
    {
        public static int compareCount;
        public static int moveCount;

        public static void ClearCount()
        {
            compareCount = 0;
            moveCount = 0;
        }

        public static int[] MergeSort(int[] array)
        {
            ClearCount();
            return MergeSort(array, 0, array.Length - 1);
        }

        private static int[] MergeSort(int[] array, int leftBound, int rigthBound)
        {
            if (leftBound < rigthBound)
            {
                int middle = (leftBound + rigthBound) / 2;
                MergeSort(array, leftBound, middle);
                MergeSort(array, middle + 1, rigthBound);
                Merge(array, leftBound, middle, rigthBound);
            }
            return array;
        }

        private static void Merge(int[] array, int leftBound, int middle, int rigthBound)
        {
            int currentLeft = leftBound;
            int currentRight = middle + 1;
            int[] tempArray = new int[rigthBound - leftBound + 1];
            int index = 0;

            while ((currentLeft <= middle) && (currentRight <= rigthBound))
            {
                tempArray[index++] = array[currentLeft] < array[currentRight] ?
                    array[currentLeft++] : array[currentRight++];
                compareCount++;
                moveCount++;
            }

            moveCount += middle - currentLeft + 1;
            if (currentLeft <= middle)
                Array.Copy(array, currentLeft, tempArray, index, middle - currentLeft + 1);

            moveCount += rigthBound - currentRight + 1;
            if (currentRight <= rigthBound)
                Array.Copy(array, currentRight, tempArray, index, rigthBound - currentRight +1);
            moveCount += rigthBound - leftBound + 1;
            Array.Copy(tempArray, 0, array, leftBound, rigthBound - leftBound + 1);
        }

        public static int[] BlockSort(int[] array, int numberOfBlock, bool debug = false)
        {
            ClearCount();
            if (array == null || array.Length < 2)
                return array;
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach(int value in array)
            {
                if (value < min) min = value;
                compareCount++;
                if (value > max) max = value;
                compareCount++;
            }
            int range = max - min;
            if (range == 0) return array;
            if (range + 1 < numberOfBlock) numberOfBlock = range + 1;
            IntList[] blocks = new IntList[numberOfBlock];
            for (int i = 0; i < blocks.Length; i++)
                blocks[i] = new IntList();
            int number;
            for(int i = 0; i < array.Length; i++)
            {
                number = ((array[i] - min) * (numberOfBlock - 1)) / range;
                compareCount += blocks[number].InsertInOrder(array[i]);
                moveCount++;
            }
             return MergeBlocks(blocks, array, debug);
        }

        private static int[] MergeBlocks(IntList[] blocks, int[] array, bool debug = false)
        {
            int index = 0;
            foreach (IntList block in blocks)
            {
                if (debug) Console.Write("\nblock: ");
                while(index < array.Length && !block.IsEmpty)
                {
                    array[index++] = block.Top();
                    moveCount++;
                    if (debug) Console.Write(array[index - 1] + " ");
                }
                if (index >= array.Length && !block.IsEmpty)
                    throw new Exception("Количество элементов в блоках больше чем размер массива");
            }
            if (debug) Console.WriteLine();
            return array;
        }
    }
}
