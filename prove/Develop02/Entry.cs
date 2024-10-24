using System;
using System.IO; 

class Entry //creating the class
{

    public void Save()
    {
        Console.WriteLine("What is the filename? (put the file extension on the end. ex. journal.txt)");
        string filename = Console.ReadLine();
        File.Move("journal.txt", filename);
    }

    

    public void Write() //setting it to public and not to return anything
    {
        //getting current day/time from the OS
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        //naming the file something original
        string fileName = "journal.txt";

        //create an if statement so if the file is being created for the first time it creates one and writes onto it
        //but if a file is already in place, it just appends to the file instead.
        if (File.Exists("journal.txt"))
        {
            //creating the file
            using (StreamWriter outputFile = new StreamWriter(fileName, true))
            {
                //getting a random prompt from the Prompt Class
                Prompt freshprompt = new Prompt();
                string prompt=freshprompt.RandomPrompt();
                //writing said promt to the console
                Console.WriteLine(prompt);
                //Allowing a console input and naming it something cool
                string journalEntry = Console.ReadLine();
                //formatting the file that is to be written with a date, the prompt that was given, and the entry itself.
                outputFile.WriteLine($"~{dateText.ToString()} -Prompt: {prompt} -Entry: {journalEntry}");
            }
        }
        else{
            //creating the file
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                //getting a random prompt from the Prompt Class
                Prompt freshprompt = new Prompt();
                string prompt=freshprompt.RandomPrompt();
                //writing said promt to the console
                Console.WriteLine(prompt);
                //Allowing a console input and naming it something cool
                string journalEntry = Console.ReadLine();
                //formatting the file that is to be written with a date, the prompt that was given, and the entry itself.
                outputFile.WriteLine($"~{dateText.ToString()} -Prompt: {prompt} -Entry: {journalEntry}");
            }
        }     
    }

    


}