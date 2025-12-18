using System;
using System.Collections.Generic;
using System.Threading;

// Base Activity Class
class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "";
        _description = "";
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        PauseWithSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        PauseWithSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name} Activity.");
        PauseWithSpinner(3);
    }

    public void PauseWithSpinner(int seconds)
    {
        List<string> spinnerChars = new List<string> { "|", "/", "-", "\\" };
        
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        
        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % spinnerChars.Count;
        }
    }

    public void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public virtual void Run()
    {
        // This will be overridden in derived classes
    }
}