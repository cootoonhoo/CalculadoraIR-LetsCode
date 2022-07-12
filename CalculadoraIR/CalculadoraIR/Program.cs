using CalculadoraIR.Services.Interfaces;
using CalculadoraIR.Services.Taxes;
using CalculadoraIR.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraIR
{
    public class Program
    {
        public static void Main()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvicer = services.BuildServiceProvider();
            var TaxCalculator = serviceProvicer.GetService<ITaxCalculator>();
            var TaxValues = serviceProvicer.GetService<ITaxValues>();
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<ITaxValues, BrasilTaxStyle>()
                .AddScoped<ITaxCalculator, TaxCalculator>();
        }
    }
}