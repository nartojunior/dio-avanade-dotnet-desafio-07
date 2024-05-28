using ConsoleCalculadora.Services;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace ConsoleCalculadoraTests
{
    public class UnitTestCalculadora
    {
        // serve para exibir mensagens no Gerenciador de Testes.
        private readonly ITestOutputHelper output;

        public UnitTestCalculadora(ITestOutputHelper output)
        {
            this.output = output;
        }
        public Calculadora SetupCalculadora() 
        {
            return new Calculadora(DateTime.Now.ToLongTimeString());
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(3, 3, 6)]
        [InlineData(2, 2, 4)]
        public void TestSomar(int x, int y, int expected)
        {
            // Arrange
            Calculadora calc = SetupCalculadora();

            // Act(ion)
            var result = calc.Somar(x, y);
            ShowHistorico(calc);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2,-1)]
        [InlineData(3, 3, 0)]
        [InlineData(6, 2, 4)]
        public void TestSubtrair(int x, int y, int expected)
        {
            // Arrange
            Calculadora calc = SetupCalculadora();

            // Act(ion)
            var result = calc.Subtrair(x, y);
            ShowHistorico(calc);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(3, 3, 9)]
        [InlineData(6, 2, 12)]
        public void TestMultiplicar(int x, int y, int expected)
        {
            // Arrange
            Calculadora calc = SetupCalculadora();

            // Act(ion)
            var result = calc.Multiplicar(x, y);
            ShowHistorico(calc);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(8, 4, 2)]
        [InlineData(5, 5, 1)]
        public void TestDividir(int x, int y, int expected)
        {
            // Arrange
            Calculadora calc = SetupCalculadora();

            // Act(ion)
            var result = calc.Dividir(x, y);
            ShowHistorico(calc);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestDividirPorZero()
        {
            // Arrange
            Calculadora calc = SetupCalculadora();

            // Action/Assert
            Assert.Throws<DivideByZeroException>(
                () => calc.Dividir(2, 0));
        }

        [Fact]
        public void TestHistoricoCom3Acoes()
        {
            // Arrange
            Calculadora calc = SetupCalculadora();

            calc.Somar(1, 2);
            calc.Somar(2, 3);
            calc.Somar(3, 4);
            calc.Somar(4, 5);

            var lista = calc.Historico();

            ShowHistorico(calc);
 
            // Action/Assert
            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }

        private void ShowHistorico(Calculadora calc) 
        {
            foreach (var acao in calc.Historico())
            {
                output.WriteLine(acao);
            }
        }
    }
}