using NUnit.Framework;
using SoftplanRule;
using System;
using System.Linq;

namespace SoftplanTests
{
    public class SoftplanRule_Tests
    {
        static IJuros juros = new Juros();
        double valorInicial = 100;
        int meses = 5;
        double taxaJuros = juros.ValorTaxaJuros() / 100;
        string caminhoRepository = AppDomain.CurrentDomain
                .BaseDirectory.Split("SoftplanTests").FirstOrDefault();

        [Theory]
        public void CalcularJuros_Test()
        {
            Assert.AreEqual(105.1, juros.CalcularJuros(valorInicial, meses, taxaJuros));
            Assert.Zero(juros.CalcularJuros(0, meses, taxaJuros));
        }

        [Theory]
        public void RetornaTaxaJuros_Test()
        {
            Assert.AreEqual(1, taxaJuros * 100);
        }

        [Theory]
        public void ShowMeTheCode_Test()
        {
            var esperado = RepositoryInformation
                .GetRepositoryInformationForPath(caminhoRepository).Url;

            Assert.IsTrue(!string.IsNullOrEmpty(esperado));
        }
    }
}
