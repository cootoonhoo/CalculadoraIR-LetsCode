using CalculadoraIR.Services.Interfaces;
using CalculadoraIR.Services.Taxes;
using CalculadoraIR.Services;
using CalculadoraIR.Presetation;
using CalculadoraIR.Repositories;
using CalculadoraIR.Domain;
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
            var RegistryService = serviceProvicer.GetService<IPersonRegisty>();
            var RepoService = serviceProvicer.GetService<IPersonRepository>();

            int OptionResponse;

            do
            {
                OptionResponse = MainMenuFlow();
                switch (OptionResponse) {
                    case 1:
                        RepoService.SavePerson(RegistryService.CreatePerson());
                        break;
                    case 2:

                        break;
                    default:
                        RepoService.SaveRepo();
                        return;
                }
            } while (true);

        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<ITaxValues, BrasilTaxStyle>()
                .AddScoped<ITaxCalculator, TaxCalculator>()
                .AddScoped<IPersonRepository, PersonRepository>()
                .AddScoped<IPersonRegisty, PersonRegistry>();
            
        }

        public static int MainMenuFlow() {

            int OptionResponse;
            bool test = true;
            do
            {
                Console.Clear();
                Screens.Header();
                Screens.MainMenu();
                if (!test) Console.WriteLine("Opção inválida");
                Console.WriteLine("Digite uma alternativa:");
                test = int.TryParse(Console.ReadLine(), out OptionResponse) && OptionResponse > 0 && OptionResponse <= 3;
            } while (!test);
            return OptionResponse;
        }
    }
}