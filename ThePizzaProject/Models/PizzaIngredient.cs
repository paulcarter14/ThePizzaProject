﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePizzaProject.Models
{
    public class PizzaIngredient
    {
        [Key]
        public int PizzaIngredientID { get; set; }
        public int PizzaID { get; set; }
        public int IngredientID { get; set; }
        public Pizza Pizza { get; set; }
        public Ingredient Ingredients { get; set; }

    }
}
