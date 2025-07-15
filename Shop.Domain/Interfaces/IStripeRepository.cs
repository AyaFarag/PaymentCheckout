using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Interfaces
{
    public interface IStripeRepository
    {
        Task<object> Pay(decimal Amount, string Currency);
        Task<string> success();
        Task<string> cancel();
    }
}
