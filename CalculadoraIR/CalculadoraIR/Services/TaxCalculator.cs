using CalculadoraIR.Services.Interfaces;

namespace CalculadoraIR.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly ITaxValues taxValues;
        public TaxCalculator(ITaxValues taxValues)
        {
            this.taxValues = taxValues;
        }

        public decimal CalculateTax(decimal amount)
        {
            decimal AllTaxes = taxValues.GetAliquot(amount) - taxValues.GetDerive(amount);
            return AllTaxes;
        }

        public decimal CalculateTaxPerMonth(decimal amount)
        {
            return CalculateTax(amount) / 12; 
        }
    }
}
