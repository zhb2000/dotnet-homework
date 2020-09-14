using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace CSHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            double areaSum = 0;
            for (int cnt = 1; cnt <= 10; cnt++)
            {
                areaSum += ShapeFactory.MakeShape().Area;
            }
            Console.WriteLine($"sum of area: {areaSum}");
        }
    }

    class ShapeFactory
    {
        public static IShape MakeShape()
        {
            int randNum = rand.Next(4);
            if (randNum == 0)
            {
                return new Round(rand.Next(1, 10));
            }
            else if (randNum == 1)
            {
                return new Rectangle(rand.Next(1, 10), rand.Next(1, 10));
            }
            else if (randNum == 2)
            {
                return new Square(rand.Next(1, 10));
            }
            else
            {
                int a = rand.Next(1, 10), b = rand.Next(2, 10);
                int c = a + b - 1;
                return new Triangle(a, b, c);
            }
        }

        private static readonly Random rand = new Random();
    }
    interface IShape
    {
        double Area { get; }
        bool IsValid();
    }

    class Round : IShape
    {
        public Round(double radius) => Radius = radius;
        public double Radius { get; set; }
        public double Area { get => Math.PI * Radius * Radius; }
        public bool IsValid() => Radius > 0;
    }

    class Rectangle : IShape
    {
        public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }
        public virtual double Length { get; set; }
        public virtual double Height { get; set; }
        public virtual double Area => Length * Height;
        public virtual bool IsValid() => Length > 0 && Height > 0;
    }

    class Square : Rectangle
    {
        public Square(double side) : base(side, side)
        {
        }
        public override double Length { get; set; }
        public override double Height { get; set; }
        public override double Area => Length * Height;
        public override bool IsValid()
        {
            return Length > 0 && Height > 0 && Length == Height;
        }
    }

    class Triangle : IShape
    {
        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }
        public double Area
        {
            get
            {
                double a = SideA, b = SideB, c = SideC;
                double s = (a + b + c) / 2;
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            }
        }
        public bool IsValid()
        {
            if (SideA <= 0 || SideB <= 0 || SideC <= 0)
            {
                return false;
            }
            double[] arr = new double[] { SideA, SideB, SideC };
            Array.Sort(arr);
            if (arr[0] + arr[1] <= arr[2])
            {
                return false;
            }
            return true;
        }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
    }

}
