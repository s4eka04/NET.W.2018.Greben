using System;
using NAT.A._2019.Greben._08;

namespace Greben10
{
    public static class Helper
    {
        /// <summary>
        /// Extension method ToString for Book
        /// </summary>
        /// <param name="book"></param>
        /// <param name="stringArray"></param>
        /// <returns>String representation book</returns>
        public static string ToString(this Book book, params string[] stringArray)
        {
            string stringRepresentation = string.Empty;
            string[] checkedstring = new string[] { "I", "A", "N", "H", "Y", "S", "P" };
            if (CheckRepeatOfSymble(stringArray))
            {
                throw new FormatException("Сan be no duplicate formats");
            }

            foreach (var str in stringArray)
            {
                string symbol = null;

                if ((symbol = checkedstring.FindStrOnArray(str)) != null)
                {
                    if (symbol == "I")
                    {
                        stringRepresentation += book.Id.ToString() + ',';
                    }
                    else if (symbol == "A")
                    {
                        stringRepresentation += book.Author + ',';
                    }
                    else if (symbol == "N")
                    {
                        stringRepresentation += book.Name + ',';
                    }
                    else if (symbol == "H")
                    {
                        stringRepresentation += book.PublishingHouse + ',';
                    }
                    else if (symbol == "Y")
                    {
                        stringRepresentation += book.YearPublish.ToString() + ',';
                    }
                    else if (symbol == "S")
                    {
                        stringRepresentation += book.NumberOfPages.ToString() + ',';
                    }
                    else if (symbol == "P")
                    {
                        stringRepresentation += book.Price.ToString() + ',';
                    }
                }
                else
                {
                    throw new FormatException("The " + str + " format string is not supported");
                }
            }

            return stringRepresentation.Remove(stringRepresentation.Length - 1);
        }

        /// <summary>
        /// Search for the desired string format
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="str"></param>
        /// <returns>Needed string</returns>
        private static string FindStrOnArray(this string[] arr, string str)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == str.ToUpper())
                {
                    return str.ToUpper();
                }
            }

            return null;
        }

        /// <summary>
        /// Finds the repetition of rows in an array
        /// </summary>
        /// <param name="arrayString"></param>
        /// <returns>True if found</returns>
        private static bool CheckRepeatOfSymble(string[] arrayString)
        {
            for (int i = 0; i < arrayString.Length; i++)
            {
                for (int j = 0; j < arrayString.Length; j++)
                {
                    if (j != i)
                    {
                        if (arrayString[j] == arrayString[i])
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
