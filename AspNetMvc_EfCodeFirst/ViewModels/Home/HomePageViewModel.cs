using AspNetMvc_EfCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMvc_EfCodeFirst.ViewModels.Home
{
    public class HomePageViewModel
    {
         public List<Person> People { get; set; }

         public List<Addres> Addreses { get; set; }
    }
}