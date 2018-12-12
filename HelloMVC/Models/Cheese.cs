﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Cheese(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
