using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class IndexModel
    {
        [Required]
        [Display(Name = "Felhasználónév")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Jelszó")]
        [DataType(DataType.Password)]
        public string PlainTextPassword { get; set; }

        public List<string> ImagePathes { get; set; }
    }
}