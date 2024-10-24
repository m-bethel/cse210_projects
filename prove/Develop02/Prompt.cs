using System;

//creating the Prompt class
class Prompt
{
    //setting up a list of journal prompts
    public static List<string> Prompts = new List<string>
    {
            "What are you grateful for today?",
            "Describe a challenge you faced recently and how you handled it.",
            "What are your goals for the next month?",
            "Write about a memory that makes you smile.",
            "What is something new you learned this week?",
            "How do you define success in your life?",
            "What habits would you like to improve or eliminate?",
            "What are the qualities you admire most in others?",
            "If you could give advice to your younger self, what would it be?",
            "What does your perfect day look like?",
            "What motivates you to keep going when things get tough?",
            "What is one thing you would like to accomplish this year?",
            "How do you practice self-care?",
            "Write about a time when you felt really proud of yourself.",
            "What does happiness mean to you?",
            "Who is someone who has had a significant impact on your life?",
            "What are some things you would like to let go of in your life?",
            "What are three things you're looking forward to in the near future?",
            "What does work-life balance mean to you?",
            "Describe a place where you feel most at peace."
    };
    
    //initializing the Random class to pick one of the prompts randomly
    public string RandomPrompt()//make it a public string so I can access it later.
    {
        Random random = new Random();
        int index = random.Next(Prompts.Count);
        string prompt = Prompts[index];
        return prompt;
    }

    


}