using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Greben_13_14;
using Matrix_Greben_13_14.FolderMatrix;

namespace Matrix_Greben_13_14.FolderMatrix
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(T[][] inputMatrix, Func<T, T, bool> func) : base(inputMatrix, func) {  }

        protected override bool CheckMatrix(T[][] matr)
        {
            if(!base.CheckMatrix(matr))
            {
                return false;
            }

            for (int i = 0; i < matr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (i != j)
                    {
                        if(func(matr[i][j], default(T)))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public override T this[int index1, int index]
        {
            get => base[index1, index];

            set
            {
                if (index1 == index)
                {
                    base[index1, index] = value;
                }
                else
                {
                    throw new Exception("non-diagonal elements cannot be changed in a diagonal matrix");
                }
            }
        }

        protected override void ChangeItem(object sender, СhangeEventArgs e)
        {
            Console.WriteLine("Change Diagonal matrix element!");
            base.ChangeItem(sender, e);
        }
    }
}
