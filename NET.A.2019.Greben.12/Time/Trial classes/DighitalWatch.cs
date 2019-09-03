using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer.Trial_classes
{
    public class DighitalWatch
    {

        
        /// <summary>
        /// Construcor and subscribe
        /// </summary>
        /// <param name="timer"></param>
        public DighitalWatch(Timer timer)
        {
            timer.TimerSignal += DighitalMessage;
        }

        /// <summary>
        /// Execution method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DighitalMessage(object sender, TimeEventArgs e)
        {
            Console.WriteLine("Dighital watch");
            Console.WriteLine("Time = " + e.TimeInSec + "c, begin = " + e.TimeBegin + ", end = " + e.TimeEnd);
        }

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// <param name="timer"></param>
        public void Unregister(Timer timer)
        {
            timer.TimerSignal -= DighitalMessage;
        }
    }
}
