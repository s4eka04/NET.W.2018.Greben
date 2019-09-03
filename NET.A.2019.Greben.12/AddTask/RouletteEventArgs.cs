using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTaskEvent
{
    public class RouletteEventArgs : EventArgs
    {
        /// <summary>
        /// Prop Number
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Prop Parity
        /// </summary>
        public Parity Parity { get; private set; }

        /// <summary>
        /// Prop Color
        /// </summary>
        public Color Color { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="number"></param>
        /// <param name="parity"></param>
        /// <param name="color"></param>
        public RouletteEventArgs(int number, Parity parity, Color color)
        {
            Number = number;
            Parity = parity;
            Color = color;
        }
    }
}
