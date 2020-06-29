using NUnit.Framework;
using SoftplanRule;

namespace SoftplanTests
{
    public class SoftplanRule_Tests
    {
        IJuros juros = new Juros();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalcularJuros_Success()
        {
            var valorInicial = 1000M;
            var meses = 10;

            Assert.AreEqual(1, juros.CalcularJuros(valorInicial, meses));
        }

        [Test]
        public void RetornaTaxaJuros_Success()
        {
            Assert.AreEqual(1, juros.ValorTaxaJuros());
        }
    }
}
