using System;
using System.Collections.Generic;
using System.IO; // Needed for reading CSV files

class Program
{
    static void Main(string[] args)
    {
        Activity baseActivity = new Activity(0, "Relaxation Activity");
        baseActivity.DisplayWelcomeMessage();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Saved Results");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice (1–5): ");
            string choice = Console.ReadLine();

            if (choice == "5" || string.Equals(choice, "quit", StringComparison.OrdinalIgnoreCase))
            {
                running = false;
                continue;
            }

            Console.Clear();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter total time (in seconds): ");
                    int breathTime = int.Parse(Console.ReadLine());
                    BreathingActivity breathing = new BreathingActivity(breathTime, "Breathing Activity");
                    breathing.DisplayActivity(breathing.GetName(), breathing.GetCountDown());
                    breathing.StartBreathingSession();
                    break;

                case "2":
                    Console.Write("Enter total time (in seconds): ");
                    int reflectTime = int.Parse(Console.ReadLine());
                    ReflectingActivity reflecting = new ReflectingActivity(
                        new List<string> {
                            "Think of a time when you helped someone in need.",
                            "Think of a time when you accomplished something difficult.",
                            "Think of a time when you did something truly selfless.",
                            "Think of a time when you stood up for someone else."
                        },
                        new List<string> {
                            "Why was that experience meaningful to you?",
                            "What did you learn from it?",
                            "Have you ever done anything like this before?",
                            "What is your favorite thing about this experience?"

                        },
                        reflectTime, "Reflecting Activity"
                    );
                    reflecting.DisplayActivity(reflecting.GetName(), reflecting.GetCountDown());
                    reflecting.StartReflectionSession();
                    reflecting.SaveResultsToCsv("reflection_results.csv");
                    break;

                case "3":
                    Console.Write("Enter total time (in seconds): ");
                    int listTime = int.Parse(Console.ReadLine());
                    ListingActivity listing = new ListingActivity(
                        new List<string> {
                            "List things you are grateful for.",
                            "List people who have made a positive impact in your life."
                        },
                        listTime, "Listing Activity"
                    );
                    listing.DisplayActivity(listing.GetName(), listing.GetCountDown());
                    listing.DisplayPrompt(listing.GetRandomPrompt(listing.GetPrompts()));
                    listing.StartListingSession();
                    listing.SaveResultsToCsv("listing_results.csv");
                    break;

                case "4":
                    Console.WriteLine("\nWhich results would you like to view?");
                    Console.WriteLine("1. Reflection Results");
                    Console.WriteLine("2. Listing Results");
                    Console.Write("Enter choice: ");
                    string fileChoice = Console.ReadLine();

                    if (fileChoice == "1")
                        ViewSavedResults("reflection_results.csv");
                    else if (fileChoice == "2")
                        ViewSavedResults("listing_results.csv");
                    else
                        Console.WriteLine("Invalid choice.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number 1–5.");
                    break;
            }

            Console.WriteLine("\nPress Enter to return to the main menu...");
            Console.ReadLine();
            Console.Clear();
        }

        Console.WriteLine("Program ended. Goodbye!");
    }

    static void ViewSavedResults(string fileName)
    {
        Console.WriteLine($"\n=== Viewing: {fileName} ===\n");

        if (!File.Exists(fileName))
        {
            Console.WriteLine("No saved results found for this activity yet.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }

        Console.WriteLine("\n=== End of file ===");
    }
    // I added a saving function that kinda works
}
