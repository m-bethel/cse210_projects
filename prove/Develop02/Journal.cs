class Journal
{
    private List<string> entries;

    public Journal()
    {
        entries = new List<string>();
    }

    public void WriteEntry()
    {

        Console.Write("Prompt: ");
        Prompt prompt = new Prompt();

        string givenPrompt = prompt.GetRandomPrompt();
        Console.WriteLine(givenPrompt);

        string dt = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss: ");
        string entry = dt + "Prompt: " + givenPrompt + " " + Console.ReadLine();
        entries.Add(entry);
        Console.WriteLine("Entry added.");
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }
        Console.WriteLine("===========================");
        Console.WriteLine("Journal Entries:");
        foreach (string entry in entries)
        {
            Console.WriteLine($"- {entry}");
            Console.WriteLine("--------------------");
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        foreach (string line in entries)
        {
            string[] parts = line.Split(' ');
            string csvLine = string.Join(',', parts);
            Console.WriteLine(csvLine);
        }
        System.IO.File.WriteAllLines(filename, entries);
        Console.WriteLine("Entries saved to file.");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (System.IO.File.Exists(filename))
        {
            entries = System.IO.File.ReadAllLines(filename).ToList();
            Console.WriteLine("Entries loaded from file.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}