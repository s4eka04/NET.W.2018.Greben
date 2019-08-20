using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class JaggedArray
    {

        private int[][] jaggedarray;

        public JaggedArray(int[][] arr)
        {
            if (arr == null)
                throw new Exception(" array cann't be empty");
            jaggedarray = arr;
        }
        public  void BubbleSortByIncreaseSum()
        {

            for (int i = 0; i < jaggedarray.Length; i++)
            {
                for (int j = 0; j < jaggedarray.Length - 1 - i; j++)
                {

                    //It is necessary so that the sum of the elements in the row does not exceed the value of int

                    double sumJLine = 0;
                    double sumJ_1Line = 0;

                    for(int k = 0; k < jaggedarray[j].Length; k ++)
                    {
                        sumJLine += jaggedarray[j][k];
                    }
                    for (int k = 0; k < jaggedarray[j+1].Length; k++)
                    {
                        sumJ_1Line += jaggedarray[j+1][k];
                    }
                    if ( sumJLine > sumJ_1Line)
                    {
                        int[] temp = jaggedarray[j];
                        jaggedarray[j] = jaggedarray[j + 1];
                        jaggedarray[j + 1] = temp;
                    }
                }
            }
        }


        public  void BubbleSortByIncreaseMaxElement()
        {

            for (int i = 0; i < jaggedarray.Length; i++)
            {
                for (int j = 0; j < jaggedarray.Length - 1 - i; j++)
                {
                    if (jaggedarray[j].Max() > jaggedarray[j + 1].Max())
                    {
                        int[] temp = jaggedarray[j];
                        jaggedarray[j] = jaggedarray[j + 1];
                        jaggedarray[j + 1] = temp;
                    }
                }
            }
        }

        public  void BubbleSortByDecreaseMaxElement()
        {

            for (int i = 0; i < jaggedarray.Length; i++)
            {
                for (int j = 0; j < jaggedarray.Length - 1 - i; j++)
                {
                    if (jaggedarray[j].Max() < jaggedarray[j + 1].Max())
                    {
                        int[] temp = jaggedarray[j];
                        jaggedarray[j] = jaggedarray[j + 1];
                        jaggedarray[j + 1] = temp;
                    }
                }
            }
        }

        public  void BubbleSortByIncreaseMinElement()
        {

            for (int i = 0; i < jaggedarray.Length; i++)
            {
                for (int j = 0; j < jaggedarray.Length - 1 - i; j++)
                {
                    if (jaggedarray[j].Min() > jaggedarray[j + 1].Min())
                    {
                        int[] temp = jaggedarray[j];
                        jaggedarray[j] = jaggedarray[j + 1];
                        jaggedarray[j + 1] = temp;
                    }
                }
            }
        }

        public  void BubbleSortByDecreaseMinElement()
        {

            for (int i = 0; i < jaggedarray.Length; i++)
            {
                for (int j = 0; j < jaggedarray.Length - 1 - i; j++)
                {
                    if (jaggedarray[j].Min() < jaggedarray[j + 1].Min())
                    {
                        int[] temp = jaggedarray[j];
                        jaggedarray[j] = jaggedarray[j + 1];
                        jaggedarray[j + 1] = temp;
                    }
                }
            }
        }
        public  void BubbleSortByDecreaseSum()
        {

            for (int i = 0; i < jaggedarray.Length; i++)
            {
                for (int j = 0; j < jaggedarray.Length - 1 - i; j++)
                {

                    //It is necessary so that the sum of the elements in the row does not exceed the value of int

                    double sumJLine = 0;
                    double sumJ_1Line = 0;

                    for (int k = 0; k < jaggedarray[j].Length; k++)
                    {
                        sumJLine += jaggedarray[j][k];
                    }
                    for (int k = 0; k < jaggedarray[j + 1].Length; k++)
                    {
                        sumJ_1Line += jaggedarray[j + 1][k];
                    }
                    if (sumJLine > sumJ_1Line)
                    { 
                        int[] temp = jaggedarray[j];
                        jaggedarray[j] = jaggedarray[j + 1];
                        jaggedarray[j + 1] = temp;
                    }
                }
            }
        }

        public  void ShowJaggedArray()
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

        public int[][] GetJaggedArray()
        {
            return jaggedarray;
        }

        public bool EqualsArray(int[][] arr)
        {
            if (arr == null)
                return false;
            if (this.jaggedarray.Length != arr.Length)
                return false;
            for(int i = 0; i < arr.Length; i++)
            {
                if (this.jaggedarray[i].Length != arr[i].Length)
                    return false;
            }

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] != this.jaggedarray[i][j])
                        return false;
                }
            }
            return true;
        }
    }
}

