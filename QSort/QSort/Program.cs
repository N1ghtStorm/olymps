using System;
using System.Linq;

namespace QSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var unsortedArray = new int[] { 5, 15, 2, 8, 7, 3, 1};
            unsortedArray.ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("==================================================");
            unsortedArray.QSortIntArray(0, unsortedArray.Length - 1);
            unsortedArray.ToList().ForEach(x => Console.WriteLine(x));
        }
    }

    public static class SortExtensions
    {
        public static void QSortIntArray(this int[] intArray, int start, int end)
        {
            if (intArray.Length <= 1)
            {
                return;
            }


            if (start < end)
            {
                var q = intArray.Partition(start, end);
                intArray.QSortIntArray(start, q-1);
                intArray.QSortIntArray(q+1, end);
            }
            //var pivotIndex = (intArray.Length / 2) - 1;
            //var pivot = intArray[pivotIndex
            //var lesserArray = new int[pivotIndex];
            //var biggerArray = new int[intArray.Length - pivotIndex];
        }

        public static int Partition(this int[] intArray, int start, int end)
        {
            var last_subarray_element = intArray[end];
            var i = start;

            for (int j = start + 1; j < end; j++) 
            {
                if (intArray[j] <= last_subarray_element)
                {
                    i++;
                    var temp = intArray[i];
                    intArray[i] = intArray[j];
                    intArray[j] = temp;
                }

                var temp_1 = intArray[i];
                intArray[i] = intArray[end];
                intArray[end] = temp_1;
            }

            return i;
        }
    }
}
