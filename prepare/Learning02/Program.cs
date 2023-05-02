using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2015;
        job1._endYear = 2017;

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer II";
        job2._company = "Oracle";
        job2._startYear = 2017;
        job2._endYear = 2019;

        Job job3 = new Job();
        job3._jobTitle = "Software Engineer III";
        job3._company = "Adobe";
        job3._startYear = 2019;
        job3._endYear = 2023;

        Resume resume = new Resume();
        resume._name = "Anthony Garcia";
        resume._jobs = new List<Job>();
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume._jobs.Add(job3);

        resume.Display();
        
    }
}