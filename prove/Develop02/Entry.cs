class Entry
{
    public string _dt = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss: ");
    public string _givenPrompt;
    public string _userEntry;

    public string EntryString()
    {
        return _dt + "Prompt: " + _givenPrompt + ": " + _userEntry;
    }

    
}