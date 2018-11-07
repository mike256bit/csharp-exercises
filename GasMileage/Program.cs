using System;

namespace GasMileage
{
    class Program
    {
        static void Main(string[] args)
        {

            int miles;
            float gallons;
            double perGallon;

            string input;

            Console.WriteLine("How many miles have you driven?");
            input = Console.ReadLine();
            miles = int.Parse(input);

            Console.WriteLine("\nHow many gallons of gas have you used?");
            input = Console.ReadLine();
            gallons = float.Parse(input);

            perGallon = miles / gallons;


            Console.WriteLine("\nYour gas mileage is " + perGallon.ToString() + " miles per gallon.");
            Console.ReadLine();
        }
    }
}
