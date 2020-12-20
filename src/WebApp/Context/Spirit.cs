using System;

namespace WebApp.Context
{
    public class Spirit
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        
    }
}