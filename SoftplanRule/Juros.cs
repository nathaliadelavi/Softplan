using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SoftplanRule
{
    public class Juros : IJuros
    {
        public decimal CalcularJuros(decimal valorInicial, int meses)
        {
            double temp = 0.01;

            double valorFinal = Convert.ToDouble(valorInicial) * (1 + temp);

            valorFinal = Math.Pow(valorFinal, meses);

            return (decimal)valorFinal;
        }

        private void ObterTaxaJuros()
        {
            
        }
    }
}
