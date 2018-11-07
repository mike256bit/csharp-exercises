using System;

namespace WorkingWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //escape characters in literal strings
            //string myString = "My \"so-called\" life";

            //escape char for new line
            //string myString = "A new line.\nHere it is.";

            //escaping a backslash (use another \)
            //string myString = "Go to C:\\ drive";
            //string myString = @"Go to C:\ drive";

            //Replacement code with String.Format
            //string myString = string.Format("{0} = {1}", "First", "Second");

            //Currency formatting
            //string myString = string.Format("{0:C}", 123.45);

            //Decimal and commas
            //string myString = string.Format("{0:N}", 1234567);

            //Percentages
            //string myString = string.Format("{0:P}", .234);

            //Custom formatting
            //string myString = string.Format("{0:(###) ###-####}", 1234567890);

            string myString = " A lame song lyrics for bro  ";
            //Start at inx a and grab everything after until b
            myString = myString.Substring(6, 10);

            Console.WriteLine(myString);
            Console.ReadLine();
        }
    }
}
