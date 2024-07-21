using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace citiFM_Assessment2023.models
{
    public class Product
    {
        public string productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal unitPrice { get; set; }
        public int? maximumQuantity { get; set; }
    }
    public class Product_withMarkup : Product
    {
        public decimal unitPrice_MarkUp { get; set; }
    }
}