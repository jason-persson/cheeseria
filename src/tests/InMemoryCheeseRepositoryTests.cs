using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Domain;
using System.Collections.Generic;

namespace Tests
{
    /// I'm not convinced that testing this repository adds much value, but I want to demonstrate that I can write unit tests
    public class InMemoryCheeseRepositoryTests
    {
        [Fact]
        public async Task AddSucceeds()
        {
            // Arrange
            var repository = new InMemoryCheeseRepository();
            var expected = new Cheese(1, "Test1", "", "", 0);

            // Act
            await repository.Add(expected);

            // Assert
            var actual = await repository.GetAll();
            actual.Should().ContainSingle()
                .And.Contain(expected);
        }

        [Fact]
        public async Task DeleteExistingSucceeds()
        {
            // Arrange
            var repository = new InMemoryCheeseRepository();
            var cheese1 = new Cheese(1, "Test1", "", "", 0);
            var cheese2 = new Cheese(2, "Test2", "", "", 0);
            var cheese3 = new Cheese(3, "Test3", "", "", 0);

            await repository.Add(cheese1);
            await repository.Add(cheese2);
            await repository.Add(cheese3);

            // Act
            await repository.Delete(3);

            // Assert
            var actual = await repository.GetAll();
            actual.Should().NotContain(cheese3)
                .And.Contain(cheese1)
                .And.Contain(cheese2);
        }

        [Fact]
        public async Task DeleteNonExistingThrows()
        {
            // Arrange
            var repository = new InMemoryCheeseRepository();

            // Act
            var act = () => repository.Delete(1);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }

        [Fact]
        public async Task GetExistingSucceeds()
        {
            // Arrange
            var repository = new InMemoryCheeseRepository();
            const int expectedId = 1;
            var expected = new Cheese(expectedId, "Test1", "", "", 0);

            await repository.Add(expected);

            // Act
            var actual = await repository.Get(expectedId);

            // Assert
            actual.Should().Be(expected);
        }

        [Fact]
        public async Task GetNonExistingThrows()
        {
            // Arrange
            var repository = new InMemoryCheeseRepository();

            // Act
            var act = () => repository.Get(1);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }

        [Fact]
        public async Task UpdateExistingSucceeds()
        {
            // Arrange
            var repository = new InMemoryCheeseRepository();
            const int expectedId = 1;
            var original = new Cheese(expectedId, "Original Name", "", "", 0);
            var updated = new Cheese(expectedId, "Updated Name", "", "", 0);

            await repository.Add(original);
            
            // Sanity test to make sure original and updated are actually different
            var actual = await repository.Get(expectedId);
            actual.Should().NotBe(updated);

            // Act
            actual = await repository.Update(updated);

            // Assert
            actual.Should().Be(updated);
        }

        [Fact]
        public async Task UpdateNonExistingThrows()
        {
            // Arrange
            var repository = new InMemoryCheeseRepository();

            // Act
            var act = () => repository.Update(new Cheese(1, "Test1", "", "", 0));

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>();
        }

        [Fact]
        public async Task GetAllSucceeds()
        {
            // Arrange
            var repository = new InMemoryCheeseRepository();
            var cheese1 = new Cheese(1, "Test1", "", "", 0);
            var cheese2 = new Cheese(2, "Test2", "", "", 0);
            var cheese3 = new Cheese(3, "Test3", "", "", 0);

            await repository.Add(cheese1);
            await repository.Add(cheese2);
            await repository.Add(cheese3);

            // Act
            var actual = await repository.GetAll();

            // Assert
            actual.Should().HaveCount(3)
                .And.Contain(cheese1)
                .And.Contain(cheese2)
                .And.Contain(cheese3);
        }
    }
}