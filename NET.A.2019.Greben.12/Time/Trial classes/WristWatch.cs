using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Trial_classes
{
    public class WristWatch
    {
        /// <summary>
        /// Construcor and subscribe
        /// </summary>
        /// <param name="timer"></param>
        public WristWatch(Timer timer)
        {
            timer.TimerSignal += WristMessage;
        }

        /// <summary>
        /// Execution method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void WristMessage(object sender, TimeEventArgs e)
        {
            Console.WriteLine("Wrist Watch");
            Console.WriteLine("Time = " + e.TimeInSec + "c, begin = " + e.TimeBegin + ", end = " + e.TimeEnd);
        }

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// <param name="timer"></param>
        public void Unregister(Timer timer)
        {
            timer.TimerSignal -= WristMessage;
        }
    }
}
