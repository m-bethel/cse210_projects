using System;
using System.Security.Cryptography;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine( "Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.WriteLine("What is your name?");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number:");
        int favoriteNumber = int.Parse(Console.ReadLine());

        return favoriteNumber;

    }
    static void PromptUserBirthYear(out int promptUserBirthYear)
    {
        Console.WriteLine("Please enter the year you were born");
        promptUserBirthYear = int.Parse(Console.ReadLine());
        int userAge = DateTime.Now.Year - promptUserBirthYear;
    
    }
    static int SquareNumbers(int favoriteNumber)
    {
        return favoriteNumber * favoriteNumber;
    }
    static void DisplayResult(string userName, int squaredNumber, int userAge)
    {
        
        Console.WriteLine($"{userName}, the square of your number is: {squaredNumber}.");
        Console.WriteLine($"{userName}, You turn {userAge} this year.");
    }

    static void Main(string[] args)
    {
        
        DisplayWelcome();
        Thread.Sleep(1800); // Pause for some time in milliseconds
        Console.Clear();
        
        string promptUserName = PromptUserName();

        int promptUserNumber = PromptUserNumber(); 
    
        int squaredNumber = SquareNumbers(promptUserNumber);

        int promptUserBirthYear;
        PromptUserBirthYear(out promptUserBirthYear);

        DisplayResult(promptUserName, squaredNumber, promptUserBirthYear);
        
        
    }
}