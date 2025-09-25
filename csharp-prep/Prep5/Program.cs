using System;

class Program
{
    static void Main(string[] args)
    {
        static void Main()
        {
            DisplayMessage();
            string name = PromptUserName();
            int favNumber = PromptUserNumber();
            int squaredNumber = SquareNumber(favNumber);
            Console.Write("Enter your birth year: ");
            int birthYear = int.Parse(Console.ReadLine());
            int age = AgeThisYear(birthYear);
            DisplayResults(name, favNumber, squaredNumber, age);

        }

        static void DisplayResults(string name, int favNumber, int squaredNumber, int age)
        {
            Console.WriteLine($"Hello, {name}!");
            Console.WriteLine($"Your favorite number is {favNumber} and its square is {squaredNumber}.");
            Console.WriteLine($"You are {age} years old this year.");
        }


        static void DisplayMessage()
        {
            Console.WriteLine("Welcomme to the program!");
        }
        
        static string PromptUserName()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Enter your favorite number: ");
            int favNumber = int.Parse(Console.ReadLine());
        return favNumber;
        }

        static int SquareNumber(int number)
        {
            return number * number;
        }
        static int AgeThisYear(int birthYear)
        {
            Console.Write("Enter your birth year: ");
            int age = 2025 - birthYear;
            return age;
        }

        
        Main();
    }
}