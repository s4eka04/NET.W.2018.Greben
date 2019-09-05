using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Greben_13_14
{
    public class СhangeEventArgs : EventArgs
    {
        private readonly int index1;
        private readonly int index2;

        public СhangeEventArgs(int index1, int index2)
        {
            this.index1 = index1;
            this.index2 = index2;
        }

        public int Index1 { get => index1; }
        public int Index2 { get => index2; }

    }
}
