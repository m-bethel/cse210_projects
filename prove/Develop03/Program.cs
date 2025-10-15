using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case " ":
                    running = false;
                    break;

                case "quit":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
