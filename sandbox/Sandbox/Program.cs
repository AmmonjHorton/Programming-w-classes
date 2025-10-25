using System;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture();

        while (true)
        {
            Console.Clear(); // clears the console so it redraws cleanly
            scripture.DisplayScripture();

            Console.WriteLine("Press ENTER to hide a word, or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
        }

        Console.WriteLine("All done! Great job memorizing!");
    }
}
