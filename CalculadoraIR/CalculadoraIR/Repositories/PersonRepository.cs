using CalculadoraIR.Domain;
using CalculadoraIR.Services.Interfaces;
using System.IO;
using System.Text;


namespace CalculadoraIR.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        public List<Person> _database { get; } = new();
        public void SavePerson(Person person)
        {
            _database.Add(person);
        }
        public void LoadRepo() {
            
        }
        public void SaveRepo()
        {
            try
            {
                StreamWriter file = new StreamWriter("../../../PersonDataBase.txt", true, Encoding.UTF8);
                foreach (var Person in _database)
                {
                    file.WriteLine(Person);
                }
                file.Close();
            }
            catch (Exception e) {
                Console.WriteLine($"Exception {e}");
            }
        }
        public PersonRepository() {
            LoadRepo();
        }
    }
}
