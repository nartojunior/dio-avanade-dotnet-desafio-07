using ConsoleCalculadora.Services;

namespace ConsoleCalculadoraTests
{
    public class UnitTestCalculadora
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(3, 3, 6)]
        [InlineData(2, 2, 4)]
        public void TestSomar(int x, int y, int expected)
        {
            // Arrange
            Calculadora calc = new();

            // Act(ion)
            var result = calc.Somar(x, y);

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
            Calculadora calc = new();

            // Act(ion)
            var result = calc.Subtrair(x, y);

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
            Calculadora calc = new();

            // Act(ion)
            var result = calc.Multiplicar(x, y);

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
            Calculadora calc = new();

            // Act(ion)
            var result = calc.Dividir(x, y);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestDividirPorZero()
        {
            // Arrange
            Calculadora calc = new();

            // Action/Assert
            Assert.Throws<DivideByZeroException>(
                () => calc.Dividir(2, 0));
        }

        [Fact]
        public void TestHistoricoCom3Acoes()
        {
            // Arrange
            Calculadora calc = new();

            calc.Somar(1, 2);
            calc.Somar(1, 2);
            calc.Somar(1, 2);
            calc.Somar(1, 2);

            var lista = calc.Historico();

            // Action/Assert
            Assert.NotEmpty(lista);
            Assert.Equal(3, lista.Count);
        }
    }
}