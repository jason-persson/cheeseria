using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Domain;

namespace Tests
{
    public class InMemoryCheeseRepositoryTests
    {
        [Fact]
        public async Task AddCheeseTest()
        {
            // Arrange
            var repository = new InMemoryCheeseRepository();

            // Act
            var expected = new Cheese(1, "Test");
            await repository.AddCheese(expected);

            // Assert
            var actual = await repository.GetCheeses();
            actual.Should().Contain(expected);
        }
    }
}