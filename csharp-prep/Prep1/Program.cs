using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.Write($"What is your name? ");
        // string name = Console.ReadLine();
        // Console.Write($"What is your last name? ");
        // string lastName = Console.ReadLine();
        // Console.WriteLine($"Hello {name} {lastName}!");

        
        Console.Write($"What is your grade percentage? ");
        string input = Console.ReadLine();
        double percentage = double.Parse(input);
        
        if (percentage >= 90)
        {
            Console.WriteLine($"You have an A.");
        }
        else if (percentage >= 80)
        {
            Console.WriteLine($"You have a B.");
        }
        else if (percentage >= 70)
        {
            Console.WriteLine($"You have a C.");
        }
        else if (percentage >= 60)
        {
            Console.WriteLine($"You have a D.");
        }
        else
        {
            Console.WriteLine($"You have an F.");
        }

    }
}