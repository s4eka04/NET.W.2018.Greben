using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timer.Trial_classes;

namespace Timer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Timer timer = new Timer();
            DighitalWatch dighital = new DighitalWatch(timer);
            WristWatch wrist = new WristWatch(timer);

            int beginTime = DateTime.Now.Second;
            Console.WriteLine("Enter time on the timer(in seconds): ");

            if (!Int32.TryParse(Console.ReadLine(), out int timeOnTimer))
            {
                throw new Exception("Inccorect entered value");
            }

            for (int i = timeOnTimer; i > 0; i--)
            {
                Console.WriteLine("Time: " + i);

                Thread.Sleep(500);
            }

            timer.SimulateTimer(timeOnTimer, beginTime);
        }
    }
}
