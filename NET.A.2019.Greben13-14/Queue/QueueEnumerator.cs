using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Greben13_14
{
    public class QueueEnumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// Field needed for Reset();
        /// </summary>
        private readonly Queue<T> first = null;

        /// <summary>
        /// Field Position
        /// </summary>
        private  Queue<T> referenceForEnumerator = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="first"></param>
        public QueueEnumerator(Queue<T> first)
        {
            this.first = first;
            referenceForEnumerator = new Queue<T>(first.Value);
        }

        /// <summary>
        /// Current item
        /// </summary>
        /// <return>Item type T</return>
        public T Current
        {
            get
            {
                if (first.Reference == null)
                {
                    throw new Exception("Reference points to Null");
                }

                return referenceForEnumerator.Value;
            }
        }

        /// <summary>
        /// If something goes wrong
        /// </summary>
        object IEnumerator.Current => throw new NotImplementedException();

        /// <summary>
        /// Move Next item
        /// </summary>
        /// <returns>false if end list</returns>
        public bool MoveNext()
        {

            if (referenceForEnumerator.Reference != null)
            {
                referenceForEnumerator = referenceForEnumerator.Reference;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Reset
        /// </summary>
        public void Reset()
        {
            referenceForEnumerator = first;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() { }
    }
}
