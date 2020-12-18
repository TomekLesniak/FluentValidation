using System;

namespace OrdersLibrary
{
    public class Order
    {
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
