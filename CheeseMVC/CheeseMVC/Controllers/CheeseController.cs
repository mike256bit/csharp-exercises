using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        //Home page with list of all cheeses
        public IActionResult Index()
        {
            //Links the foreach loop in the template to this list using a simple Viewmodel
            List<Cheese> Cheeses = CheeseData.GetAll();
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
                addCheeseViewModel.CreateCheese();

                return Redirect("/Cheese");
            }

            //If not valid, rerender:
            return View(addCheeseViewModel);
        }

        //Go to edit form
        public IActionResult Edit(int cheeseId)
        {
            EditCheeseViewModel editCheeseViewModel = new EditCheeseViewModel
            {
                CheeseId = cheeseId,
                Name = CheeseData.GetById(cheeseId).Name,
                Description = CheeseData.GetById(cheeseId).Description,
                Type = CheeseData.GetById(cheeseId).Type,
                Rating = CheeseData.GetById(cheeseId).Rating
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
                var editCheese = CheeseData.GetById(editCheeseViewModel.CheeseId);

                editCheese.Name = editCheeseViewModel.Name;
                editCheese.Description = editCheeseViewModel.Description;
                editCheese.Type = editCheeseViewModel.Type;
                editCheese.Rating = editCheeseViewModel.Rating;

                return Redirect("/Cheese");
            }

            //If not valid, rerender:
            return View(editCheeseViewModel);
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


    }
}
