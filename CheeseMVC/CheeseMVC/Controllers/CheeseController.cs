using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        
        static private string error = "";

        // GET: /<controller>/
        public IActionResult Index()
        {
            //Links the foreach loop in the template to this list
            ViewBag.Cheeses = CheeseData.GetAll();
            error = "";

            return View();
        }

        public IActionResult Add()
        {
            ViewBag.AddError = error;
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string desc = "(none)")
        {
            error = "";


            if(!string.IsNullOrEmpty(name))
            {
                //Figure out how to create a new instance based on the string name of the cheese. 
                //look at activator.createinstance. you'll need it some day. 

                CheeseData.Add(new Cheese(name, desc));

            }

            else
            {
                error = "Something went wrong. Please try again.";
                return Redirect("/Cheese/Add");
            }

            //Send user back to /Cheese/Index
            return Redirect("/Cheese");
        }

        //Go to delete form
        public IActionResult Delete()
        {
            ViewBag.Cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Delete")]
        public IActionResult DelCheese(int[] cheeseIds)
        {
            //int delCheese = 0;

            //change the cheese class to include a unique integer ID, starting at 0, and just use that as the index pos. 
            //foreach (int anId in cheeseIds) 
            //{
            //    foreach (Cheese aCheese in cheeseList)
            //    {
            //        if (aCheese.Name == aName)
            //        {
            //            delCheese = cheeseList.IndexOf(aCheese);
            //        }
            //    }

            //    cheeseList.RemoveAt(delCheese);
            //}

            foreach (int anId in cheeseIds)
            {
                CheeseData.Remove(anId);
            }
        
            return Redirect("/Cheese");
        }
    }
}
