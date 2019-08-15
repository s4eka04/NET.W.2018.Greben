using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertDouble
{
    public static class ChangeADouble
    {
        public static string ToBinary(this double numberSource)
        {
            double maxE = Math.Pow(2, 11) - 1;
            double maxM = Math.Pow(2, 52) - 1;
            double S = 0;
            double E = 0;
            double M = 0;

            double endWindow = 1;
            double beginWindow = 0;
            if (numberSource.ToString()[0] == '-' ||  numberSource.ToString() == double.NaN.ToString())
            {
                S = 1;
                numberSource = Math.Abs(numberSource);
            }

            if (numberSource == double.PositiveInfinity)
            {
                E = maxE;
                M = 0;
            }
            else if (numberSource.ToString() == double.NaN.ToString())
            {
                E = maxE;
                M = Math.Pow(2, 51);
            }
            else

            {
                if (numberSource >= double.MaxValue / 2)
                {
                    endWindow = double.MaxValue;
                    beginWindow = endWindow / 2;
                }
                else if (endWindow < numberSource)
                {
                    while (endWindow < numberSource)
                    {
                        endWindow *= 2;
                    }

                    beginWindow = endWindow / 2;


                }

                E = Math.Log(beginWindow, 2) + 1023;
                if (E < 0)
                    E = 0;
                M = Math.Ceiling(Math.Pow(2, 52) * (numberSource - beginWindow) / (endWindow - beginWindow));
                if (M == Math.Pow(2, 52))
                    M--;
            }





            string returnString = S.ToString() + ReturnCorrectString(E, 11) + ReturnCorrectString(M, 52);
            Console.WriteLine(returnString);

            return returnString;
        }

        static string ReturnCorrectString(double number, int part)
        {
            string str = Convert.ToString((long)number, 2);
            if (str.Length < part)
            {
                str = new string('0', part - str.Length) + str;
            }

            return str;
        }


    }
}
