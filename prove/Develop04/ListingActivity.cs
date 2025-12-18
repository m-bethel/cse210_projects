class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                items.Add(input);
            }
        }
        
        return items;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        string prompt = GetRandomPrompt();
        Console.WriteLine($" --- {prompt} ---");
        Console.Write("You may begin in: ");
        PauseWithCountdown(5);
        Console.WriteLine();
        
        List<string> items = GetListFromUser();
        
        Console.WriteLine($"\nYou listed {items.Count} items!");
        
        DisplayEndingMessage();
    }
}
