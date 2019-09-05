using Matrix_Greben_13_14.FolderMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Greben_13_14.Helper
{
    public abstract class MatrixAdditionHelper<T>: Matrix<T>
    {
        protected static  Func<T, T, bool> func1;
        private MatrixAdditionHelper(T[][] inputMatrix, Func<T, T, bool> func): base(inputMatrix, func)
        {

        }
       public static Matrix<T> Add(Matrix<T> t1, Matrix<T> t2, Func<T, T, T> funcAddition)
        {
            func1 = t1.func;
            if (t1.Rows != t2.Rows && t1.Columns != t2.Columns)
            {
                throw new Exception("it is impossible to summarize matrices");
            }

            T[][] array = new T[t1.Rows][];
            for(int i = 0; i < t1.Rows; i++)
            {
                array[i] = new T[t1.Columns];
            }

            
            for(int i = 0; i < t1.Rows; i++)
            {
                for(int j = 0; j < t1.Columns; j++)
                {
                    array[i][j] = funcAddition(t1[i, j],t2[i, j]); 
                }
            }

            if(func1 == null)
            {
                func1 = t2.func;
            }
            return new SquareMatrix<T>(array, func1);
        }
    }
}