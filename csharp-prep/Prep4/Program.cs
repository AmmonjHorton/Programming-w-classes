using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter any integer onto the list (0 to stop): ");
        List<int> numbers = new List<int>();
        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            if (number != 0)
                numbers.Add(number);
            else
            {
                Console.WriteLine($"The sum is {numbers.Sum()}");
                Console.WriteLine($"The average is {numbers.Average()}");
                Console.WriteLine($"The largest number is {numbers.Max()}");
                Console.WriteLine($"The smallest number is {numbers.Min()}");
                Console.WriteLine("The numbers in order are: ");
                numbers.Sort();
                foreach (int num in numbers)
                    Console.WriteLine(num);
                break;
            }
        }
    }
}