using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PaySpace.Calculator.Web.Services.Abstractions;

namespace PaySpace.Calculator.Web.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCalculatorHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            string baseUrl = configuration.GetSection("CalculatorSettings")["ApiUrl"];

            // Configure HttpClient
            services.AddHttpClient("CalculatorHttpService", client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });
            services.AddScoped<ICalculatorHttpService, CalculatorHttpService>();
        }
    }
}