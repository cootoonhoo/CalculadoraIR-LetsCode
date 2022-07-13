using CalculadoraIR.Domain;
using CalculadoraIR.Services.Interfaces;

namespace CalculadoraIR.Services
{
    public class PrintService : IPrintService
    {
        private readonly ITaxCalculator taxCalculator;
        private readonly ITaxValues taxValues;
        public PrintService(ITaxCalculator taxCalculator, ITaxValues taxValues)
        {
            this.taxCalculator = taxCalculator;
            this.taxValues = taxValues;
        }
        public void PrintAllPeople(List<Person> people)
        {
            Console.WriteLine("--- Nome dos clientes ---");
            for (int i = 0; i < people.Count; i++) {
                Console.WriteLine($"{i+1}. {people[i].Name}");
            }
            WaitEnter();
        }

        public void PrintPerson(Person Person)
        {
            Console.WriteLine($"Nome: {Person.Name}");
            Console.WriteLine($"Renda: R${Person.Revenue.ToString("F2")}");
            Console.WriteLine($"--- Impostos ---");
            if (taxValues.GetAliquot(Person.Revenue) == 0) {
                Console.WriteLine("Isento(a) de impostos.");
                WaitEnter();
                return;
            }
            Console.WriteLine($"Aliquota aplicada: {taxValues.GetAliquot(Person.Revenue).ToString("F2")}");
            Console.WriteLine($"Dedução: {taxValues.GetDerive(Person.Revenue).ToString("F2")}");
            Console.WriteLine($"Imposto total: {taxCalculator.CalculateTax(Person.Revenue).ToString("F2")}");
            Console.WriteLine($"Imposto parcelado(12x): {taxCalculator.CalculateTaxPerMonth(Person.Revenue).ToString("F2")}");
            Console.WriteLine();
            WaitEnter();
        }

        public Person PrintSelectedPerson(List<Person> people)
        {
            int Response;
            bool Test;
            Console.Clear();
            Console.WriteLine("--- Nome dos clientes ---");
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {people[i].Name}");
            }
            do
            {
                Console.WriteLine("Digite o indice do cliente desejado:");
                Test = int.TryParse(Console.ReadLine(), out Response) && Response > 0 && Response <= people.Count;
                if (!Test) Console.WriteLine("O número digitado não existe");
            } while (!Test);
            return people[Response-1];
        }

        private void WaitEnter() {
            Console.WriteLine("Aperte ENTER para voltar ao menu");
            Console.ReadLine();
        }
    }
}
