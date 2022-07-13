using CalculadoraIR.Domain;
using CalculadoraIR.Services.Interfaces;

namespace CalculadoraIR.Services
{
    public class SearchPerson : ISearchPerson
    {
        public List<Person> SearchPersonByName(string Name, List<Person> PersonDataBase)
        {
            var FilterPeople = (
                from Person in PersonDataBase
                where Person.Name.Contains(Name)
                select Person
                ).ToList();

            return FilterPeople;
        }
    }
}
