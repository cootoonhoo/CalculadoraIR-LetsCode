using CalculadoraIR.Domain;
using CalculadoraIR.Services.Interfaces;

namespace CalculadoraIR.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        public List<Person> _database { get; }
        public void SavePerson(Person person)
        {
            _database.Add(person);
        }
    }
}
