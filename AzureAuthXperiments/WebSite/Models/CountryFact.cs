using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class CountryFact
    {
        [Key]
        public string CountryName { get; set; }

        public int Population { get; set; }
    }
}