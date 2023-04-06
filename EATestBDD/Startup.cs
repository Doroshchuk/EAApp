using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Data;
using ProductAPI.Repository;
using SolidToken.SpecFlow.DependencyInjection;

namespace EATestBDD
{
    public static class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json").Build();
            string? connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ProductDbContext>(option =>
                    option.UseSqlServer(connectionString));

            services.AddTransient<IProductRepository, ProductRepository>();
            services.UseWebDriverInitializer();
            services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<IProductPage, ProductPage>();
            services.AddScoped<IDriverFixture, DriverFixture>();
            services.AddScoped<IBrowserDriver, BrowserDriver>();

            return services;    
        }
    }
}
