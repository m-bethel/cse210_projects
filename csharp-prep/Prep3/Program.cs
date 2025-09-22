using System;

class Program
{
    static void Main(string[] args)
    {
        string response = "yes";
        Random randomnumbergenerator = new Random();
        int number = randomnumbergenerator.Next(1, 101);

        Console.WriteLine("Welcome to the Number Guessing Game");
        Console.WriteLine("I am thinking of a number between 1 and 100");
        Console.WriteLine("Would you like to play? (yes/no)");
        response = Console.ReadLine().ToLower();
        
            while (response == "yes")
            {
                Console.WriteLine("What is your guess?");
                string guess = Console.ReadLine();
                int userguess = int.Parse(guess);

                if (userguess < number)
                {
                    Console.WriteLine("Too low");
                    Console.WriteLine("Would you like to guess again? (yes/no)");
                    response = Console.ReadLine().ToLower();
                }
                else if (userguess > number)
                {
                    Console.WriteLine("Too high");
                    Console.WriteLine("Would you like to guess again? (yes/no)");
                    response = Console.ReadLine().ToLower();
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine("Would you like to play again? (yes/no)");
                    response = Console.ReadLine().ToLower();
                    number = randomnumbergenerator.Next(1, 101);
                }
            }
        Console.WriteLine("Thanks for playing!");

    }
}