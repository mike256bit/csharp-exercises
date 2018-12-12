using System;
using System.Linq;
using System.Collections.Generic;


namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Restaurant!");
            Console.ReadLine();
        }

        public class Menu
        {
            public string MenuName { get; set; } //menu name, e.g. "kids' menu", "over 55 crowd", "beef"
            public List<string> MenuFoodCategory { get; set; } //menu types included in menu pork, beef, etc
            public double MenuValue { get; set; }//price max? like, it's a dollar menu or something
            public List<MenuItem> MenuContains { get; set; }//list of MenuItem objects in menu
        }

        public class MenuItem
        {
            public string ItemName { get; set; }
            public double ItemPrice { get; set; }
            public bool NewItem { get; set; }
            public string ItemCategory { get; set; }
            public string FoodCategory { get; set; }


        }
    }
}
