using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Context
{
    [Table("UserOrders")]
    public class UserOrder
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long OrderId { get; set; }

        public DateTime Created { get; set; }
    }
}