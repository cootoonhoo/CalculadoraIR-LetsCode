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
            var SearchService = serviceProvicer.GetService<ISearchPerson>();
            var PrintService = serviceProvicer.GetService<IPrintService>();
            var RepoService = serviceProvicer.GetService<IPersonRepository>();

            RepoService.LoadRepo();
            int OptionResponse;
            string Response;

            do
            {
                OptionResponse = MainMenuFlow();
                switch (OptionResponse)
                {
                    case 1:
                        Person newPerson = RegistryService.CreatePerson();
                        Console.Clear();
                        Screens.Header();
                        PrintService.PrintPerson(newPerson);
                        RepoService.SavePerson(newPerson);
                        break;
                    case 2:
                        Response = GetName();
                        var PeopleSearch = SearchService.SearchPersonByName(Response, RepoService.GetPeople());
                        var SelectedPerson = PrintService.PrintSelectedPerson(PeopleSearch);
                        Console.Clear();
                        Screens.Header();
                        PrintService.PrintPerson(SelectedPerson);
                        break;
                    case 3:
                        Console.Clear();
                        PrintService.PrintAllPeople(RepoService.GetPeople());
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
                .AddScoped<ISearchPerson, SearchPerson>()
                .AddScoped<IPrintService, PrintService>()
                .AddScoped<IPersonRegisty, PersonRegistry>();
        }

        public static int MainMenuFlow()
        {

            int OptionResponse;
            bool test = true;
            do
            {
                Console.Clear();
                Screens.Header();
                Screens.MainMenu();
                if (!test) Console.WriteLine("Opção inválida");
                Console.WriteLine("Digite uma alternativa:");
                test = int.TryParse(Console.ReadLine(), out OptionResponse) && OptionResponse > 0 && OptionResponse <= 4;
            } while (!test);
            return OptionResponse;
        }
        public static string GetName() {
            string Response;
            Console.Clear();
            Screens.Header();
            do
            {
                Console.WriteLine("Digite um nome:");
                Response = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Response))
                    Console.WriteLine("Nome inválido");
            } while (string.IsNullOrWhiteSpace(Response));
            return Response;
        }
    }
}