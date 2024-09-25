using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("What was your final percentage? ");
        string percentage = Console.ReadLine();

        int x =int.Parse(percentage);

        string letterGrade = "Letter";

        if (x >= 90)
        {
            letterGrade="A";
        }
        else if (x >= 80 &&  x < 90)
        {
            letterGrade="B";
        }
        else if (x >= 70 && x < 80 )
        {
            letterGrade="C";
        }
        else if (x >= 60 && x < 70)
        {
            letterGrade="D";
        }
        else if (x < 60)
        {
            letterGrade="F";
        }

        Console.WriteLine($"Your final grade is: {letterGrade}");

        if ( x >= 70)
        {
            Console.WriteLine("Congrats! You passed the class!");

        }
        else if (x < 70)
        {
            Console.WriteLine("Should have studied Harder! You failed the class :(");
        }
    }
}