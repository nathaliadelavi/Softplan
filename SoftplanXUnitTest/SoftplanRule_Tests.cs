using Moq;
using SoftplanRule;
using Xunit;

namespace SoftplanXUnitTest
{
    public class SoftplanRule_Tests
    {
        [Fact]
        public void ValorTaxaJuros_Test()
        {
            // arrange
            Mock<IJuros> jurosMock = new Mock<IJuros>();
            jurosMock.Setup(x => x.ValorTaxaJuros())
                .Returns(1);

            // act
            IJuros juros = new Juros();
            var valorRecebido = juros.ValorTaxaJuros();
            var valorEsperado = jurosMock.Object.ValorTaxaJuros();

            // assert
            Assert.Equal(valorEsperado, valorRecebido);
        }

        [Fact]
        public void CalcularJuros_Test()
        {
            // arrange
            Mock<IJuros> jurosMock = new Mock<IJuros>();
            jurosMock.Setup(x => x.ValorTaxaJuros())
                .Returns(0.01);
            jurosMock.Setup(x => x.CalcularJuros(It.IsAny<double>(), It.IsAny<int>(), It.IsAny<double>()))
                .Returns(105.1);

            // act
            IJuros juros = new Juros();
            var valorTaxaJuros = juros.ValorTaxaJuros() / 100;
            var valorRecebido = juros.CalcularJuros(100, 5, valorTaxaJuros);

            var valorEsperado = jurosMock.Object.CalcularJuros(1, 1, 1);

            // assert
            Assert.Equal(valorEsperado, valorRecebido);
        }
    }
}
