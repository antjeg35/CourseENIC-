using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP2Module5BOLesPizzas;
using TP2Module5LesPizzas.Models;

namespace TP2Module5LesPizzas.Controllers
{
    public class PizzaController : Controller
    {
        TP2Module5BOLesPizzas.Utils.FakeDbPizza dataInstance = TP2Module5BOLesPizzas.Utils.FakeDbPizza.Instance;

        private Pizza savePizza(PizzaVM pizzaVM)
        {
            List<Ingredient> Ingredients = new List<Ingredient>();
            foreach (int id in pizzaVM.IdSelectionIngredients)
            {
                Ingredient ingredient = dataInstance.listeIngredients.Find(i => i.Id == id);
                Ingredients.Add(ingredient);
            }

            Pizza pizza = new Pizza
            {
                Id = dataInstance.listePizzas.Count,
                Nom = pizzaVM.Pizza.Nom,
                Pate = dataInstance.listePates.FirstOrDefault(pate => pate.Id == pizzaVM.IdPate),
                Ingredients = Ingredients
            };
            return pizza;         
        }
        
        // GET: Pizza
        public ActionResult Index()
        {
            List<Pizza>listePizzas = dataInstance.listePizzas;
           
            return View(listePizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizza = dataInstance.listePizzas.FirstOrDefault(x => x.Id == id);
            if (pizza != null)
            {
                return View(pizza);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaVM pizzaVM = new PizzaVM();
            pizzaVM.Ingredients = dataInstance.listeIngredients.ToList();
            pizzaVM.Pates = dataInstance.listePates.ToList();

            return View(pizzaVM);
            
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaVM pizzaVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (dataInstance.listePizzas.Any(p => p.Nom.ToUpper() == pizzaVM.Pizza.Nom.ToUpper()))
                    {
                        ModelState.AddModelError("", "Il existe déjà une pizza portant ce nom");
                        pizzaVM.Ingredients = dataInstance.listeIngredients.ToList();
                        pizzaVM.Pates = dataInstance.listePates.ToList();
                        return View(pizzaVM);
                    }
                    dataInstance.listePizzas.Add(savePizza(pizzaVM));
                    return RedirectToAction("Index");
                    
                }
                pizzaVM.Ingredients = dataInstance.listeIngredients.ToList();
                pizzaVM.Pates = dataInstance.listePates.ToList();
                return View(pizzaVM);
            }
            catch
            {
                pizzaVM.Ingredients = dataInstance.listeIngredients.ToList();
                pizzaVM.Pates = dataInstance.listePates.ToList();
                return View(pizzaVM);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            
                Pizza pizzaEdit = dataInstance.listePizzas.FirstOrDefault(p => p.Id == id);
                PizzaVM pizzaVM = new PizzaVM();
                pizzaVM.Pizza = pizzaEdit;
                pizzaVM.Ingredients = dataInstance.listeIngredients.ToList();
                pizzaVM.Pates = dataInstance.listePates.ToList();

                return View(pizzaVM);
        }
        
        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaVM pizzaVM)
        {
                try
                {
                     /* int indexPizza = dataInstance.listePizzas.FindIndex(index => index.Equals(pizza.Id));*/
                    dataInstance.listePizzas[pizzaVM.Pizza.Id] = savePizza(pizzaVM);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View();
                }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = dataInstance.listePizzas.FirstOrDefault(x => x.Id == id);
            if (pizza != null)
            {
                return View(pizza);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = dataInstance.listePizzas.FirstOrDefault(x => x.Id == id);
                dataInstance.listePizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
