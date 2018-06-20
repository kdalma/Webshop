using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Webshop.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0: YYYY/MMM/DD}")]
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }

        public string Name { get; set; }
        public List<Product> PurchaseProduct { get; set; }
    }
}