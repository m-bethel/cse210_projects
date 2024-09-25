using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter numbers to add to the list. Enter 0 to stop.");
        List<int> numbers = new List<int>();


        int x = -1;
        int sum = 0;
        int avg = 0;
        int max = 0;

        while (x!=0)
        {
            Console.Write("Enter a number: ");
            string userInput = Console.ReadLine();
            x = int.Parse(userInput);
            if (x != 0)
            {
                numbers.Add(x);
            }
        }




        foreach (int number in numbers)
        {
            sum = sum + number;
            avg = sum/numbers.Count;
            if (max < number)
            {
                max = number;
            }
        }
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The maximum v is: {max}");


    }
}