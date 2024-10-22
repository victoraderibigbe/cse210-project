using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square s = new Square("blue", 5);
        shapes.Add(s);

        Rectangle r = new Rectangle("pink", 7, 4);
        shapes.Add(r);

        Circle c = new Circle("green", 3);
        shapes.Add(c);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}");
        }
    }
}