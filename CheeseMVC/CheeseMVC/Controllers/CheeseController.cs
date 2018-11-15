using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        //'static' availble to any code within this class
        //Class vars are usually capitalized and local vars are not
        static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();
        static private string error = "";

        // GET: /<controller>/
        public IActionResult Index()
        {

            //Links the foreach loop in the template to this list
            ViewBag.Cheeses = Cheeses;
            error = "";

            return View();
        }

        public IActionResult Add()
        {
            ViewBag.AddError = error;
            return View();
        }

        //Go to delete form
        public IActionResult Delete()
        {
            ViewBag.Cheeses = Cheeses;
            return View();
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult NewCheese(string name, string desc)
        {
            error = "";

            if (string.IsNullOrEmpty(desc))
            {
                desc = "(none)";
            }

            if(!string.IsNullOrEmpty(name))
            {
                Cheeses[name] = desc;
            }
            else
            {
                error = "Something went wrong. Please try again.";
                return Redirect("/Cheese/Add");
            }

            //Send user back to /Cheese/Index
            return Redirect("/Cheese");
        }

        [HttpPost]
        [Route("/Cheese/Delete")]
        public IActionResult DelCheese(string[] name)
        {
            int i = 0;
            while (i < name.Count())
            {
                Cheeses.Remove(name[i]);
                i++;
            }

            return Redirect("/Cheese");
        }
    }
}
