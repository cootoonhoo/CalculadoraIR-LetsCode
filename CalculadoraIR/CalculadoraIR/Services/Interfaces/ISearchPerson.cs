using CalculadoraIR.Domain;
namespace CalculadoraIR.Services.Interfaces
{
    public interface ISearchPerson
    {
        public List<Person> SearchPersonByName(string Name, List<Person> PersonDataBase);
    }
}
