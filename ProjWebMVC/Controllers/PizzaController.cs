using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjWebMVC.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            var lst = Crud().Select();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pizza pizza)
        {
            if (ModelState.IsValid) //se o objeto for != de null
            {
                Crud().Insert(pizza);
                return RedirectToAction("Index");

            }                                  
            return View(pizza);
        }

        private IPizzaDB Crud()
        {
            return new PizzaDB();
        }

        public ActionResult Edit()
        {
            var pizza = Crud().Select();
            return View(pizza);
        }

        public ActionResult Delete(int id)
        {
            var pizza = Crud().SelectById(id);
            return View(pizza);
        }



        public ActionResult DeleteConfirm(Pizza pizza)
        {
            Crud().Delete(pizza);
            return RedirectToAction("Index");
        }



       
    }
}