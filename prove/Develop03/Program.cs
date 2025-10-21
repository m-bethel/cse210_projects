using System;

class Program
{
    static void Main(string[] args)
    {   
        Menu menu = new Menu();
        bool running = true;
        while (running)
        {
            menu.DisplayMenu();
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Scripture scripture = new Scripture();
                    scripture.SelectScripture();
                    break;

                case "2":
                Console.WriteLine("Exiting the program. Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
