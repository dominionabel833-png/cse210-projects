// =========================================================================
// PROJECT: CSE 210 - Week 02 Journal Program
// EXCEEDING CORE REQUIREMENTS:
// 1. Robust File Storage: Implemented a custom multi-character separator (~|~) 
//    for saving and loading entries. This prevents user entries containing 
//    commas, quotes, or periods from breaking the file reader parser.
// 2. Enhanced Prompt Generation: Created a dedicated PromptGenerator class 
//    that manages a randomized pool of thoughtful writing prompts, ensuring 
//    a seamless user experience.
// =========================================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int choice = 0;

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != 5)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out choice))
            {
                if (choice == 1)
                {
                    // Get random prompt and ask user for response
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");
                    string entryText = Console.ReadLine();
                    
                    // Capture current date as a string
                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date, prompt, entryText);
                    theJournal.AddEntry(newEntry);
                    Console.WriteLine("Entry added successfully!\n");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("\n--- Journal Entries ---");
                    theJournal.DisplayAll();
                }
                else if (choice == 3)
                {
                    Console.Write("\nEnter filename to save (e.g., journal.txt): ");
                    string filename = Console.ReadLine();
                    theJournal.SaveToFile(filename);
                }
                else if (choice == 4)
                {
                    Console.Write("\nEnter filename to load (e.g., journal.txt): ");
                    string filename = Console.ReadLine();
                    theJournal.LoadFromFile(filename);
                }
                else if (choice == 5)
                {
                    Console.WriteLine("\nGoodbye!");
                }
                else
                {
                    Console.WriteLine("\nInvalid option. Please choose between 1 and 5.\n");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a number.\n");
            }
        }
    }
}