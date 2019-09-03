using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class Binary<T>
    {
       /// <summary>
       /// Array property
       /// </summary>
        public T[] ArrayT { get; private set; }

        /// <summary>
        /// Delegate
        /// </summary>
        Func<T, T, bool> func = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tempArray"></param>
        public Binary(T[] tempArray)
        {
            
            ArrayT = tempArray;
        }

        /// <summary>
        /// Sort Method
        /// </summary>
        /// <param name="sortDelegate"></param>
        public void Sort(Func<T, T, bool> sortDelegate)
        {
            if(sortDelegate == null)
            {
                throw new Exception();
            }
            func = sortDelegate;
            for (int i = 0; i < ArrayT.Length; i++)
            {
                for (int j = 0; j < ArrayT.Length - 1 - i; j++)
                {
                    if (func(ArrayT[j], ArrayT[j+1]))
                    {
                        Swap(ref ArrayT[j], ref ArrayT[j + 1]);
                    }
                }
            }
        }


        /// <summary>
        /// Binary Search goal
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="equally"></param>
        /// <returns>Index goal</returns>
        public int SearchIndex(T goal, Func<T, T, bool> equally)
        {
            if(func == null)
            {
                throw new Exception();
            }
            int indexBegin = 0;
            int check = 0;
            int indexEnd = ArrayT.Length;
            int middle = 0;
            while (!equally(goal,ArrayT[middle]))
            {
                if(check >= Math.Ceiling(Math.Log(ArrayT.Length, 2)))
                {
                    throw new Exception("Value not found" + check);
                }
                middle = (indexBegin + indexEnd) / 2;
                if (func(goal, ArrayT[middle]))
                {
                    indexBegin = middle;
                    check++;
                }
                else
                {
                    indexEnd = middle;
                    check++;
                }
            }

            return middle;
        }

        /// <summary>
        /// Swap elements
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        private void Swap(ref T t1, ref T t2)
        {
            T temp = t1;
            t1 = t2;
            t2 = temp;
        }

        /// <summary>
        /// Show Array
        /// </summary>
        public void Show()
        {
            foreach (var item in ArrayT)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
