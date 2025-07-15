using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO.StripeDTO
{
    public class PaymentStripeDTO
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "usd";
        public string productName { get; set; }
    }
}
