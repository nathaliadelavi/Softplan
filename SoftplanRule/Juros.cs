using System;

namespace SoftplanRule
{
    public class Juros : IJuros
    {
        public double CalcularJuros(double valorOriginal, int meses, double taxaJuros)
        {
            var jurosCompostos = Math.Pow(1 + taxaJuros, meses);
            var valorFinal = jurosCompostos * valorOriginal;
            
            return Math.Truncate(100 * valorFinal) / 100;
        }
    }
}
