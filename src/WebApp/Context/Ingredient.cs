using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Context
{
    [Table("Ingredients")]
    public class Ingredient
    {
        public long Id { get; set; }
        public long DrinkId { get; set; }
        public long SpiritId { get; set; }
        public int Percentage { get; set; }        

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}