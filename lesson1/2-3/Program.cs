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
            Console.WriteLine("All primes in 2~100:");
            int[] primes = AllPrimes(100);
            foreach (int prime in primes)
            {
                Console.Write($"{prime} ");
            }
        }

        /// <summary>
        /// 埃氏筛法求 2~n 的所有质数
        /// </summary>
        static int[] AllPrimes(int n)
        {
            bool[] isComposite = new bool[n + 1];
            for (int i = 2; i * i <= n; i++)
            {
                if (!isComposite[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        isComposite[j] = true;
                    }
                }
            }
            var primes = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (!isComposite[i])
                {
                    primes.Add(i);
                }
            }
            return primes.ToArray();
        }
    }
}
