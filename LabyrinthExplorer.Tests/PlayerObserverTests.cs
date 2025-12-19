using LabyrinthExplorer.Data;
using LabyrinthExplorer.Tests.TestUtilities;
using Xunit;

namespace LabyrinthExplorer.Tests
{
    public class PlayerObserverTests
    {
        [Fact]
        public void SanityChanges_NotifyObserver()
        {
            var mapper = new PlayerStateMapper();
            var observer = new RecordingPlayerObserver();
            var player = new Player(mapper, observer, new PlayerData());

            player.Sanity = 12;
            player.Sanity = 15;

            Assert.Collection(observer.SanityChanges,
                change => Assert.Equal(12, change),
                change => Assert.Equal(15, change));
        }

        [Fact]
        public void ShowInventory_RelaysItemsToObserver()
        {
            var mapper = new PlayerStateMapper();
            var observer = new RecordingPlayerObserver();
            var player = new Player(mapper, observer, new PlayerData());
            var item = new Item { Name = "Gem" };
            player.Inventory.Add(item);

            player.ShowInventory();

            Assert.Single(observer.InventoryShown);
            Assert.Equal(item, observer.InventoryShown[0]);
        }
    }
}
