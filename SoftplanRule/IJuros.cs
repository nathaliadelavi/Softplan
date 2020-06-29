namespace SoftplanRule
{
    public interface IJuros
    {
        public decimal ValorTaxaJuros()
        {
            return 1;
        }

        decimal CalcularJuros(decimal valorInicial, int meses);
    }
}
