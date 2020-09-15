using AspNetMvc_EfCodeFirst.Models;
using AspNetMvc_EfCodeFirst.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc_EfCodeFirst.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPerson(Person person)
        {
            DatabaseContext databaseContext = new DatabaseContext();
            person.IsActive = true;
            databaseContext.People.Add(person);
            int result = databaseContext.SaveChanges();

            if (result > 0)
            {
                ViewBag.Result = "Kişi kaydedilmiştir.";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Kişi kaydedilememiştir";
                ViewBag.Status = "danger";
            }

            return View();
        }

        public ActionResult UpdatePerson(int personID)
        {
            Person person = null;

            if (personID != null)
            {
                DatabaseContext databaseContext = new DatabaseContext();
                person = databaseContext.People.Where(x => x.PersonId == personID).FirstOrDefault();
            }
            return View(person);
        }
        [HttpPost]
        public ActionResult UpdatePerson(Person model, int? personID)
        {
            DatabaseContext databaseContext = new DatabaseContext();
            Person person = databaseContext.People.Where(x => x.PersonId == personID).FirstOrDefault();

            if(person != null)
            {
                person.PersonName = model.PersonName;
                person.PersonSurname = model.PersonSurname;
                person.PersonAge = model.PersonAge;
            }
           // databaseContext.People.Add(person);
            int result = databaseContext.SaveChanges();

            if (result > 0)
            {
                ViewBag.Result = "Kişi güncellenmiştir..";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Kişi güncellenememiştir";
                ViewBag.Status = "danger";
            }
            ViewBag.person = TempData["person"];
            return View(model);



        }

        public ActionResult DeletePerson(int personID)
        {
            DatabaseContext databaseContext = new DatabaseContext();
            Person person = databaseContext.People.Where(x => x.PersonId == personID).FirstOrDefault();

            return View(person);
        }

        [HttpPost,ActionName("DeletePerson")]
        public ActionResult DeletePersonOk(int personID)
        {
            DatabaseContext databaseContext = new DatabaseContext();
            Person person = databaseContext.People.Where(x => x.PersonId == personID).FirstOrDefault();
            //databaseContext.People.Remove(person);
            person.IsActive = false;
            databaseContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
    
}