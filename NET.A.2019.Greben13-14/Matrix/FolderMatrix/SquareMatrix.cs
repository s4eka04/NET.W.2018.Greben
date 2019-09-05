using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Greben_13_14;

namespace Matrix_Greben_13_14.FolderMatrix
{
    public class SquareMatrix<T> : Matrix<T>
    {
        public SquareMatrix(T[][] inputMatrix, Func<T, T, bool> func) : base(inputMatrix, func) {  }

        protected override bool CheckMatrix(T[][] matr)
        {
            int row = matr.Length;
            for(int i = 0; i < row; i++)
            {
                if(matr[i].Length != row)
                {
                    return false;
                }
            }

            return true;
        }

        protected override void ChangeItem(object sender, СhangeEventArgs e)
        {
            Console.WriteLine("Change Square matrix element!");
            base.ChangeItem(sender, e);
        }
    }
}
