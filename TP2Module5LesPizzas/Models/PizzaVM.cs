using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
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

        [Required(ErrorMessage = "- Selectionner une pâte -")]
        [IntegerValidator(MinValue = 1)]
        public int IdPate { get; set; }

        [Required]
        [ListValidation(ErrorMessage = "Une pizza doit avoir entre 2 et 5 ingrédients")]
        public List<int> IdSelectionIngredients { get; set; } = new List<int>();
    }
}