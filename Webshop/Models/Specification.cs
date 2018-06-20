using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class Specification
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [MaxLength(400, ErrorMessage = "A mező maximum 400 karakter hosszú lehet.")]
        public string Description { get; set; }
    }
}