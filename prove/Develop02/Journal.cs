class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void WriteEntry()
    {
        Console.Write("Prompt: ");
        Prompt prompt = new Prompt();
        string givenPrompt = prompt.GetRandomPrompt();
        Console.WriteLine(givenPrompt);

        Entry entryObj = new Entry();
        entryObj._givenPrompt = givenPrompt;
        entryObj._userEntry = Console.ReadLine();
        
        _entries.Add(entryObj);
        Console.WriteLine("Entry added.");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }
        Console.WriteLine("===========================");
        Console.WriteLine("Journal Entries:");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"- {entry.EntryString()}");
            Console.WriteLine("--------------------");
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        string[] lines = new string[_entries.Count];
        int x = 0; //index for lines array
        foreach (Entry i in _entries)
        {
            string csvLine = string.Join('|', [i._dt, i._givenPrompt, i._userEntry]);

            Console.WriteLine(csvLine);
            lines[x] = csvLine;
            x += 1;
        }
        System.IO.File.WriteAllLines(filename, lines);
        Console.WriteLine("Entries saved to file.");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        List<string> entries = new List<string>();
        if (System.IO.File.Exists(filename))
        {
            _entries = new List<Entry>();
            entries = System.IO.File.ReadAllLines(filename).ToList();
            foreach(string i in entries)
            {
                string[] parts = i.Split('|');
                Entry entryObj = new Entry();
                entryObj._dt = parts[0];
                entryObj._givenPrompt = parts[1];
                entryObj._userEntry = parts[2];

                _entries.Add(entryObj);
            }

            Console.WriteLine("Entries loaded from file.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}