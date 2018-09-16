using System.Diagnostics;
using System;

namespace MultiplyMatrix
{
    class MatrixAdder
    {
        public static void CountTimeSimpleMultiplying(Matrix firstMatrix, Matrix secondMatrix)
        {

            Stopwatch stopwatch = Stopwatch.StartNew();
            firstMatrix.MultiplyMatrix(secondMatrix);
            stopwatch.Stop();

            string retVal = $"Simple multiplying took {stopwatch.ElapsedMilliseconds} miliseconds.";

            //for (int i = 0; i < firstMatrix.Height; i++)
            //{
            //    for (int j = 0; j < firstMatrix.Width; j++)
            //    {
            //        Console.Write("{0} ", firstMatrix.Elements[i, j]);
            //    }
            //    Console.Write("\n");
            //}
            Console.Write("\n");
            Console.WriteLine(retVal);
            Console.Write("\n");
        }


        public static void CountTimeParallelMultiplying(Matrix firstMatrix, Matrix secondMatrix,int numberOfThreads)
        {



            Stopwatch stopwatch = Stopwatch.StartNew();

            firstMatrix.MultiplyMatrixParallel(secondMatrix,numberOfThreads);
            stopwatch.Stop();

            string retVal = $"Parallel multiplying took {stopwatch.ElapsedMilliseconds} miliseconds.";

            //for (int i = 0; i < firstMatrix.Height; i++)
            //{
            //    for (int j = 0; j < firstMatrix.Width; j++)
            //    {
            //        Console.Write("{0} ", firstMatrix.Elements[i, j]);
            //    }
            //    Console.Write("\n");
            //}

            Console.Write("\n");
            Console.WriteLine(retVal);
            Console.Write("\n");
        }
    }
}
