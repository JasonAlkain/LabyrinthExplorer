using System.Linq;
using LabyrinthExplorer.Data;
using LabyrinthExplorer.Tests.TestUtilities;
using Xunit;

namespace LabyrinthExplorer.Tests
{
    public class PlayerStateMapperTests
    {
        [Fact]
        public void ToData_CreatesDeepCopyOfInventory()
        {
            var mapper = new PlayerStateMapper();
            var observer = new RecordingPlayerObserver();
            var player = new Player(mapper, observer, new PlayerData())
            {
                Name = "Explorer",
                Sanity = 8,
            };
            player.Inventory.Add(new Card { Name = "Torch", Description = "Bright light" });
            player.Inventory.Add(new Weapon { Name = "Sword", Description = "Sharp" });

            var data = mapper.ToData(player);

            Assert.Equal("Explorer", data.Name);
            Assert.Equal(8, data.Sanity);
            Assert.Equal(2, data.Inventory.Count);

            player.Inventory[0].Name = "Changed";

            var mappedNames = data.Inventory.Select(i => i.Name).ToList();
            Assert.Contains("Torch", mappedNames);
            Assert.Contains("Sword", mappedNames);
        }

        [Fact]
        public void Apply_RestoresStateWithoutSharingInventoryInstances()
        {
            var mapper = new PlayerStateMapper();
            var observer = new RecordingPlayerObserver();
            var player = new Player(mapper, observer, new PlayerData());
            var data = new PlayerData
            {
                Name = "NewName",
                Sanity = 3,
                Inventory =
                {
                    new Card { Name = "Map", Description = "Guidance" },
                }
            };

            mapper.Apply(player, data);

            Assert.Equal("NewName", player.Name);
            Assert.Equal(3, player.Sanity);
            Assert.Single(player.Inventory);

            data.Inventory[0].Name = "Changed";

            Assert.Equal("Map", player.Inventory[0].Name);
        }
    }
}
