using CalculadoraIR.Domain;
using CalculadoraIR.Services.Interfaces;
using System.IO;
using System.Text;


namespace CalculadoraIR.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        public List<Person> _database { get; private set; } = new();
        public List<Person> OpenDataBase { get; private set; } = new();
        public void SavePerson(Person person)
        {
            _database.Add(person);
        }
        public void LoadRepo()
        {
            try
            {
                StreamReader File = new StreamReader("../../../PersonDataBase.txt");
                string Line = "";
                while ((Line = File.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(Line)) 
                    {
                        Person person = new Person();
                        person.Name = Line.Split(";")[0];
                        person.Revenue = decimal.Parse(Line.Split(";")[1]);
                        _database.Add(person);
                    }
                }
                File.Close();
                OpenDataBase = _database;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SaveRepo()
        {
            try
            {
                StreamWriter File = new StreamWriter("../../../PersonDataBase.txt", true, Encoding.UTF8);
                foreach (var Person in OpenDataBase) 
                {
                    //Corrigir aqui:
                    if (!_database.Contains(Person)) 
                    {
                        File.WriteLine(Person);
                    }
                }
                File.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public List<Person> GetPeople()
        {
            return _database;
        }
    }
}
