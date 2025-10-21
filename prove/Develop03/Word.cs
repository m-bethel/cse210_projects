class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }

    public void HideWord()
    {
        _hidden = true;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public void DisplayText()
    {
        if (_hidden)
        {
            Console.Write(new string('_', _word.Length) + " ");
        }
        else
        {
            Console.Write(_word + " ");
        }
    }
}