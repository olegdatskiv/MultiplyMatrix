using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrixFirst = new Matrix();
            Matrix matrixSecond = new Matrix();

            MatrixAdder.CountTimeParallelMultiplying(matrixFirst, matrixSecond,4);
            MatrixAdder.CountTimeSimpleMultiplying(matrixFirst, matrixSecond); 
        }
    }
}
