public class Job
{
    public string _company  = "";
    public string _jobtitle = "";
    public int _startYear = 2024;
    public int  _endYear = 2027;

    public void Display()
    {
        Console.WriteLine($"{_jobtitle} ({_company}) {_startYear} - {_endYear}");
    }
}
