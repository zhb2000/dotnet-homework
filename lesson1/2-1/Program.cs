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
            Console.Write("Input an integer: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write($"Prime Factors of {num}: ");
            Output(PrimeFactors(num));
            Console.WriteLine();
        }

        /// <summary>
        /// 素数分解
        /// </summary>
        /// <param name="num">要被分解的数</param>
        /// <returns>num 的所有素数因子</returns>
        static int[] PrimeFactors(int num)
        {
            int temp = num;
            var primeFactors = new List<int>();
            for (int i = 2; i * i <= num; i++)
            {
                if (temp % i == 0)
                {
                    primeFactors.Add(i);
                    while (temp % i == 0)
                    {
                        temp /= i;
                    }
                }
            }
            if (temp > 1) // num is a prime
            {
                primeFactors.Add(temp);
            }
            return primeFactors.ToArray();
        }

        static void Output(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != 0)
                {
                    Console.Write(", ");
                }
                Console.Write(arr[i]);
            }
        }
    }
}
