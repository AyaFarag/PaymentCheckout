using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Automapper;
using Shop.Application.Service.BrandService;
using Shop.Application.Service.CartService;
using Shop.Application.Service.CategoryService;
using Shop.Application.Service.CountryService;
using Shop.Application.Service.Payment.StripeService;
using Shop.Application.Service.ProductService;
using Shop.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Configuration
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IStripeService, StripeService>();


            services.AddHttpContextAccessor();

            services.AddAutoMapper(typeof(CountryProfile));
            services.AddAutoMapper(typeof(BrandProfile));
            services.AddAutoMapper(typeof(CategoryProfile));
            services.AddAutoMapper(typeof(ProductProfile));



            // Register FluentValidation
            services.AddValidatorsFromAssemblyContaining<CountryValidator>();

            // Add FluentValidation to MVC
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            return services;
        }
    }
}
