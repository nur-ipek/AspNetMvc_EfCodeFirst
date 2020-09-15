using AspNetMvc_EfCodeFirst.Models;
using AspNetMvc_EfCodeFirst.Models.Managers;
using AspNetMvc_EfCodeFirst.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc_EfCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DatabaseContext databaseContext = new DatabaseContext();
            //List<Person> people = databaseContext.People.ToList();

            HomePageViewModel model = new HomePageViewModel();
            model.People = databaseContext.People.ToList();
            model.Addreses = databaseContext.Addreses.ToList();

            return View(model);
        }
        public ActionResult Test()
        {
            return View();
        }
    }
}