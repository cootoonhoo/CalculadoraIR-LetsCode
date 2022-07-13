using CalculadoraIR.Domain;

namespace CalculadoraIR.Services.Interfaces
{
    public interface IPrintService
    {
        public void PrintPerson(Person Person);
        public Person PrintSelectedPerson(List<Person> people);
        public void PrintAllPeople(List<Person> people);
    }
}
