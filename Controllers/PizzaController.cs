using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        PizzeriaDbContext db;

        public PizzaController() : base ()
        {
            db = new PizzeriaDbContext();
        }

        public IActionResult Index()
        {
            
            List<Pizza> listaPizze = db.Pizze.ToList();


            return View(listaPizze);
        }

        public IActionResult Detail(int id)
        {
            PizzeriaDbContext db = new PizzeriaDbContext();

            Pizza pizza = db.Pizze.Where(p => p.PizzaId == id).FirstOrDefault();
            return View(pizza);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            db.Pizze.Add(pizza);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
