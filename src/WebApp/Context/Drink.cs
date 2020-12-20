using System;

namespace WebApp.Context
{
    public class Drink
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public float OverheadCost { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}