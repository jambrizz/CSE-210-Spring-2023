using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("Red", 5);
        shapes.Add(square);

        Circle circle = new Circle("Blue", 3);
        shapes.Add(circle);

        Rectangle rectangle = new Rectangle("Green", 4, 5);
        shapes.Add(rectangle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor() + " " + shape.GetArea());
        }
    }
}