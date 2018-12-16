using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        //Introduce DbContext to reference
        //Private field "context" of type CheeseDbContext
        private CheeseDbContext context;

        //Based on code added to startup, "request" dbContext via constructor
        public CheeseController(CheeseDbContext dbContext)
        {
            //set private field to passed-in dbContext, Framework will create the controller
            context = dbContext;
        }


        //Home page with list of all cheeses
        public IActionResult Index()
        {
            //Links the foreach loop in the template to this list using a simple Viewmodel
            //Cheeses property of coxtext is a DbSet which will hold on to Cheese objects
            List<Cheese> Cheeses = context.Cheeses.ToList();
            return View(Cheeses);
        }

        //Go to add form
        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        //Add new cheese from form data
        [HttpPost]
        //[Route("/Cheese/Add")] if action is a diff name
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            //if ViewModel data validates:
            if (ModelState.IsValid)
            {
                //addCheeseViewModel.CreateCheese();
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type,
                    Rating = addCheeseViewModel.Rating
                };

                //Add and Save are part of the DbSet class
                context.Cheeses.Add(newCheese);
                context.SaveChanges();

                return Redirect("/Cheese");
            }

            //If not valid, rerender:
            return View(addCheeseViewModel);
        }

        //Go to edit form
        public IActionResult Edit(int cheeseId)
        {
            Cheese editCheese = context.Cheeses.Single(p => p.ID == cheeseId);

            EditCheeseViewModel editCheeseViewModel = new EditCheeseViewModel
            {
                CheeseId = editCheese.ID,
                Name = editCheese.Name,
                Description = editCheese.Description,
                Type = editCheese.Type,
                Rating = editCheese.Rating
            };

            return View(editCheeseViewModel);
        }

        //Edit cheese from form data
        [HttpPost]
        public IActionResult Edit(EditCheeseViewModel editCheeseViewModel)
        {
            //if ViewModel data validates:
            if (ModelState.IsValid)
            {
                var editCheese = context.Cheeses.Single(p => p.ID == editCheeseViewModel.CheeseId);

                editCheese.Name = editCheeseViewModel.Name;
                editCheese.Description = editCheeseViewModel.Description;
                editCheese.Type = editCheeseViewModel.Type;
                editCheese.Rating = editCheeseViewModel.Rating;

                context.SaveChanges();

                return Redirect("/Cheese");
            }

            //If not valid, rerender:
            return View(editCheeseViewModel);
        }
    
        //Go to delete form
        public IActionResult Delete()
        {
            ViewBag.Cheeses = context.Cheeses.ToList();
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
                //CheeseData.Remove(anId);

                //retreive from DbContext
                Cheese theCheese = context.Cheeses.Single(p => p.ID == anId);
                //Remove object
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();
        
            return Redirect("/Cheese");
        }


    }
}
