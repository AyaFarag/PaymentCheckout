using Shop.Application.DTO.StripeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Service.Payment.StripeService
{
    public interface IStripeService
    {
        Task<string> Pay(PaymentStripeDTO paymentDTO);
        Task<string> success();
        Task<string> cancel();
    }
}
