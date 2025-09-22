using System;

class Program
{
    static void Main(string[] args)
    {


        List<int> numbers = new List<int>();

        Console.WriteLine("Enter integers (type '0' to finish):");
        while (true)
        {
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
                break;
            numbers.Add(input);
        }
        int sum = 0;
        float average = 0;
        int maximum = 0;
        foreach (int number in numbers)
        {
            sum += number;
            average = sum / numbers.Count;
            maximum = numbers.Max();

        }
        Console.WriteLine($"Total: {sum}, Average: {average}, Largest: {maximum}");
    }
}