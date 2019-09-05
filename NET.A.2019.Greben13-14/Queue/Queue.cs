using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Greben13_14
{
    public class Queue<T>
    {
        /// <summary>
        /// Value in queue
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Reference to next value
        /// </summary>
        public Queue<T> Reference { get; private set; }


        /// <summary>
        /// Pointer to first
        /// </summary>
        private static Queue<T> first = null;

        /// <summary>
        /// Pointer to last
        /// </summary>
        private static Queue<T> end = null;

        /// <summary>
        /// Construcor
        /// </summary>
        public Queue()
        {

        }

        /// <summary>
        /// Construcor
        /// </summary>
        /// <param name="value"></param>
        public Queue(T value)
        {
            Value = value;
            Reference = first;
        }

        /// <summary>
        /// Adding element to queue
        /// </summary>
        /// <param name="queue"></param>
        public void Enqueue(T queue)
        {
            if (first != null)
            {
                first = new Queue<T>(queue);
            }
            else
            {
                first = new Queue<T>(queue);
                end = first;
            }

           


        }

        /// <summary>
        /// Enumertator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(first);
        }

        /// <summary>
        /// Get first item
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return first.Value; 
        }

        /// <summary>
        /// Get first item and delete it
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            Queue<T> temp = first;
            first = temp.Reference;

            return temp.Value;
        }

    }
}
