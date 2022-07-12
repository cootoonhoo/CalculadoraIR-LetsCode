using CalculadoraIR.Domain;
namespace CalculadoraIR.Services.Interfaces
{
    public interface IPersonRepository
    {
        public void SavePerson(Person person);
        public void LoadRepo();
        public void SaveRepo();
        public List<Person> GetPeople();
    }
}
