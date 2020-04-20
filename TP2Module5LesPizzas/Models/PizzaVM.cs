using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2Module5BOLesPizzas;

namespace TP2Module5LesPizzas.Models
{
    public class PizzaVM
    {
        public Pizza Pizza{ get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Pate> Pates { get; set; } = new List<Pate>();

        public int IdPate { get; set; }
        public List<int> IdSelectionIngredients { get; set; } = new List<int>();
    }
}