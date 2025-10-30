using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
    Assignment homework = new Assignment("Multiplication", "Ammon Horton");
    MathAssignment maths = new MathAssignment("Ammon Horton", "Multiplication", "8.13", "8-19");
     WritingAssignment waters = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");




    Console.WriteLine(homework.GetSumary());
    Console.WriteLine(maths.GetSumary());
    Console.WriteLine(maths.GetHomeworkList());
    Console.WriteLine(waters.GetSumary());
    Console.WriteLine(waters.GetWritingInformation());
    
    }
}