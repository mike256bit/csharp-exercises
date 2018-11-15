using System;
using System.Collections.Generic;

namespace CountingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            //string testString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc accumsan sem ut ligula scelerisque sollicitudin. Ut at sagittis augue. Praesent quis rhoncus justo. Aliquam erat volutpat. Donec sit amet suscipit metus, non lobortis massa. Vestibulum augue ex, dapibus ac suscipit vel, volutpat eget massa. Donec nec velit non ligula efficitur luctus.";

            string testString = "";

            do
            {
                Console.WriteLine("\nEnter a string to generate a list of alphanumeric characters present (press ENTER to quit):");
                testString = Console.ReadLine();
                testString = testString.ToLower();

                string alphas = "abcdefghijklmnopqrstuvwxyz";

                Dictionary<char, int> CharDict = new Dictionary<char, int>();

                //loop through the string character by character
                //for each character, check to see if in dictionary
                //if no, add char as key with instance as value (1)
                //if yes, get value, add 1 and update dictionary

                foreach (char c in testString)
                {
                    if (CharDict.ContainsKey(c) && alphas.Contains(c))
                    {
                        //Console.WriteLine(CharDict[c]);
                        CharDict[c] = (CharDict[c] + 1);
                    }
                    else if (alphas.Contains(c))
                    {
                        CharDict[c] = 1;
                    }

                }

                foreach (KeyValuePair<char, int> character in CharDict)
                {
                    Console.WriteLine(string.Format("{0}: {1}", character.Key, character.Value));
                }
            } while (testString != "");

            //Console.ReadLine();
        }
    }
}
