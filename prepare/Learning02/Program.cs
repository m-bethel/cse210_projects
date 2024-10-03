using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Intel";
        job1._jobtitle = "Principal Investigator";
        job1._startYear = 2025;
        job1._endYear = 2027;

        

        Job job2 = new Job();
        job2._company = "INL";
        job2._jobtitle= "Reactor Operator";
        job2._startYear = 2028;
        job2._endYear = 2035;

        

        Resume myResume = new Resume();
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}