using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace citiFM_Assessment2023.models
{
    public class Order
    {
        public string customerName { get; set; }
        public string customerEmail { get; set; }
        public List<OrderLineItem> lineItems { get; set; }
    }
    public class OrderLineItem
    {
        public string productId { get; set; }
        public int quantity { get; set; }
    }
}