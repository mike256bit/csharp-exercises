/*
 ViewModel notes:
    Model class specifically used in a View
    Specifically ties a Model to a Specific view
    Provides validation and strongly typed data (good for compiler)
*/

using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CheeseMVC.ViewModels
{
    //represents all of the data related to "add" View; bridge model and view
    public class AddCheeseViewModel
    {
        [Required] //forces Name field to be populated
        [Display (Name = "Cheese Name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please describe your cheese.")]
        public string Description { get; set; }

        [Range(1, 5)]
        [Display (Name = "Rating")]
        public int Rating { get; set; }

        //user-selected option
        public CheeseType Type { get; set; }

        //options for users to select from
        public List<SelectListItem> CheeseTypes { get; set; }

        public AddCheeseViewModel()
        {
            CheeseTypes = new List<SelectListItem>();

            CheeseTypes.Add(new SelectListItem {
                Value = ((int)CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Spreadable).ToString(),
                Text = CheeseType.Spreadable.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Processed).ToString(),
                Text = CheeseType.Processed.ToString()
            });
        }

        public void CreateCheese()
        {
            Cheese newCheese = new Cheese
            {
                Name = Name,
                Description = Description,
                Type = Type,
                Rating = Rating
            };

            CheeseData.Add(newCheese);
        }
        
    }
}
