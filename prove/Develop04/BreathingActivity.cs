class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run()
    {
        DisplayStartingMessage();
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write("\n\nBreathe in...");
            PauseWithCountdown(4);
            
            Console.Write("\nNow breathe out...");
            PauseWithCountdown(6);
        }
        
        DisplayEndingMessage();
    }
}
