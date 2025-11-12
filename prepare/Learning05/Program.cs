using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square square1 = new Square("Orange",6);
        shapes.Add(square1);

        Rectangle r2d2 = new Rectangle("Brown", 5, 6);
        shapes.Add(r2d2);

        Circle c4 = new Circle("Pink", 12.6);
        shapes.Add(c4);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetArea()} and {shape.GetColor()}");
        }

    }
}