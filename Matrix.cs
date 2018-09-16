using System.Threading;
using System;

namespace MultiplyMatrix
{
    class Matrix
    {
        public int[,] Elements { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public Matrix()
        {
            Height = Width = 1000;

            Random rnd = new Random();

            Elements = new int[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Elements[i, j] = rnd.Next(1000);
                }
            }
        }

        public Matrix(int[,] matrix)
        {
            if (matrix != null)
                Elements = matrix;
        }

        public void MultiplyMatrix(Matrix matrix)
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    int tmp = 0;
                    for (int i = 0; i < Width; i++)
                    {
                        tmp += Elements[row, i] * matrix.Elements[i, col];
                    }
                    Elements[row, col] = tmp;
                }
            }

        }

        public void MultiplyMatrixParallel(Matrix matrix,int numberOfThreads)
        {

            numberOfThreads = Math.Min(numberOfThreads, this.Height);

            Thread[] threads = new Thread[numberOfThreads];

            for (int i = 0; i < numberOfThreads; i++)
            {

                int firstCoeficient = (Height / numberOfThreads) * i;
                int lastCoeficient = (Height / numberOfThreads) * (i + 1);

                threads[i] = new Thread(() =>
                {
                    if (i == (numberOfThreads - 1))
                        lastCoeficient = Height;

                    for (int row = firstCoeficient; row < lastCoeficient; row++)
                    {
                        for (int col = 0; col < Width; col++)
                        {
                            int tmp = 0;
                            for (int k = 0; k < Width; k++)
                            {
                                tmp += Elements[row, k] * matrix.Elements[k, col];
                            }
                            Elements[row, col] = tmp;
                        }
                    }
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }
    }
}
