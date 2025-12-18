using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();

        // Add different shapes to the list
        Square square = new Square("Red", 5);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        shapes.Add(rectangle);

        Circle circle = new Circle("Green", 3);
        shapes.Add(circle);

        // Iterate through the list and display color and area for each shape
        Console.WriteLine("Shape Information:");
        Console.WriteLine("==================");
        
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            
            Console.WriteLine($"The {color} shape has an area of {area:F2}");
        }
    }
}