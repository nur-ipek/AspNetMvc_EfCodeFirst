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
    public class AddresController : Controller
    {
        // GET: Addres
        public ActionResult AddAddres()
        {
            DatabaseContext databaseContext = new DatabaseContext();

            IEnumerable<SelectListItem> PeopleList =
                (from person in databaseContext.People.ToList()
                 select new SelectListItem()
                 {
                     Text = person.PersonName + " " + person.PersonSurname,
                     Value = person.PersonId.ToString()
                 }
                ).ToList();
            TempData["people"] = PeopleList;
            ViewBag.People = PeopleList; // SAYFA ÜZERİNDE (VİEW DA) VİEWBAG KULLANILIYOR ! TEMPDATA DİREK OLARAK SAYFAYA GİTMİYORRR.
            return View();
        }
        [HttpPost]
        public ActionResult AddAddres(Addres addres)
        {
            DatabaseContext databaseContext = new DatabaseContext();
            addres.IsActive = true;
            Person person = databaseContext.People.Where(x => x.PersonId == addres.Person.PersonId).FirstOrDefault();
            if (person != null)
            {
                addres.Person = person;
              
                databaseContext.Addreses.Add(addres);
                int result = databaseContext.SaveChanges();

                if (result > 0)
                {
                    ViewBag.Result = "Adres kaydedilmişitir.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Adres kaydedilemedi.";
                    ViewBag.Status = "danger";
                }

            }
            ViewBag.People = TempData["people"];
            return View();
        }

        public ActionResult UpdateAddress(int addressID)
        {
            DatabaseContext databaseContext = new DatabaseContext();

            //List<SelectListItem> peopleList =
            //    (from person in databaseContext.People.ToList()
            //     select new SelectListItem()
            //     {
            //         Text = person.PersonName + " " + person.PersonSurname,
            //         Value = person.PersonId.ToString()
            //     }

            //     ).ToList();

            var peopleList = databaseContext.People.Where(x => x.IsActive == true).ToList();

            TempData["people"] = peopleList;
            ViewBag.People = peopleList;


            Addres address = databaseContext.Addreses.Where(x => x.AddressId == addressID).FirstOrDefault();

            return View(address);
        }
        [HttpPost]
        public ActionResult UpdateAddress(Addres model, int addressID)
        {
            DatabaseContext databaseContext = new DatabaseContext();
            Person person = databaseContext.People.Where(x => x.PersonId == model.PersonId).FirstOrDefault();
            Addres address = databaseContext.Addreses.Where(x => x.AddressId == addressID).FirstOrDefault();

            if (addressID > 0)
            {
                address.AddressDefinition = model.AddressDefinition;
                address.Person = person;
            }

            int result = databaseContext.SaveChanges();

            if (result > 0)
            {
                ViewBag.Result = "Adres güncellenmiştir..";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Adres güncellenememiştir";
                ViewBag.Status = "danger";
            }
            ViewBag.People = TempData["people"];
            return View(model);

        }
    }
}