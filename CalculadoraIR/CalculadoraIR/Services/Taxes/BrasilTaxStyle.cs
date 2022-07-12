using CalculadoraIR.Services.Interfaces;

namespace CalculadoraIR.Services.Taxes
{
    public class BrasilTaxStyle : ITaxValues
    {
        public Dictionary<decimal[], decimal> TaxTable = new Dictionary<decimal[], decimal>();

        public decimal GetAliquot(decimal amount)
        {
            return amount * AliquotIndex(amount);
        }

        public decimal GetDerive(decimal amount)
        {
            return DeriveIndex(amount);
        }

        public decimal AliquotIndex(decimal amount)
        {
            switch (amount)
            {
                case <= 22847.76M:
                    return 0;

                case <= 33919.80M:
                    return 0.075M;

                case <= 45012.60M:
                    return 0.15M;

                case <= 55976.16M:
                    return 0.225M;

                default:
                    return 0.275M;
            }
        }
        public decimal DeriveIndex(decimal amount)
        {
            switch (amount)
            {
                case <= 22847.76M:
                    return 0;

                case <= 33919.80M:
                    return 1713.58M;

                case <= 45012.60M:
                    return 4257.57M;

                case <= 55976.16M:
                    return 7633.51M;

                default:
                    return 10432.32M;
            }
        }

    }
}
