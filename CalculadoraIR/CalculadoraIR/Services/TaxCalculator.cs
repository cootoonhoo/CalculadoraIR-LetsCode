using CalculadoraIR.Services.Interfaces;

namespace CalculadoraIR.Services
{
    class TaxCalculator : ITaxCalculator
    {
        private readonly ITaxValues taxValues;
        public TaxCalculator(ITaxValues taxValues)
        {
            this.taxValues = taxValues;
        }

        public decimal CalculateTax(decimal amount)
        {
            decimal AllTaxes = taxValues.GetAliquot(amount) + taxValues.GetDerive(amount);

            return AllTaxes;
        }

    }
}
