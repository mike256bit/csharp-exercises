using System;

namespace RectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            float SideA;
            float SideB;
            string input;
            float RectArea;

            Console.WriteLine("How long is side A?");
            input = Console.ReadLine();
            SideA = float.Parse(input);
            Console.WriteLine("\nHow long is side B?");
            input = Console.ReadLine();
            SideB = float.Parse(input);

            RectArea = SideA * SideB;

            Console.WriteLine("\nYou entered " + SideA.ToString() + " units for side A and "
                + SideB.ToString() + " units for side B.");
            Console.WriteLine("\nThe area of the rectangle is " + RectArea.ToString() + " units squared");
            Console.ReadLine();

            
        }
    }
}
