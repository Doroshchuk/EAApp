using Microsoft.Extensions.DependencyInjection;
using EATestFramework.Settings;
using EATestFramework.Driver;
using Microsoft.Extensions.Configuration;

namespace EATestFramework.Extensions
{
    public static class WebDriverInitializerExtension
    {
        public static IServiceCollection UseWebDriverInitializer(
            this IServiceCollection services)
        {
            services.AddSingleton(ReadConfig("appsettings.json"));

            return services;
        }

        private static TestSettings ReadConfig(string configFileName)
        {
            var config = new ConfigurationBuilder()
               .AddJsonFile(configFileName).Build();
            var testSettings = config.GetSection("TestSettings").Get<TestSettings>();
            
            return testSettings;
        }
    }
}
