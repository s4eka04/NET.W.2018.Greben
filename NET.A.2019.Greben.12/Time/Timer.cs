using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public class Timer
    {
        /// <summary>
        /// Event
        /// </summary>
        public event EventHandler<TimeEventArgs> TimerSignal;

        /// <summary>
        /// Call event
        /// </summary>
        /// <param name="e"></param>
        private  void OnTimer(TimeEventArgs e)
        {
            if(TimerSignal != null)
            {
                TimerSignal(this, e);
            }
        }

        /// <summary>
        /// Additional information and call
        /// </summary>
        /// <param name="time"></param>
        /// <param name="begin"></param>
        public void SimulateTimer(int time, int begin)
        {
            OnTimer(new TimeEventArgs(time, begin));
        }
    }
}
