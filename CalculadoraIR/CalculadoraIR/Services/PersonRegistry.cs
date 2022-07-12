using CalculadoraIR.Domain;
using CalculadoraIR.Services.Interfaces;

namespace CalculadoraIR.Services
{
    public class PersonRegistry : IPersonRegisty
    {
        public Person CreatePerson()
        {
            string Name;
            decimal Revenue;
            bool teste;
            Person newPerson = new Person();
            do
            {
                Console.WriteLine("Digite o nome:");
                Name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(Name)) Console.WriteLine("Nome inválido");
            } while (string.IsNullOrWhiteSpace(Name));

            do
            {
                Console.WriteLine("Digite a renda:");
                 teste = Decimal.TryParse(Console.ReadLine(), out Revenue) && Revenue > 0;
                if (!teste) Console.WriteLine("Valor inválido, digite no modelo (XXXX.XX)"); ;
            } while (!teste);

            newPerson.Name = Name;
            newPerson.Revenue = Revenue;
            return newPerson;
        }
    }
}
