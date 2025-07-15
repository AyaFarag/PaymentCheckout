using Shop.Domain.Interfaces;
using Shop.Infrastracture.Data;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastracture.Presistance
{
    public class StripeRepository : IStripeRepository
    {
        private readonly ApplicationDBContext context;
        public StripeRepository(ApplicationDBContext _context) 
        {
            context = _context;
        }

        public Task<object> Pay(decimal Amount, string Currency)
        {
            throw new NotImplementedException();
        }

        public Task<string> success()
        {
            throw new NotImplementedException();
        }
        public Task<string> cancel()
        {
            throw new NotImplementedException();
        }
    }
}
