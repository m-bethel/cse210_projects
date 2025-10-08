class Prompt
{
    public string GetRandomPrompt()
    {
        string[] prompts = new string[]
        {
            "What made you smile today?",
            "Describe a challenge you overcame recently.",
            "What are you grateful for today?",
            "Write about a memorable moment from your week.",
            "What is something new you learned recently?",
            "What was the highlight of your day?",
            "Describe a place you would like to visit and why.",
            "What is a goal you are working towards?"
        };

        Random rand = new Random();
        int index = rand.Next(prompts.Length);
        return prompts[index];
    }
}