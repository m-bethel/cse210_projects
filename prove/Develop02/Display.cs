using System;
using System.IO;

class Display
{
    //Exceeding the Requirements
    //Editing Entries
    public void EditEntries()
    {
        //Load and display the file
        //asking user for a file name
        Console.WriteLine("What is the filename? (put the file extension on the end. ex. journal.txt)");
        string filename = Console.ReadLine();

        //public void List <string> fileEntries = new List <string> ();

        if (File.Exists(filename))
        {
            //reading the file in
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split("~");
                //fileEntries.Add(new FileEntries{parts[0]});

                string entries = parts[0];

                Console.WriteLine(entries);
            }
            
        }

        //ask which one to edit
        Console.WriteLine("Which entry would you like to edit?)");
        int index = int.Parse(Console.ReadLine());

        //var entry = fileEntries[index -1];

        Console.WriteLine("Write new entry: ");
        string newEntry = Console.ReadLine();
        //entry = newEntry;
        Console.WriteLine("updated!");


    }

    //setting up the method to display the entries
    public void DisplayEntries()
    {
        //setting a default filename to load as journal.txt
        string filename = "journal.txt";
        if (File.Exists(filename))
        {
            
            //reading the file in
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split("~");
                string entries = parts[0];
                Console.WriteLine(entries);
            }
        }
        //just in case the file does not exist
        else
        {
            Console.WriteLine("I cannot find that file, load a file beforehand to display it.");
        }
        
    }
    //Loading a specified file
    public void Load()
    {
        //asking user for a file name
        Console.WriteLine("What is the filename? (put the file extension on the end. ex. journal.txt)");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            //reading the file in
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split("~");
                string entries = parts[0];
                Console.WriteLine(entries);
            }
            
        }
        //a line just in case the file was misspelled, etc.
        else
        {
            Console.WriteLine("I cannot find that file, load a file beforehand to display it.");
        }
    }

}