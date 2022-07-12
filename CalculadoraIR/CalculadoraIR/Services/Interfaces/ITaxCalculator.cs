namespace CalculadoraIR.Services.Interfaces
{
    public interface ITaxCalculator
    {
        public decimal CalculateTax(decimal amount);
        public decimal CalculateTaxPerMonth(decimal amount);
    }
}
