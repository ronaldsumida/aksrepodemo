using IRepositoryLib;
using LoggerLib;
using ProductLib;
using ProductRepoLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProductServiceExtensions
    {
        public static IServiceCollection AddProducts(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Product, int>, ProductRepository>();
            services.AddSingleton<IMyLogger, FileLogger>();
            services.AddScoped<ProductService>();
            return services;
        }
    }
}
