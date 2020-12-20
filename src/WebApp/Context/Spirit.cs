using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Context
{
    [Table("Spirits")]
    public class Spirit
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        
    }
}