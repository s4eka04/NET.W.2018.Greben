using Matrix.Greben_13_14.Helper;
using Matrix_Greben_13_14.FolderMatrix;
using System;


namespace Matrix_Greben_13_14
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[4][];
            matrix[0] = new int[] { 1, 2, 3, 4 };
            matrix[1] = new int[] { 1, 3, 4, 5 };
            matrix[2] = new int[] { 1, 2, 3, 4 };
            matrix[3] = new int[] { 1, 2, 3, 4 };

            int[][] matrix4 = new int[3][];
            matrix4[0] = new int[] { 1, 2, 1 };
            matrix4[1] = new int[] { 2, 3, 4 };
            matrix4[2] = new int[] { 1, 4, 3 };

            int[][] m = new int[3][];
            m[0] = new int[] { 1, 2, 1 };
            m[1] = new int[] { 5, 3, 4 };
            m[2] = new int[] { 1, 4, 3 };


            Matrix<int> matrix1 = new SymmetriсMatrix<int>(matrix4, (i, j) => i == j);
            Matrix<int> matrix2 = new SquareMatrix<int>(matrix, (i, j) => i == j);
            Matrix<int> matrix3 = new SquareMatrix<int>(m, (i, j) => i == j);

            matrix3 = MatrixAdditionHelper<int>.Add(matrix1, matrix3, (i, j) => i + j);
            Console.WriteLine(matrix1);
            Console.WriteLine(matrix2);
            Console.WriteLine(matrix3);


            matrix1.SubscribeEvent();
            matrix2.SubscribeEvent();

            matrix1[1, 2] = 50;
            matrix2[3, 1] = 100;

            Console.WriteLine(matrix1);
            Console.WriteLine(matrix2);

        }
    }
}
