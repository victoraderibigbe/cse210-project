using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        double grade = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine();
        string letter = "";
        string sign = "";

        if (grade >= 90)
        {
            letter = "A";
            if (grade % 10 < 3)
            {
                sign = "-";
            }
        }
        else if (grade >= 80)
        {
            letter = "B";
            if (grade % 10 >= 7)
            {
                sign = "+";
            }
            else if (grade % 10 < 3)
            {
                sign = "-";
            }
        }
        else if (grade >= 70)
        {
            letter = "C";
            if (grade % 10 >= 7)
            {
                sign = "+";
            }
            else if (grade % 10 < 3)
            {
                sign = "-";
            }
        }
        else if (grade >= 60)
        {
            letter = "D";
            if (grade % 10 >= 7)
            {
                sign = "+";
            }
            else if (grade % 10 < 3)
            {
                sign = "-";
            }
        }
        else if (grade < 60)
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is {letter}{sign}");

        Console.WriteLine();
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You have an exceptional grade");
        }
        else
        {
            Console.WriteLine("Keep working hard, you can do better next time!");
        }
    }
}