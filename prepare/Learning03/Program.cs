using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction newFraction1 = new Fraction();
        Fraction newFraction2 = new Fraction(5);
        Fraction newFraction3 = new Fraction(3,4);
        Fraction newFraction4 = new Fraction(1,3);
        
        Console.WriteLine(newFraction1.GetFractionString());
        Console.WriteLine(newFraction2.GetFractionString());
        Console.WriteLine(newFraction3.GetFractionString());
        Console.WriteLine(newFraction4.GetFractionString());

        Console.WriteLine(newFraction1.GetFractionFloat());
        Console.WriteLine(newFraction2.GetFractionFloat());
        Console.WriteLine(newFraction3.GetFractionFloat());
        Console.WriteLine(newFraction4.GetFractionFloat());

    }
}
