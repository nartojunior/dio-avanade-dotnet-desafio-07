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
    }
}