using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TP2Module5BOLesPizzas;

namespace TP2Module5LesPizzas.Models
{
    public class ListValidation : ValidationAttribute
    {
        public override bool IsValid (object value)
        {
            var list = value as IList;
            bool valid = false;
            if (list.Count >= 2 && list.Count <= 5)
            {
                valid = true;
                return valid;
            }
            else
            {
                valid = false;
                return valid;
            }
            /*
            var list = value as list;
            return  list.Count() >= 2 && list.Count() <= 5
                ? new ValidationResult("Une pizza doit avoir entre 2 et 5 ingrédients")
                : ValidationResult.Success;*/
        }
    }
}