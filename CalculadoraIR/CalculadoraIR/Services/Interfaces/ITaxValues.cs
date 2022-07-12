namespace CalculadoraIR.Services.Interfaces
{
    public interface ITaxValues
    {
        public decimal GetDerive(decimal amount);
        public decimal GetAliquot(decimal amount);
    }
}
