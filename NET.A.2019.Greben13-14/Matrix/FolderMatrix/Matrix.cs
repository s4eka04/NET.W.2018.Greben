using Matrix.Greben_13_14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Greben_13_14.FolderMatrix
{
    public abstract class Matrix<T>
    {
        protected T[][] matrix = null;
        protected MatrixManeger e = new MatrixManeger();
        public Func<T, T, bool> func = null;

        public int Rows { get; private set; }

        public int Columns { get; private set; }

        public Matrix(T[][] inputMatrix, Func<T, T, bool> func)
        {
            if(func == null)
            {
                throw new Exception("Func cann't Null");
            }

            this.func = func;

            if (!CheckMatrix(inputMatrix))
            {
                throw new Exception("inappropriate matrix");
            }

            Rows = inputMatrix.Length;
            Columns = inputMatrix[0].Length;
            matrix = new T[Rows][];
            MatrixCreation();
            FillMatrix(inputMatrix);
        }

        public virtual void SubscribeEvent()
        {
            e.changeMatrix += ChangeItem;
        }
        protected virtual void FillMatrix(T[][] matr)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    matrix[i][j] = matr[i][j]; 
                }
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    str.AppendFormat(matrix[i][j].ToString() + " ");
                }
                str.AppendFormat("\n");
            }

            str.AppendFormat("\n");

            return str.ToString();
        }

        private  void MatrixCreation() 
        {
            for(int i = 0; i < Rows; i ++)
            {
                matrix[i] = new T[Columns];
            }
        }

        public virtual T this[int index1, int index]
        {
            get => matrix[index1][index];

            set
            {
                if(value is T)
                {
                    matrix[index1][index] = value;
                    e.SimulateChangeMatrix(index1, index);
                }
                else
                {
                    throw new Exception("Incorrect value");
                }
            }
        }
        protected virtual bool CheckMatrix( T[][] matr)
        {
            int rows = matr[0].Length;
            for(int i = 0; i < matr.Length; i++ )
            {
                if(matr[i].Length != rows)
                {
                    return false;
                }
            }

            return true;
        }

        protected bool Equals(T t1, T t2)
        {
            if(func(t1,t2))
            {
                return true;
            }

            return false;
        }

        protected virtual void ChangeItem(object sender, СhangeEventArgs e)
        {
            Console.WriteLine("matrix[" + e.Index1 + ", " + e.Index2 + "]");
            Console.WriteLine("Matrix Type :" + typeof(T));
            Console.WriteLine();
        }
    }
}
