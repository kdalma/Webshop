using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class FavoriteModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }

        public List<Favorite> MyFavoriteProducts { get; set; }
    }
}