namespace _3_Liskov_Subtitution_Principle___GOOD_EXAMPLE
{
    internal class Program
    {
        public class Shape
        {
            public virtual double GetArea() => 0;
        }

        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public override double GetArea() => Width * Height;
        }

        public class Square : Shape
        {
            public double Side { get; set; }

            //THIS IS THE KEY POINT OF LSP, SINCE CHILD CLASS MUST ACT CORRECTLY EVEN WE USE PARENT CLASS AS A REFERENCE
            public override double GetArea() => Side * Side;
        }

        public static void PrintArea(Shape shape)
        {
            Console.WriteLine($"The area is {shape.GetArea()}");
        }

        public static void Main()
        {
            Shape rectangle = new Rectangle { Width = 4, Height = 5 };
            Shape square = new Square { Side = 4 };

            PrintArea(rectangle); // Works as expected
            PrintArea(square);    // Works as expected
        }
    }
}
