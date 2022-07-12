namespace CalculadoraIR.Services.Interfaces
{
    public interface ITaxValues
    {
        public decimal GetDerive(decimal amount);
        public decimal GetAliquot(decimal amount);
        public decimal AliquotIndex(decimal amount);
        public decimal DeriveIndex(decimal amount);
    }
}
