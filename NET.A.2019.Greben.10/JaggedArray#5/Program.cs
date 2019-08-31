using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BubbleSortDelegate;
using NAT.A._2019.Greben._08;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[][] arr = new int[4][];
            {
                arr[0] = new int[] { 1, 4, 2, 2 };
                arr[1] = new int[] { 2, 1, 7 };
                arr[2] = new int[] { 4, 1, 6, 1, 4, 1 };
                arr[3] = new int[] { 4, 0, 6, 1, 4, 1 };
            }

            JaggedArray array = new JaggedArray(arr);
            array.ShowJaggedArray();
            array.CompareArray(CompareMaxSum);
            array.Sort();
            array.ShowJaggedArray();

            array.CompareArray(CompareMin);
            array.Sort();
            array.ShowJaggedArray();
        }

        public static int CompareMax(int[] arr1, int[] arr2)
        {
            if (arr1.Max() < arr2.Max())
            {
                return 1;
            }
            else if (arr1.Max() > arr2.Max())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static int CompareMaxSum(int[] arr1, int[] arr2)
        {
            if (arr1.Sum() < arr2.Sum())
            {
                return 1;
            }
            else if (arr1.Sum() > arr2.Sum())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public static int CompareMin(int[] arr1, int[] arr2)
        {
            if (arr1.Min() < arr2.Min())
            {
                return 1;
            }
            else if (arr1.Min() > arr2.Min())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
