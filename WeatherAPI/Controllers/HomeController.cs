using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    public class HomeController : Controller
    {
        ValuesController api = new ValuesController();
        [HttpGet]
        public ActionResult Index(string town = null)
        {
            ViewBag.Title = "Home Page";
            var model = new Weather();
            if (town != null)
                model = api.Get(town);
            else
                model = api.Get();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Weather model)
        {
            return RedirectToAction("Index", new { town = model.Town });
        }
    }
}
