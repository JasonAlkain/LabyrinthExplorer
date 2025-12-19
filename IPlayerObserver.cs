using System;
using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer
{
    public interface IPlayerObserver
    {
        void OnSanityChanged(Player player, int sanity);

        void OnInventoryItemShown(Item item);
    }

    public class NullPlayerObserver : IPlayerObserver
    {
        public void OnSanityChanged(Player player, int sanity)
        {
        }

        public void OnInventoryItemShown(Item item)
        {
        }
    }

    public class ConsolePlayerObserver : IPlayerObserver
    {
        private readonly IConsoleService _console;

        public ConsolePlayerObserver(IConsoleService console)
        {
            _console = console ?? throw new ArgumentNullException(nameof(console));
        }

        public void OnSanityChanged(Player player, int sanity)
        {
            _console.Write($"Sanity changed to: {sanity}");
        }

        public void OnInventoryItemShown(Item item)
        {
            _console.Write($"[ {item.Name} ] ");
        }
    }
}
