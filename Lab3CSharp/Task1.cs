using System;
using System.Linq;

namespace Lab3
{
    public class Task1
    {
        /// <summary>
        /// Executes Task 1: managing an array of Trapeze objects.
        /// </summary>
        public static void Execute()
        {
            Console.Write("Enter the number of trapezoids: ");
            int n = int.Parse(Console.ReadLine()!);
            Trapeze[] trapezoids = new Trapeze[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nTrapezoid {i + 1}:");
                Console.Write("Base A: ");
                int a = int.Parse(Console.ReadLine()!);
                Console.Write("Base B: ");
                int b = int.Parse(Console.ReadLine()!);
                Console.Write("Height H: ");
                int h = int.Parse(Console.ReadLine()!);
                Console.Write("Color code (integer): ");
                int c = int.Parse(Console.ReadLine()!);

                trapezoids[i] = new Trapeze(a, b, h, c);
            }

            Console.WriteLine("\n--- Sorted by Color ---");
            var byColor = trapezoids.OrderBy(t => t.Color).ToArray();
            PrintTrapezoids(byColor);

            Console.WriteLine("\n--- Sorted by Area ---");
            var byArea = trapezoids.OrderBy(t => t.GetArea()).ToArray();
            PrintTrapezoids(byArea);

            Console.WriteLine("\n--- Sorted by Perimeter ---");
            var byPerimeter = trapezoids.OrderBy(t => t.GetPerimeter()).ToArray();
            PrintTrapezoids(byPerimeter);

            int squaresCount = trapezoids.Count(t => t.IsSquare());
            Console.WriteLine($"\nNumber of trapezoids that are squares: {squaresCount}");
        }

        /// <summary>
        /// Helper method to print an array of Trapeze objects.
        /// </summary>
        private static void PrintTrapezoids(Trapeze[] array)
        {
            foreach (var t in array)
            {
                t.PrintLengths();
                Console.WriteLine($"Color: {t.Color}, Area: {t.GetArea():F2}, Perimeter: {t.GetPerimeter():F2}, Is Square: {t.IsSquare()}");
            }
        }
    }

    /// <summary>
    /// Represents a trapezoid with bases, height, and color.
    /// Assuming isosceles trapezoid for perimeter calculation.
    /// </summary>
    public class Trapeze
    {
        protected int a;
        protected int b;
        protected int h;
        protected int c;

        public Trapeze(int a, int b, int h, int c)
        {
            this.a = a;
            this.b = b;
            this.h = h;
            this.c = c;
        }

        public int A
        {
            get => a;
            set => a = value;
        }

        public int B
        {
            get => b;
            set => b = value;
        }

        public int H
        {
            get => h;
            set => h = value;
        }

        public int Color
        {
            get => c;
        }

        public void PrintLengths()
        {
            Console.WriteLine($"Base A: {a}, Base B: {b}, Height: {h}");
        }

        public double GetPerimeter()
        {
            double side = Math.Sqrt(h * h + Math.Pow(Math.Abs(a - b) / 2.0, 2));
            return a + b + 2 * side;
        }

        public double GetArea()
        {
            return (a + b) / 2.0 * h;
        }

        public bool IsSquare()
        {
            return a == b && a == h;
        }
    }
}