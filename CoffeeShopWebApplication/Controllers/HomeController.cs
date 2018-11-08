﻿using System;
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

        public ActionResult AddUser(Register newUser)
        {
            if(ModelState.IsValid)
            {
                ViewBag.WelcomeMessage = $"Welcome {newUser.FirstName}!";

                return View("Summary");
            }
            else
            {
                return View("Error");
            }

        }

    }
}