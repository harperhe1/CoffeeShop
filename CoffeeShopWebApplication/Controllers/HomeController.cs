using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoffeeShopWebApplication.Models;

namespace CoffeeShopWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();
            List<Item> myList = ORM.Items.ToList();
            ViewBag.ItemList = myList;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Summary()
        {
            return View();
        }

        public ActionResult AddUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
                ORM.Users.Add(newUser);
                ORM.SaveChanges();
                ViewBag.WelcomeMessage = $"Welcome {newUser.FirstName}!";

                return View("Summary");
            }
            else
            {
                return View("Error");
            }
           
        }
        
        public ActionResult AddItem()
        {
            return View();
        }

        public ActionResult EditItem(string Name)
        {
            if (Name == null || Name == "")
            {
                return View("Index");
            }

            CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();
            Item found = ORM.Items.Find(Name);

            if (found != null)
            {
                ViewBag.Item = found;
                return View();
            }

            return View();
        }

        public ActionResult SaveItemChanges(Item NewItem)
        {
            CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();
            Item oldItem = ORM.Items.Find(NewItem.Name);

            oldItem.Description = NewItem.Description;
            oldItem.Price = NewItem.Price;
            oldItem.Quantity = NewItem.Quantity;

            ORM.Entry(oldItem).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult DeleteItem(string name)
        {
            CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();

            Item ItemToDelete = ORM.Items.Find(name); //Find() is a method that is used to find objects by the primary key
            //remove item
            ORM.Items.Remove(ItemToDelete);

            //Save changes to DB
            ORM.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AddNewItem(Item NewItem)
        {
            CoffeeShopDBEntities1 ORM = new CoffeeShopDBEntities1();

            ORM.Items.Add(NewItem);
            ORM.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}