using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Job
{
 public string _company;

 public string _jobTitle;

 public int _startYear;

 public int _endYear;

 public void Display()
 {
    Console.WriteLine($"{_jobTitle} ({_company}) {_startYear} - {_endYear} ");
 }

}