using CalculadoraIR.Domain;
using CalculadoraIR.Services.Interfaces;
using System.IO;
using System.Text;


namespace CalculadoraIR.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        public List<Person> _database { get; private set; } = new();
        private List<Person> Originalpersons { get; }
        public void SavePerson(Person person)
        {
            _database.Add(person);
        }
        public void LoadRepo() {
            try
            {
                string Line;
                string[] Data = new string[2];
                StreamReader File = new StreamReader("../../../PersonDataBase.txt");
                do
                {
                Console.WriteLine("TO aqui");
                Console.ReadLine();
                    Line = File.ReadLine();
                    if (!string.IsNullOrWhiteSpace(Line))
                    {
                        Data = Line.Split(";");
                        Person newPerson = new();
                        newPerson.Name = Data[0];
                        newPerson.Revenue = Decimal.Parse(Data[1]);
                        _database.Add(newPerson);
                    }
                Console.WriteLine("Close O aqui");
                Console.ReadLine();
                } while (!string.IsNullOrWhiteSpace(Line));
                File.Close();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        public void SaveRepo()
        {
            try
            {
                StreamWriter file = new StreamWriter("../../../PersonDataBase.txt", true, Encoding.UTF8);
                foreach (var Person in _database)
                {
                    if(!Originalpersons.Contains(Person))
                        Console.WriteLine(Person);
                        file.WriteLine(Person);
                    Console.Read();
                }
                file.Close();
            }
            catch (Exception e) {
                Console.WriteLine($"Exception {e}");
            }
        }

        public List<Person> GetPeople()
        {
            return _database;
        }
    }
}
