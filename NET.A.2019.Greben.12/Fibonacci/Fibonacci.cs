using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_6
{
    public class Fibonacci
    {
        /// <summary>
        /// List of numbers
        /// </summary>
        private List<int> list;

        /// <summary>
        /// Variable
        /// </summary>
        private int firstNumber = 0;

        /// <summary>
        /// Variable
        /// </summary>
        private int secondNumber = 1;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Fibonacci()
        {
            list = new List<int>();
            AddFirstAndSecondNumbers();
        }

        /// <summary>
        /// Fibonacci numbers
        /// </summary>
        public void GenerationNumbers()
        {
            double check = 0;
            while (true)
            {
                check = (double)firstNumber + (double)secondNumber;
                if (check > int.MaxValue)
                {
                    break;
                }

                list.Add((int)check);
                firstNumber = secondNumber;
                secondNumber = (int)check;
            }
        }

        /// <summary>
        /// Get integer array
        /// </summary>
        /// <returns>Array integer</returns>
        public int[] GetArray()
        {
            return list.ToArray();
        }

        /// <summary>
        /// Show in console list
        /// </summary>
        public void ShowList()
        {
            foreach (var i in list)
            {
                Console.WriteLine(i + "  ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Add first two numbers
        /// </summary>
        private void AddFirstAndSecondNumbers()
        {
            list.Add(firstNumber);
            list.Add(secondNumber);
        }
    }
}
