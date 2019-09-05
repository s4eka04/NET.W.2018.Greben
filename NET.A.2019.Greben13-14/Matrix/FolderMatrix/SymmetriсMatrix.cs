using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix.Greben_13_14;

namespace Matrix_Greben_13_14.FolderMatrix
{
    public class SymmetriсMatrix<T> : SquareMatrix<T>
    {
        public SymmetriсMatrix(T[][] inputMatrix, Func<T, T, bool> func) : base(inputMatrix, func) { }

        protected override bool CheckMatrix(T[][] matr)
        {
            if(!base.CheckMatrix(matr))
            {
                throw new Exception("Matrix cann't jagged");
            }
            for(int i = 0; i < matr.Length; i ++)
            {
                for(int j = 0; j < i; j++)
                {
                    if ( i != j)
                    {
                        if (!func(matr[i][j], matr[j][i]))
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
                if (index1 != index)
                {

                    base[index1, index] = value;
                    base[index, index1] = value;
                }
                else if (index == index1)
                {
                    base[index1, index] = value;
                }
            }
        }

        protected override void ChangeItem(object sender, СhangeEventArgs e)
        {
            Console.WriteLine("Change Symmetric matrix element!");
            base.ChangeItem(sender, e);
        }
    }
}
