using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSortDelegate
{
    public class JaggedArray:IComparer<int[]>
    {
        /// <summary>
        /// Jagged array
        /// </summary>
        private int[][] jaggedarray;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="arr"></param>
        public JaggedArray(int[][] arr)
        {
            if (arr == null)
            {
                throw new Exception(" array cann't be empty");
            }

            jaggedarray = arr;
        }

        /// <summary>
        /// Delegate
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public delegate int ComparerDelecate(int[] arr1, int[] arr2);

        /// <summary>
        /// Variable delegate
        /// </summary>
        private ComparerDelecate delComp;

        /// <summary>
        /// Method taking delegate
        /// </summary>
        /// <param name="del"></param>
        public void CompareArray(ComparerDelecate del)
        {
            if (del != null)
            {
                delComp = del;
            }
            else
            {
                throw new Exception(" Delegate cann't be null");
            }
        }

        /// <summary>
        /// Realization interface
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(int[] x, int[] y)
        {
            return delComp(x, y);
        }

        /// <summary>
        /// Sort method
        /// </summary>
        public void Sort()
        {
           for (int i = 0; i < jaggedarray.Length; i++)
           {
                for (int j = 0; j < jaggedarray.Length - 1 - i; j++)
                {
                    if (delComp(jaggedarray[j], jaggedarray[j+1]) > 0)
                    {
                        Swap(ref jaggedarray[j], ref jaggedarray[j+1]);
                    }
                }
           }
        }

        /// <summary>
        /// Output array
        /// </summary>
        public void ShowJaggedArray()
        {
            for (int i = 0; i < jaggedarray.Length; i++)
            {
                for (int j = 0; j < jaggedarray[i].Length; j++)
                {
                    Console.Write(jaggedarray[i][j] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Swap arrays
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        private void Swap(ref int[] a1, ref int[] a2)
        {
            int[] tempA = a1;
            a1 = a2;
            a2 = tempA;
        }
    }
}
