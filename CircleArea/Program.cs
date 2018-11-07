using System;

namespace CircleArea
{
    class Program
    {
        static void Main(string[] args)
        {

            float radius = -1;
            string input;

            do
            {
                do
                {
                    Console.WriteLine("What is the radius of the circle?");
                    input = Console.ReadLine();

                    if (input == "")
                    {
                        Console.WriteLine("\nPlease enter a number. Press enter to try again.");
                        Console.ReadLine();
                    }
                } while (input == "");

                radius = float.Parse(input);

                if (radius < 0)
                {
                    Console.WriteLine("\nRadius must be a positive number. Press enter to try again.");
                    Console.ReadLine();
                }
                else
                {
                    double area = radius * radius * 3.1415;
                    Console.WriteLine("\nThe area of a circle with radius " + radius.ToString() + " is " + area.ToString() + ".");
                    Console.WriteLine("\nPress enter to exit.");
                    Console.ReadLine();
                }
            } while (radius < 0);
        }
    }
}
