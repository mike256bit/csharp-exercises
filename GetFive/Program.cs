using System;
using System.Collections.Generic;
using System.Linq;

namespace GetFive
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> wordList = new List<string>(){"junky", "crumb", "wednesday", "yellow", "jazzy", "test", "tester", "funny", "Tuesday"};
            Printer.PrintWord(wordList, 5);
        }
    }

    public class Printer
    {
        public static void PrintWord(List<string> wordList, int i)
        {
            foreach(string word in wordList)
            {
                if (word.Length == i)
                {
                    Console.WriteLine(word);
                }
            }
            Console.ReadLine();
        }
    }
}
