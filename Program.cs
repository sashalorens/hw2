using System.Diagnostics;
using System.Xml.Linq;

namespace hw2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var quickSortArray1 = initArray(5000);
            var oddEvenSortArray1 = initArray(5000);
            var insertionSortArray1 = initArray(5000);

            var quickSortArray2 = initArray(25000);
            var oddEvenSortArray2 = initArray(25000);
            var insertionSortArray2 = initArray(25000);

            var quickSortArray3 = initArray(50000);
            var oddEvenSortArray3 = initArray(50000);
            var insertionSortArray3 = initArray(50000);

            var stopwatch = new Stopwatch();
            Console.WriteLine("5000 elements:");

            stopwatch.Start();
            QuickSort(quickSortArray1, 0, quickSortArray1.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("QuickSort: " + stopwatch.ElapsedMilliseconds.ToString());
            stopwatch.Reset();
            stopwatch.Start();
            OddEvenSort(oddEvenSortArray1);
            stopwatch.Stop();
            Console.WriteLine("OddEvenSort: " + stopwatch.ElapsedMilliseconds.ToString());
            stopwatch.Reset();
            stopwatch.Start();
            InsertionSort(insertionSortArray1);
            Console.WriteLine("InsertionSort: " + stopwatch.ElapsedMilliseconds.ToString());

            Console.WriteLine("\n25000 elements:");
            stopwatch.Start();
            QuickSort(quickSortArray2, 0, quickSortArray2.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("QuickSort: " + stopwatch.ElapsedMilliseconds.ToString());
            stopwatch.Reset();
            stopwatch.Start();
            OddEvenSort(oddEvenSortArray2);
            stopwatch.Stop();
            Console.WriteLine("OddEvenSort: " + stopwatch.ElapsedMilliseconds.ToString());
            stopwatch.Reset();
            stopwatch.Start();
            InsertionSort(insertionSortArray2);
            Console.WriteLine("InsertionSort: " + stopwatch.ElapsedMilliseconds.ToString());

            Console.WriteLine("\n50000 elements:");
            stopwatch.Start();
            QuickSort(quickSortArray3, 0, quickSortArray3.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("QuickSort: " + stopwatch.ElapsedMilliseconds.ToString());
            stopwatch.Reset();
            stopwatch.Start();
            OddEvenSort(oddEvenSortArray3);
            stopwatch.Stop();
            Console.WriteLine("OddEvenSort: " + stopwatch.ElapsedMilliseconds.ToString());
            stopwatch.Reset();
            stopwatch.Start();
            InsertionSort(insertionSortArray3);
            Console.WriteLine("InsertionSort: " + stopwatch.ElapsedMilliseconds.ToString());
        }

        static void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            int pivot = array[leftIndex];

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSort(array, leftIndex, j);
            if (i < rightIndex)
                QuickSort(array, i, rightIndex);
            return;
        }

        static void OddEvenSort(int[] array)
        {
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;
                for (int i = 1; i < array.Length - 1; i += 2)
                {
                    if (array[i] <= array[i + 1]) continue;
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    isSorted = false;
                }
                for (int i = 0; i < array.Length - 1; i += 2)
                {
                    if (array[i] <= array[i + 1]) continue;
                    int temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    isSorted = false;
                }
            }
        }

        static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int item = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > item)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = item;
            }
        }

        static int[] initArray(int length)
        {
            int[] array = new int[length];
            var random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int current = random.Next();
                array[i] = current;
            }

            return array;
        }
    }
}
