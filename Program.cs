using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KR_2
{
    public class Matrix
    {
        private int rows;
        private int columns;
        private int[,] matr;

        internal class Program
        {
            static void Main(string[] args)
            {
                Matrix matr = new Matrix("C:\\Users\\andre\\OneDrive\\Рабочий стол\\Matrix.txt");
                matr.Show();
                matr.StepToTheRight();
                Console.WriteLine();
                matr.Show();
            }
        }
        public Matrix(string filename)
        {
            string[] path = File.ReadAllLines(filename);
            rows = int.Parse(path[0]);
            columns = int.Parse(path[1]);
            matr = new int[rows, columns];
            int rowsBuffer = 0;
            for (int i = 2; i < path.Length;)
            {
                for (int n = 0; n < rows; n++)
                {
                    for (int m = 0; m < columns; m++)
                    {
                        matr[n,m] = int.Parse(path[i]);
                        i++;
                    }
                }
            }
        }

        public void StepToTheRight()
        {
            int buffer = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int cntStep = 0; cntStep < i + 1; cntStep++)
                {
                    int bufferLastNum = matr[i, columns - 1];
                    int j = columns - 2;
                    for (int cntIteration = 0; cntIteration < 3; cntIteration++)
                    {
                        matr[i, j + 1] = matr[i, j];
                        j--;
                    }
                    matr[i, 0] = bufferLastNum;
                }
            }
        }
        public void Show()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    Console.Write($"{matr[i, j],3} ");
                Console.WriteLine();
            }
        }

    }
}
