using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; } 
        public string UserId { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public short status { get; set; }
        public int? CouponId { get; set; }
        public Coupon Coupon { get; set; }
        public List<OrderItems> Items { get; set; } = new();
    }
}
