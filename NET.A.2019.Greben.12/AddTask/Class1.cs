using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTaskEvent
{
    /// <summary>
    /// Enum Parity
    /// </summary>
    public enum Parity
    {
        Even = 1,
        Odd = 2
    }

    /// <summary>
    /// Enum Color
    /// </summary>
    public enum Color
    {
        Red = 1,
        Green = 2
    }

    public class RouletteMeneger
    {
        /// <summary>
        /// Delegate Type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void NumberStateHandler(object sender, RouletteEventArgs e);

        /// <summary>
        /// Event
        /// </summary>
        public event NumberStateHandler BingoOnRoulette;

        /// <summary>
        /// Info for event
        /// </summary>
        /// <param name="number"></param>
        /// <param name="parity"></param>
        /// <param name="color"></param>
        public void SupplementInfo(int number, Parity parity, Color color)
        {
            InvokeEvent(new RouletteEventArgs(number, parity, color));
        }

        /// <summary>
        /// Invoke Event
        /// </summary>
        /// <param name="e"></param>
        private void InvokeEvent(RouletteEventArgs e)
        {
            if (e != null)
            {
                BingoOnRoulette(this, e);
            }
        }
    }

    public class NumberDrawnOut
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manager"></param>
        public NumberDrawnOut(RouletteMeneger manager)
        {
            manager.BingoOnRoulette += DrawnOutInfo;
        }

        /// <summary>
        /// Notify
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DrawnOutInfo(object sender, RouletteEventArgs e)
        {
            Console.WriteLine("Number: " + e.Number);
            Console.WriteLine("Parity: " + e.Parity);
            Console.WriteLine("Color: " + e.Color);
            Console.WriteLine();
        }
    }
}
