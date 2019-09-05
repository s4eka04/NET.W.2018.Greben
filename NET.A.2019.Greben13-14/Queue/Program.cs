using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Greben13_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(5);
            queue.Enqueue(4);
            queue.Enqueue(6);
            queue.Dequeue();
            foreach(var q in queue)
            {
                Console.WriteLine(q.ToString());
            }
        }
    }
}
