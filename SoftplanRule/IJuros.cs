namespace SoftplanRule
{
    public interface IJuros
    {
        public double ValorTaxaJuros()
        {
            return 1;
        }

        double CalcularJuros(double valorOriginal, int meses, double taxaJuros);
    }
}
