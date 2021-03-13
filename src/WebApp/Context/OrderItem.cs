using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Context
{
    [Table("OrderItems")]
    public class OrderItem
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public long DrinkId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }        

        public DateTime Created { get; set; }
    }
}