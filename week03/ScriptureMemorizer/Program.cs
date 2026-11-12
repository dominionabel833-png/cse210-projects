using System;

class Program
{
    static void Main(string[] args)
    {
        // -------------------------------------------------------------
        // EXCEEDING REQUIREMENTS:
        // To exceed core requirements and ensure smooth gameplay, this program 
        // uses a smart random selection algorithm. Instead of picking completely 
        // random words (which can waste turns on words that are already hidden), 
        // it filters the list to select only from currently visible words. 
        // This guarantees steady, efficient progress toward completely hiding the scripture.
        // -------------------------------------------------------------

        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding";
        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        while (userInput != "quit")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Check if all words are hidden before prompting
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Great job memorizing!");
                break;
            }

            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();

            if (userInput.Trim().ToLower() == "quit")
            {
                break;
            }


            scripture.HideRandomWords(3);
        }
    }
}