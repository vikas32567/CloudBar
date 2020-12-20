using System;

namespace WebApp.Context
{
    public class OrderItem
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public long DrinkId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }        

        public DateTime Created { get; set; }
    }
}