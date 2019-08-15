using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find
{
    public static class FindGCM
    {
        public static int ByStein(int lengthArray, int[] arraySourceInt)
        {
            if (lengthArray == arraySourceInt.Length)
            {
                if (lengthArray < 2) // finish the recurcion when length of array will be 1
                {
                    throw new Exception("must be at least two numbers");
                }

                if (CheckNonPositiveNumbers(arraySourceInt))
                    throw new ArgumentOutOfRangeException(" Number can't be nonpositive");
            }
            if (lengthArray < 2) // finish the recurcion when length of array will be 1
            {
                return 1;
            }
            ByStein(--lengthArray, arraySourceInt); // Call recursive method




            if (arraySourceInt[0] == 1)
                return arraySourceInt[0];


            // Start BinaryGCDAlgoritm
            int k = 1;
            while (arraySourceInt[0] != 0)
            {
                if (arraySourceInt[0] % 2 == 0 && arraySourceInt[lengthArray] % 2 == 0)
                {
                    arraySourceInt[0] >>= 1;
                    arraySourceInt[lengthArray] >>= 1;
                    k <<= 1;
                }
                else if (arraySourceInt[0] % 2 == 0 && arraySourceInt[lengthArray] % 2 != 0)
                {
                    arraySourceInt[0] >>= 1;
                }
                else if (arraySourceInt[0] % 2 != 0 && arraySourceInt[lengthArray] % 2 == 0)
                {
                    arraySourceInt[lengthArray] >>= 1;
                }
                else if (arraySourceInt[0] % 2 != 0 && arraySourceInt[lengthArray] % 2 != 0)
                {
                    if (arraySourceInt[0] < arraySourceInt[lengthArray])
                        Swap(ref arraySourceInt[0], ref arraySourceInt[lengthArray]);
                    arraySourceInt[0] = (arraySourceInt[0] - arraySourceInt[lengthArray]) >> 1;
                }
            }
            arraySourceInt[0] = arraySourceInt[lengthArray] * k;
            return arraySourceInt[0];
        }

        public static int ByEuclid(int lengthArray, int[] arraySourceInt)
        {
            if (lengthArray == arraySourceInt.Length)
            {
                if (lengthArray < 2) // finish the recurcion when length of array will be 1
                {
                    throw new Exception("must be at least two numbers");
                }

                if (CheckNonPositiveNumbers(arraySourceInt))
                    throw new ArgumentOutOfRangeException(" Number can't be nonpositive");
            }
            if (lengthArray < 2) // finish the recurcion when length of array will be 1
            {
                return 1;
            }
            ByEuclid(--lengthArray, arraySourceInt); // Call recursive method




            if (arraySourceInt[0] == 1)
                return arraySourceInt[0];

            if (arraySourceInt[0] < arraySourceInt[lengthArray])
            {
                Swap(ref arraySourceInt[0], ref arraySourceInt[lengthArray]);
            }


            // Start Euclidean algorithm
            while (true)
            {


                int r = arraySourceInt[0] % arraySourceInt[lengthArray];
                if (r == 0)
                {
                    arraySourceInt[0] = arraySourceInt[lengthArray];
                    break;
                }
                arraySourceInt[0] = arraySourceInt[lengthArray];
                arraySourceInt[lengthArray] = r;
            }


            return arraySourceInt[0];

        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static bool CheckNonPositiveNumbers(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <= 0)
                    return true;
            }
            return false;
        }
    }
}
