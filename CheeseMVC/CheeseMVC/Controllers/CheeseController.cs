using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;


namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        //why this
        static private string error = "";

        //Home page with list of all cheeses
        public IActionResult Index()
        {
            //Links the foreach loop in the template to this list
            ViewBag.Cheeses = CheeseData.GetAll();
            error = "";

            return View();
        }

        //Go to add form
        public IActionResult Add()
        {
            ViewBag.AddError = error;
            return View();
        }

        //Add new cheese from form data
        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(Cheese newCheese)
        {
            error = "";

            //check for empty name
            if(!string.IsNullOrEmpty(newCheese.Name))
            {

                CheeseData.Add(newCheese);
            }

            //if empty throw error
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

        //Delete cheese from form data
        [HttpPost]
        [Route("/Cheese/Delete")]
        public IActionResult DelCheese(int[] cheeseIds)
        {
            //checkbox returns int array, iterate thru array
            foreach (int anId in cheeseIds)
            {
                //delete where cheeseId matches current ID from loop
                CheeseData.Remove(anId);
            }
        
            return Redirect("/Cheese");
        }

        //Go to edit form
        public IActionResult Edit(int cheeseId)
        {
            ViewBag.editCheese = CheeseData.GetById(cheeseId);
            return View();
        }

        //Edit cheese from form data
        [HttpPost]
        public IActionResult Edit(int cheeseId, string name, string description)
        {
            Cheese editCheese = CheeseData.GetById(cheeseId);

            editCheese.Name = name;
            editCheese.Description = description;

                       
            return Redirect("/Cheese");
        }
    }
}
