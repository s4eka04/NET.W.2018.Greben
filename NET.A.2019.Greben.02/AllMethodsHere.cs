using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.A._2019.Greben._02
{
    public class AllMethodsHere
    {
        //************************************* INSERTNUMBER METHOD *****************************************************
        public static int InsertNumber(int i, int j, int numberSource, int numberIn)
        {
            int result = 0;
            numberIn = numberIn << i;
            int twoPowerJ = Convert.ToInt32(Math.Pow(2, j + 1)) - 1;
            int twoPowerI = Convert.ToInt32(Math.Pow(2, i)) - 1;
            int firstMask = twoPowerJ ^ twoPowerI;
            int firstPreResult = firstMask & numberIn;

            int maxInt = Int32.MaxValue;
            int secondMask = maxInt ^ firstMask;
            int secondPreResult = secondMask & numberSource;

            result = firstPreResult | secondPreResult;
            return result;
        }




        // *************************************FINDNEXTBIGGESRNUMBER****************************************
        public static int FindNextBiggerNumber(int number)
        {
            int time = DateTime.Now.Millisecond;

            if (number < 0)
                return -1;
            int[] arrayNumber = FromTheNumberToArray(number);

            for (int i = 0; i < arrayNumber.Length - 1; i++)
            {
                if (arrayNumber[i] < arrayNumber[i + 1])
                {
                    break;
                }
                if (i == arrayNumber.Length - 2)
                    return -1;
            }

            double muliply = Multiply(arrayNumber);
            number += 9;
            int check = 0;
            int[] tempArray = FromTheNumberToArray(number);
            while ((muliply != Multiply(tempArray)))
            {

                tempArray = FromTheNumberToArray(number);
                number += 9;
                check++;
            }

            int delta = DateTime.Now.Millisecond - time;
            Console.WriteLine("Time Working : " + delta + "ms");
            if (check == 0)
                return number;

            return number - 9;

        }
        //Split number to the array 
        static int[] FromTheNumberToArray(int number)
        {
            int size = 1;
            int tempNumber = number;

            while (tempNumber / 10 != 0)
            {
                tempNumber = tempNumber / 10;
                size++;
            }

            int[] arrayNumber = new int[size];

            for (int i = 0; i < size; i++)
            {
                arrayNumber[i] = number % 10;
                number /= 10;
            }

            Array.Reverse(arrayNumber);

            return arrayNumber;
        }
        // To check I look for the product of numbers in an array
        static double Multiply(int[] arr)
        {
            double multiply = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                    multiply *= 10;
                else
                    multiply *= arr[i];
            }
            return multiply;
        }

        //***************************************FILTERDIGITtMETHOD*************************************
        public static List<int> FilterDigit(int checkNumber, params int[] numbers)
        {
            List<int> listNeededNumber = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int tempNumber = numbers[i];
                int[] arrOurNumber = FromTheNumberToArray(tempNumber);
                for (int j = 0; j < arrOurNumber.Length; j++)
                {
                    if (arrOurNumber[j] == checkNumber)
                    {
                        listNeededNumber.Add(tempNumber);
                        break;
                    }
                }
            }

            return listNeededNumber;
        }

        //************************************FINDNTHROOTMETHOD
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if (degree <= 0)
                throw new ArgumentOutOfRangeException();

            double xk = 0;
            double xk1 = number / 2;
            double tempDegree = degree;
            while (Math.Abs(xk1 - xk) > precision)
            {
                xk = xk1;
                xk1 = (1 / tempDegree) * (((tempDegree - 1) * xk) + (number / Math.Pow(xk, tempDegree - 1)));

            }


            return Math.Round(xk1, 2);
        }
    }
}
