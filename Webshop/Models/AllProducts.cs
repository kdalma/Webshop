using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class AllProducts
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [MaxLength(400, ErrorMessage ="A mező maximum 400 karakter hosszú lehet.")]
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int SizeId { get; set; }
        public virtual SizeModel Size { get; set; }
        public int ProductCategoryId { get; set; }
        public virtual Category Category { get; set; }

        public List<SizeModel> AllSizes { get; set; }
        public List<Product> ProductList { get; set; }
    }
}