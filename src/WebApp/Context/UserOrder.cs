using System;

namespace WebApp.Context
{
    public class UserOrder
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long OrderId { get; set; }

        public DateTime Created { get; set; }
    }
}