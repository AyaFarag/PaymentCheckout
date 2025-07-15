using FluentValidation;
using FluentValidation.AspNetCore;
using Shop.Application.Service.CountryService;
using Shop.Application.Validation;

namespace Shop.API.Configuration
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
           


            return services;
        }
    }
}
