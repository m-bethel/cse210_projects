using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your Grade Percentage?");
        string gradeNumber = Console.ReadLine();

        int grade = int.Parse(gradeNumber);

        string letterGrade;

        if (grade >= 90)
        {
            letterGrade = "A" ;
        }
        else if (grade >= 80)
        {
            letterGrade = "B" ;
        }
        else if (grade >= 70)
        {
            letterGrade = "C" ;
        }
        else if (grade >= 60)
        {
            letterGrade = "D" ;
        }
        else
        {
            letterGrade = "F";
        }

        Console.WriteLine($"Your letter grade is: {letterGrade}");
        
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, You passed the class!");
        }
        else
        {
            Console.WriteLine("Work harder dolt.");
        }
    }
}