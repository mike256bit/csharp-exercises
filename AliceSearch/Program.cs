using System;

namespace AliceSearch
{
    class Program
    {
        static void Main(string[] args)
        {

            string alice = "Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice she had peeped into the book her sister was reading, but it had no pictures or conversations in it, 'and what is the use of a book,' thought Alice 'without pictures or conversation?'";

            alice = alice.ToLower();

            Console.WriteLine("Enter a search string:");
            string input = Console.ReadLine();

            input = input.ToLower();
            //Console.WriteLine(input);

            if(alice.IndexOf(input) < 0)
            {
                Console.WriteLine("\nSearch string not found.");
            }
            else
            {
                Console.WriteLine("\nTrue.");
            }

            Console.ReadLine();

        }
    }
}
