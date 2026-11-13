// Exceeded requirements: the program now randomly selects only from words
// that are not yet hidden, so every Enter press hides new words.
using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "Because God He loved the world so much that he gave his one and only Son. The only begotten Son, that whoever believes in him shall not perish but have eternal life.");
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press enter to continue or type 'quit' to finish.");
            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}