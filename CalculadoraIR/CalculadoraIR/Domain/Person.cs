
namespace CalculadoraIR.Domain
{
    public class Person
    {
        public string Name { get; set; }
        public decimal Revenue { get; set; }
        public Person() { }

        public override string ToString()
        {
            return $"{Name};{Revenue}";
        }
    }
}
