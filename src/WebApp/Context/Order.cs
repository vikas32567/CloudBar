using System;

namespace WebApp.Context
{
    public class Order
    {
        public long Id { get; set; }
        public float Price { get; set; }        

        public DateTime Created { get; set; }
    }
}