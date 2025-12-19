using System.Collections.Generic;
using LabyrinthExplorer.Data;

namespace LabyrinthExplorer.Tests.TestUtilities
{
    public class RecordingPlayerObserver : IPlayerObserver
    {
        public List<int> SanityChanges { get; } = new();

        public List<Item> InventoryShown { get; } = new();

        public void OnSanityChanged(Player player, int sanity)
        {
            SanityChanges.Add(sanity);
        }

        public void OnInventoryItemShown(Item item)
        {
            InventoryShown.Add(item);
        }
    }
}
