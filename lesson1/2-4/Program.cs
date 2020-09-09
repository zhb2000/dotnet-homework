using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = InutMatrix();
            Console.WriteLine(IsToeplitz(matrix));
        }

        static bool IsToeplitz(int[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                if (!CheckDiagonal(matrix, x, 0))
                {
                    return false;
                }
            }
            for (int y = 1; y < matrix.GetLength(1); y++)
            {
                if (!CheckDiagonal(matrix, 0, y))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check the diagonal start from (x, y)
        /// </summary>
        static bool CheckDiagonal(int[,] matrix, int x, int y)
        {
            for (int i = 1; x + i < matrix.GetLength(0) && y + i < matrix.GetLength(1); i++)
            {
                if (matrix[x + i, y + i] != matrix[x, y])
                {
                    return false;
                }
            }
            return true;
        }

        static int[,] InutMatrix()
        {
            Console.WriteLine("input n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("input m:");
            int m = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, m];
            Console.WriteLine($"input a {n}*{m} matrix:");
            for (int i = 0; i < n; i++)
            {
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = int.Parse(row[j]);
                }
            }
            return matrix;
        }
    }
}
