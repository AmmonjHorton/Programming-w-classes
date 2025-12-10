using System;

class Program
{
    static void Main(string[] args)
    {
        Amalgam player = new Amalgam();

        while;

        Console.WriteLine("Hello! Welcome to the world of Amalgamon!");
        Console.WriteLine("1. Create Amalgamon");
        Console.WriteLine("2. Save Amalgamon");
        Console.WriteLine("3. Load Amalgamon");
        Console.WriteLine("4. Fight");
        Console.WriteLine("5. Quit");
        Console.Write("Please select an option 1-5: ");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            // Code to create Amalgamon
            Console.WriteLine("Creating Amalgamon...");
            Console.WriteLine("Select a body part to add:");
            Console.WriteLine("1. Hands");
            Console.WriteLine("2. Tail");
            Console.WriteLine("3. Legs");
            Console.WriteLine("4. Torso");
            Console.WriteLine("5. Arms");
            Console.WriteLine("6. Head");
            Console.WriteLine("7. Mouth");
            Console.WriteLine("8. Ears");

        }
        else if (choice == "2")
        {
            // Code to save Amalgamon
            Console.WriteLine("Saving Amalgamon...");
        }
        else if (choice == "3")
        {
            // Code to load Amalgamon
            Console.WriteLine("Loading Amalgamon...");
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
        }
    }
}