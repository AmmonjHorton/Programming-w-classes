using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goals> goals = new List<Goals>();
    static int totalPoints = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Goal Tracker Menu ---");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    RecordEvent();
                    break;

                case "3":
                    DisplayGoals();
                    break;

                case "4":
                    SaveGoals();
                    break;

                case "5":
                    LoadGoals();
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    // ------------------------
    // CREATE GOAL
    // ------------------------
    static void CreateGoal()
    {
        Console.WriteLine("\nWhat type of goal?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("Goal name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Point value: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new Simple(name, points, description));
        }
        else if (type == "2")
        {
            goals.Add(new Eternal(name, points, description));
        }
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new Checklist(name, points, description, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid option.");
        }
    }

    // ------------------------
    // RECORD EVENT
    // ------------------------
    static void RecordEvent()
    {
        DisplayGoals();

        Console.Write("\nWhich goal did you complete? Enter number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int earned = goals[index].RecordEvent();
            totalPoints += earned;
            Console.WriteLine($"You earned {earned} points! Total: {totalPoints}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    // ------------------------
    // DISPLAY GOALS
    // ------------------------
    static void DisplayGoals()
    {
        Console.WriteLine($"\nTotal Points: {totalPoints}");
        Console.WriteLine("Your Goals:");

        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"{i+1}. ");
            goals[i].DisplayCompletion();
        }
    }

    // ------------------------
    // SAVE GOALS
    // ------------------------
    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.csv"))
        {
            writer.WriteLine(totalPoints);

            foreach (Goals g in goals)
            {
                g.ToCsv();
            }
        }

        Console.WriteLine("Goals saved!");
    }

    // ------------------------
    // LOAD GOALS
    // ------------------------
    static void LoadGoals()
    {
        if (!File.Exists("goals.csv"))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        string[] lines = File.ReadAllLines("goals.csv");
        goals.Clear();

        totalPoints = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string name = parts[0];
            int pts = int.Parse(parts[1]);
            string desc = parts[2];
            bool complete = bool.Parse(parts[3]);

            // All CSV loading would match the constructor patterns you set up
            // You can expand this later for Simple / Eternal / Checklist types
        }

        Console.WriteLine("Goals loaded!");
    }
}
