using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EshopMVC.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string CategoryId { get; set; }
        public Nullable<bool> ExistsInStock { get; set; }
    }
}