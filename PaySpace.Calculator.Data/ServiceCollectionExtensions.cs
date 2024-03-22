using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace PaySpace.Calculator.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CalculatorContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CalculatorDatabase")));
        }

        public static void InitializeDatabase(this IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<CalculatorContext>();
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            
        }
    }
}