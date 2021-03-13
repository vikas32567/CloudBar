using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Context
{
    [Table("Orders")]
    public class Order
    {
        public long Id { get; set; }
        public decimal Price { get; set; }        

        public DateTime Created { get; set; }
    }
}