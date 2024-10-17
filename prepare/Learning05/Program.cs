using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Victor Aderibigbe", "The Evolution of Modern Technology Over the Years");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLine();

        MathAssignment a2 = new MathAssignment("John Victory", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeWorkList());
        Console.WriteLine();

        WritingAssignment a3 = new WritingAssignment("Mary Rose", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}