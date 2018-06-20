using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Webshop.Models
{
    public class LoginModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Felhasználónév")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Jelszó")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}