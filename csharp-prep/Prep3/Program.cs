using System;

class Program
{
    static void Main(string[] args)
    {
        Random rng = new Random();
        int magicNumber = rng.Next(101);

        Console.WriteLine("What is the Magic Number? (Between 1-10, type 0 to abort)");
        

        string response = "response";

        while (response != "Correct!" && response !="Better luck next time!")

        
        {
            Console.Write($"({magicNumber}) Your Guess: ");

            string userInput = Console.ReadLine();
            int x = int.Parse(userInput);

            if (x < magicNumber)
            {
                response = "Higher";
            }
            if (x > magicNumber)
            {
                response = "Lower";
            }
            if (x == magicNumber)
            {
                response = "Correct!";
            }
            if (x == 0)
            {
                response = "Better luck next time!";
            }

            Console.WriteLine(response);

        }

        

        
    }
}