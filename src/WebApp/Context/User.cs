using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Context
{
    [Table("Users")]
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Status { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}