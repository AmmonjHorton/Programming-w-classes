using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);
        bool keepGoing = true;
        while (keepGoing)
        {

            Console.WriteLine(number);
            Console.Write("Guess a number between 1 and 10 ");
            int guess = int.Parse(Console.ReadLine());
            if (guess > number)
                Console.WriteLine("Too high!");
            else if (guess < number)
                Console.WriteLine("Too low!");
            else if (guess == number)
            {
                Console.WriteLine("You guessed it!");
                keepGoing = false;
            }
        }
    }
}