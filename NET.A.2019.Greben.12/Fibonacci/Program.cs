using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fibonacci = new Fibonacci();
            fibonacci.GenerationNumbers();
            fibonacci.ShowList();
            int[] array = fibonacci.GetArray();
            Console.WriteLine(array.Length);
        }
    }
}
