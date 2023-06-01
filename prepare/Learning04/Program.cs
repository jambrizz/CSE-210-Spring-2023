using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Assignment assignment1 = new Assignment();
        assignment1.SetStudentName("John");
        assignment1.SetTopic("Math");
        Console.WriteLine(assignment1.GetSummary() + "\n");
        
        MathAssignment Assignment2 = new MathAssignment();
        Assignment2.SetStudentName("Roberto Rodriguez");
        Assignment2.SetTopic("Algebra");
        Assignment2.SetMathAssignment("Chapter 2", "1-10");
        Console.WriteLine(Assignment2.GetSummary());
        Console.WriteLine(Assignment2.GetHomeworkList() + "\n");

        WritingAssignment assignment3 = new WritingAssignment();
        assignment3.SetStudentName("Mary Waters");
        assignment3.SetTopic("European History");
        assignment3.SetWritingAssignment("The Causes of World War II");
        Console.WriteLine(assignment3.GetWritingAssignment());
    }
}