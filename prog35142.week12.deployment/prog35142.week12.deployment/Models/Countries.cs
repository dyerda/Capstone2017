using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prog35142.week12.deployment.Models
{
    public class Countries
    {
        [Key]
        public int CountryId { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }
    }
}