using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] x = { 0, 1, 4, 2, 2, 5, 7, 6, 5, 3, 4, 11, 5 };
            List<int> numList = new List<int>(x);

            int sumOfEvens = GetSum.Sumator(numList);

            Console.Write(string.Format("Numbers in the list: {0}", numList[0]));
            for(int i = 1; i < numList.Count(); i++)
            {
                Console.Write(string.Format(", {0}", numList[i]));
            }
            Console.WriteLine(String.Format("\nSum of the even numbers: {0}", sumOfEvens));
            Console.ReadLine();
        }
    }

    public class GetSum
    {
        public static int Sumator(List<int> numList)
        {
            int evenSum = 0;

            foreach (int i in numList)
            {
                if (i % 2 == 0)
                {
                    evenSum += i;
                }
            }
            return evenSum;
        }
    }
}
