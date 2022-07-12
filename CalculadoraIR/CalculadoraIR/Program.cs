using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraIR
{
    public class Program
    {
        public void Main()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvicer = services.BuildServiceProvider();


        }
        public static void ConfigureServices(IServiceCollection services)
        {
            
        }
    }
}