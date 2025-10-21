using System;
using System.Collections.Generic;
using System.Linq;
class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture()
    {
        _words = new List<Word>();
        _random = new Random();
    }

    public void SelectScripture()
    {
        // Display available scriptures
        Console.Clear();
        Console.WriteLine("Available Scriptures:");
        Console.WriteLine("1. John 3:16");
        Console.WriteLine("2. Philippians 4:13");
        Console.WriteLine("3. Proverbs 3:5");
        Console.WriteLine("4. Genesis 1:1");
        Console.WriteLine("5. Psalm 23:1");
        Console.Write("\nSelect a scripture (1-5): ");

        string selection = Console.ReadLine();

        switch (selection)
        {
            case "1":
                _reference = new Reference("John", 3, 16);
                LoadWords("For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
                break;
            case "2":
                _reference = new Reference("Philippians", 4, 13);
                LoadWords("I can do all things through Christ which strengtheneth me.");
                break;
            case "3":
                _reference = new Reference("Proverbs", 3, 5);
                LoadWords("Trust in the Lord with all thine heart; and lean not unto thine own understanding.");
                break;
            case "4":
                _reference = new Reference("Genesis", 1, 1);
                LoadWords("In the beginning God created the heaven and the earth.");
                break;
            case "5":
                _reference = new Reference("Psalm", 23, 1);
                LoadWords("The Lord is my shepherd; I shall not want.");
                break;
            default:
                Console.WriteLine("Invalid selection. Returning to menu...");
                Console.ReadKey();
                return;
        }
        Memorize();
    }

    private void LoadWords(string text)
    {
        _words.Clear();
        string[] wordArray = text.Split(' ');

        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }
    

    private void Memorize()
    {
        bool running = true;

        while (running && !_words.All(w => w.IsHidden()))
        {
            Console.Clear();
            
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            
            foreach (Word word in _words)
            {
                word.DisplayText();
            }

            if (_words.All(w => w.IsHidden()))
            {
                Console.WriteLine("\nCongratulations! You have memorized the scripture.");
                break;
            }

            
            string input = Console.ReadLine().ToLower(); ;
            if (input == "quit")
            {
                break;
            }

            HideRandomWords(3);
        }
    }

    private void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].HideWord();
            visibleWords.RemoveAt(index);
        }
    }
        private void DisplayScripture()
        {
            Console.Clear();
            Console.WriteLine(_reference.GetReferenceString() + "\n");

            foreach (Word word in _words)
            {
                word.DisplayText();
            }
        }
}