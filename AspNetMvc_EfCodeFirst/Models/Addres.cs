using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetMvc_EfCodeFirst.Models
{
    public class Addres
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        [StringLength(300)]
        public string AddressDefinition { get; set; }
        public virtual Person Person { get; set; }

        public int PersonId { get; set; }
        public bool IsActive { get; set; }

    }
}