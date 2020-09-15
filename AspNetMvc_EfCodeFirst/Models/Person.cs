using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMvc_EfCodeFirst.Models
{
    public class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        [StringLength(20), Required]
        public string PersonName { get; set; }
        [StringLength(20), Required]
        public string PersonSurname { get; set; }
        public int PersonAge { get; set; }
        public virtual List<Addres> Addresses { get; set; }
        public bool IsActive { get; set; }


    }
}