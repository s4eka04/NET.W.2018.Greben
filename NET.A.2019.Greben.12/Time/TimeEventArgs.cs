using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public class TimeEventArgs : EventArgs
    {
        private readonly int timeInSeconds;
        private readonly int timeBegin;
        private readonly int timeEnd;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="timeInSeconds"></param>
        /// <param name="timeBegin"></param>
        public TimeEventArgs(int timeInSeconds, int timeBegin)
        {
            this.timeInSeconds = timeInSeconds;
            this.timeBegin = timeBegin;
            this.timeEnd = timeInSeconds + timeBegin;
        }

        /// <summary>
        /// Prop
        /// </summary>
        public int TimeInSec
        {
            get
            {
                return timeInSeconds;
            }
        }

        /// <summary>
        /// Prop
        /// </summary>
        public int TimeBegin
        {
            get
            {
                return timeBegin;
            }
        }

        /// <summary>
        /// Prop
        /// </summary>
        public int TimeEnd
        {
            get
            {
                return timeEnd;
            }
        }
    }
}
