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
            double[] arr = InputArray();
            ArrayInfo info = GetArrayInfo(arr);
            Console.WriteLine(
                $"max: {info.max}, min: {info.min}, sum: {info.sum}, avg: {info.avg}");
        }

        /// <summary>
        /// 保存最大值、最小值、和、平均值的结构体
        /// </summary>
        struct ArrayInfo
        {
            public double max;
            public double min;
            public double sum;
            public double avg;

            public ArrayInfo(double max, double min, double sum, double avg)
            {
                this.max = max;
                this.min = min;
                this.sum = sum;
                this.avg = avg;
            }
        }

        static ArrayInfo GetArrayInfo(double[] arr)
        {
            double max = arr[0], min = arr[0], sum = 0;
            foreach (double x in arr)
            {
                max = Math.Max(max, x);
                min = Math.Min(min, x);
                sum += x;
            }
            return new ArrayInfo(max, min, sum, sum / arr.Length);
        }

        static double[] InputArray()
        {
            Console.WriteLine("Input array size:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Input your array:");
            string[] strArray = Console.ReadLine().Split(' ');
            double[] arr = new double[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                arr[i] = double.Parse(strArray[i]);
            }
            return arr;
        }
    }
}
