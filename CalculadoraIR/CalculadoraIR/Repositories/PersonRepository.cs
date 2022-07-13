using CalculadoraIR.Domain;
using CalculadoraIR.Services.Interfaces;
using System.IO;
using System.Text;


namespace CalculadoraIR.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        public List<Person> _database { get; private set; } = new();
        public List<Person> DefaultDataBase { get; private set; } = new();
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
                foreach(var Person in _database)
                    DefaultDataBase.Add(Person);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SaveRepo()
        {
            bool ContainsInDefaultDataBase;
            try
            {
                StreamWriter File = new StreamWriter("../../../PersonDataBase.txt", true, Encoding.ASCII);
                for (int i = 0; i < _database.Count; i++)
                {
                    ContainsInDefaultDataBase = false;
                    for (int j = 0; i < DefaultDataBase.Count; j++)
                    {
                        if (DefaultDataBase[j].Name == _database[i].Name) 
                        {
                            ContainsInDefaultDataBase = true;
                            break;
                        }
                    }
                        Console.WriteLine("ContainsInDefaultDataBase = " + ContainsInDefaultDataBase);
                    if (ContainsInDefaultDataBase == false)
                    {
                        Console.WriteLine("ENTREI");
                        File.Write($"\n{_database[i].Name};{_database[i].Revenue}\r");
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
