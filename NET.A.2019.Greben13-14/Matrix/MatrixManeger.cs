using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Greben_13_14
{
    public class MatrixManeger
    {
        public event EventHandler<СhangeEventArgs> changeMatrix;

        protected virtual void  Change(СhangeEventArgs e)
        {
            EventHandler<СhangeEventArgs> temp = changeMatrix;
            if (temp != null)
            {
                temp(this, e);
            }
        }

        public void SimulateChangeMatrix(int index1, int index2)
        {
            Change(new СhangeEventArgs(index1, index2));
        }
    }
}
