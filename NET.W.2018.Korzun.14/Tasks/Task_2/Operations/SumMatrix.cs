using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Task_2.Matrix;

namespace Tasks.Task_2.Operations
{
    public static class SumMatrix
    {
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            if (firstMatrix is null)
            {
                throw new ArgumentNullException();
            }

            if (secondMatrix is null)
            {
                throw new ArgumentNullException();
            }

            if (firstMatrix.Size != secondMatrix.Size)
            {
                throw new ArgumentException("matrix must be the same size.");
            }

            SquareMatrix<T> newMatrix = new SquareMatrix<T>(firstMatrix.Size);

            for (int i = 0; i < secondMatrix.Size; i++)
            {
                for (int j = 0; j < secondMatrix.Size; j++)
                {
                    /*I need to install Microsoft.CSharp.RuntimeBinder for the use to dynamic type
                     becose my project has been created in .Net Framework 2.0? Runtime Error*/
                    newMatrix[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
                }                                                                  
            }

            return newMatrix;
        }
    }
}
