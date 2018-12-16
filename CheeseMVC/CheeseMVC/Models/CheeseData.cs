using System;
using System.Collections.Generic;
using System.Linq;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
        //'static' availble to any code within this class
        //Class vars are usually capitalized and local vars are not
        static private List<Cheese> cheeseList = new List<Cheese>();

        // Get all cheeses
        public static List<Cheese> GetAll()
        {
            return cheeseList;
        }

        // Add cheese(s)
        public static void Add(Cheese newCheese)
        {
            cheeseList.Add(newCheese);
        }

        // Remove cheese(s)
        public static void Remove(int id)
        {
            Cheese removeCheese = GetById(id);
            cheeseList.Remove(removeCheese);
        }

        // GetById
        public static Cheese GetById(int id)
        {
            return cheeseList.Single(p => p.ID == id);
        }

    }
}
