using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySort
{
    public static class Sort
    {

        //**********************FAST SORT****************************
        public static void FastSort(int[] array, int left, int right)
        {

            if (left < right)
            {
                //Choose a random number 
                Random random = new Random();
                int randomNumber = random.Next(left, right);

                //Put the element under the index random in place and divide the array into two parts
                int pointerSortedItem = SplitIntoTwo(array, left, right, randomNumber);

                //repeat with the left part of array
                FastSort(array, left, pointerSortedItem - 1);
                // or the right part
                FastSort(array, pointerSortedItem + 1, right);

            }

        }

        private static void Swap(int[] arr, int firstPointer, int secondPointer)
        {
            int tempInteger = arr[firstPointer];
            arr[firstPointer] = arr[secondPointer];
            arr[secondPointer] = tempInteger;
        }

        private static int SplitIntoTwo(int[] array, int left, int right, int randomNumber)
        {

            int pointerSortedItem = left;
            int pointerValue = array[randomNumber];

            Swap(array, randomNumber, right);
            for (int i = left; i < right; i++)
            {
                if (array[i] < pointerValue)
                {
                    if (i != pointerSortedItem)
                        Swap(array, pointerSortedItem, i);
                    pointerSortedItem += 1;
                }
            }
            Swap(array, pointerSortedItem, right);

            return pointerSortedItem;
        }

        //********************************** MERGE SORT *******************************
        public static void MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return;
            }

            int leftSize = array.Length / 2;
            int rightSize = array.Length - leftSize;
            int[] left = new int[leftSize];
            int[] right = new int[rightSize];

            Array.Copy(array, 0, left, 0, leftSize);
            Array.Copy(array, leftSize, right, 0, rightSize);

            MergeSort(left);
            MergeSort(right);

            Merge(array, left, right);


        }

        private static void Merge(int[] array, int[] left, int[] right)
        {
            int leftPointer = 0;
            int rightPointer = 0;
            int lengthTheArr = right.Length + left.Length;

            for(int i = 0; i < lengthTheArr - 1; i ++)
            {
                if (left.Length == leftPointer)
                {
                    array[i] = right[rightPointer++];
                }else if(right.Length == rightPointer)
                {
                    array[i] = left[leftPointer++];
                }else if (left[leftPointer] >= right[rightPointer])
                {
                    array[i] = right[rightPointer++];
                }
                else if (left[leftPointer] < right[rightPointer])
                {
                    array[i] = left[leftPointer++];
                }
                
            }

            if(leftPointer == left.Length)
            {
                array[array.Length - 1] = right[rightPointer];
            }

            if(rightPointer == right.Length)
            {
                array[array.Length - 1] = left[leftPointer];
            }
        }

    }
}
