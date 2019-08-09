using MySort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MySort;

namespace TestSortingMothods
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeArray = 20;
            int maxValue = 100;
            int[] arrayIntForFastSort = new int[sizeArray];
            int[] arrayIntForMergeSort = new int[sizeArray];
            Random rand = new Random();
            
            // Fill the array of random  numbers for FastSort
            for(int i = 0; i <arrayIntForFastSort.Length; i++)
            {
                arrayIntForFastSort[i] = rand.Next(maxValue);
            }

            //Fill the array of random numbers for MergeSort 
            for (int i = 0; i < arrayIntForMergeSort.Length; i++)
            {
                arrayIntForMergeSort[i] = rand.Next(maxValue);
            }

            // Call FastSort method
            Console.WriteLine("Before FastSort: ");
            ConsoleArray(arrayIntForFastSort);
            Sort.FastSort(arrayIntForFastSort, 0, arrayIntForFastSort.Length - 1);
            Console.WriteLine("After FastSort: ");
            ConsoleArray(arrayIntForFastSort);

            Console.WriteLine(new String('*', 70));


            //Call MergeSort metod
            Console.WriteLine("Before MergeSort: ");
            ConsoleArray(arrayIntForMergeSort);
            Sort.MergeSort(arrayIntForMergeSort);
            Console.WriteLine("After MergeSort: ");
            ConsoleArray(arrayIntForMergeSort);
            
        }

        private static void ConsoleArray(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++ )
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write('\n');
        }

    }
}
