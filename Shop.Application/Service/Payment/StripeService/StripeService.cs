using Microsoft.Extensions.Configuration;
using Shop.Application.DTO.StripeDTO;
using Shop.Application.Service.ProductService;
using Shop.Domain.Interfaces;
using Stripe;
using Stripe.Checkout;


namespace Shop.Application.Service.Payment.StripeService
{
    public class StripeService : IStripeService
    {
        private readonly IStripeRepository stripeRepository;
        private readonly IProductService productService;
        public StripeService(IStripeRepository _stripeRepository, IConfiguration config,
            IProductService _productService)
        {
            stripeRepository = _stripeRepository;
            productService = _productService;
            StripeConfiguration.ApiKey = config["Stripe:SecretKey"];
        }
        public async Task<string> Pay(PaymentStripeDTO paymentDTO)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = paymentDTO.Currency.ToLower(),
                        UnitAmount = (long)(paymentDTO.Amount * 100), // Stripe uses cents
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = paymentDTO.productName
                        }
                    },
                    Quantity = 1
                }
            },
                Mode = "payment",
                SuccessUrl = "https://localhost:7032/api/Stripe/success",
                CancelUrl = "https://yourapp.com/cancel"
            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);
            return session.Url;
        }
        public async Task<string> Pay33(PaymentStripeDTO paymentDTO)
        {
            //var productSer = new ProductService();
            //var product = await productService.CreateProduct(new ProductCreateOptions
            //{
            //    Name = paymentDTO.productName
            //});

            var priceService = new PriceService();
            var price = await priceService.CreateAsync(new PriceCreateOptions
            {
                UnitAmount = (long)(paymentDTO.Amount * 100), // Convert to cents
                Currency = paymentDTO.Currency,
                Product = "4"
            });

            var paymentLinkService = new PaymentLinkService();
            var paymentLink = await paymentLinkService.CreateAsync(new PaymentLinkCreateOptions
            {
                LineItems = new List<PaymentLinkLineItemOptions>
            {
                new PaymentLinkLineItemOptions
                {
                    Price = price.Id,
                    Quantity = 1
                }
            },
                AfterCompletion = new PaymentLinkAfterCompletionOptions
                {
                    Type = "redirect",
                    Redirect = new PaymentLinkAfterCompletionRedirectOptions
                    {
                        Url = "https://localhost:7032/api/Stripe/success"
                    }
                }
            });

            return paymentLink.Url;
        }
        public async Task<string> Pay22(PaymentStripeDTO paymentDTO)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(paymentDTO.Amount * 100), // Stripe expects cents
                Currency = paymentDTO.Currency,
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            var intent = await service.CreateAsync(options);
            return intent.ClientSecret;
        }
        public async Task<string> success()
        {
            return  "Thank you, Payment Complete";
        }
        public Task<string> cancel()
        {
            throw new NotImplementedException();
        }
    }
}
