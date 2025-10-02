using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2020;
        job1._endYear = 2023;

        Job job2 = new Job();
        job2._jobTitle = "Web Developer";
        job2._company = "Google";
        job2._startYear = 2023;
        job2._endYear = 2025;

        job1.Display();
        job2.Display();

        Resume myResume = new Resume();
        myResume._name = "John Doe";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();
    }
}


    