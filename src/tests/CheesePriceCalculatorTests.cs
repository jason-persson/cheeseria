using Domain;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using FakeItEasy;

namespace Tests
{
    public class CheesePriceCalculatorTests
    {
        [Theory]
        [InlineData(0.00, 1.00, 0.00)]
        [InlineData(1.00, 0.00, 0.00)]
        [InlineData(1.00, 1.00, 1.00)]
        [InlineData(2.50, 1.00, 2.50)]
        [InlineData(2.50, 2.00, 5.00)]
        [InlineData(5.00, 0.50, 2.50)]
        public async Task CalculateCheesePrice(decimal cheesePrice, decimal kgToBuy, decimal expectedPrice)
        {
            // Arrange
            var repository = A.Fake<ICheeseRepository>();
            A.CallTo(() => repository.Get(1)).Returns(new Cheese(1, "Test 1", "", "", cheesePrice));

            var calculator = new CheesePriceCalculator(repository);

            // Act
            var result = await calculator.CalculateCheesePrice(1, kgToBuy);

            // Assert
            result.Should().Be(expectedPrice);
        }

    }
}

