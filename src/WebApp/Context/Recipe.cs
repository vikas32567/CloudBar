using System;

namespace WebApp.Context
{
    public class Recipe
    {
        public long Id { get; set; }
        public long DrinkId { get; set; }
        public long SpiritId { get; set; }
        public int Percentage { get; set; }        

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}