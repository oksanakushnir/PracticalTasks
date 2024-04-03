using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaPartTwo
{
    internal class Task_2
    {
        internal void CalculateRectangle()
        {
            Console.WriteLine("Enter Rectangle Width:");
            var inputWidth = Console.ReadLine();

            Console.WriteLine("Enter Rectangle Height:");
            var inputHeight = Console.ReadLine();

            if (!int.TryParse(inputWidth, out int rectangleWidth))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            if (!int.TryParse(inputHeight, out int rectangleHeight))
            {
                Console.WriteLine("Invalid value entered.");
                return;
            }

            IRectangle rectangle = new Rectangle(rectangleWidth, rectangleHeight);

            Console.WriteLine("Calculated rectangle properties:");
            Console.WriteLine($"Area: {rectangle.CalculateArea()}");
            Console.WriteLine($"Perimeter : {rectangle.CalculatePerimeter()}");
            Console.WriteLine($"Diagonal: {rectangle.GetDiagonal()}");
        }
    }

    public interface IRectangle
    {
        double CalculateArea();
        double CalculatePerimeter();
        double GetDiagonal();
    }
    
    public class Rectangle : IRectangle
    {
        public double Width { get; set; }

        public double Height { get; set; }
        
        public double Angle { get; private set; }
        
        public Rectangle()
        {
            Width = 0;
            Height = 0;
            Angle = 90;
        }

        public Rectangle(double width, double height) : this()
        {
            Width = width;
            Height = height;
        }
        
        public double CalculateArea()
        {
            return Width * Height;
        }

        public double CalculatePerimeter()
        {
            return (Width + Height) * 2;
        }

        public double GetDiagonal()
        {
            return Math.Pow(Math.Pow(Width, 2) + Math.Pow(Height, 2), 0.5);
        }
    }
}
