using LabyrinthExplorer.Utilities;
using Xunit;

namespace LabyrinthExplorer.Tests
{
    public class CommandRegistryTests
    {
        [Theory]
        [InlineData(" N ", "north")]
        [InlineData("East", "east")]
        [InlineData("l", "quit")]
        [InlineData("Inventory", "inventory")]
        public void MapsGameplayAliases(string input, string expected)
        {
            Assert.True(CommandRegistry.TryMapGameplay(input, out var command));
            Assert.Equal(expected, command);
        }

        [Theory]
        [InlineData("NEW GAME", "new")]
        [InlineData(" q", "quit")]
        public void MapsMenuAliases(string input, string expected)
        {
            Assert.True(CommandRegistry.TryMapMenu(input, out var command));
            Assert.Equal(expected, command);
        }
    }
}
