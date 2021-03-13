using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Context
{
    [Table("Drink")]
    public class Drink
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal OverheadCost { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}