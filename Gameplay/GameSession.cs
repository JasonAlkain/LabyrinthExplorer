using System;
using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer.Gameplay
{
    public class GameSession
    {
        public GameSession(IConsoleService consoleService, Random? random = null)
        {
            Console = consoleService;
            Random = random ?? new Random();
            Player = new Player(Console);
            GameplayData = new GameplayData();
        }

        public IConsoleService Console { get; }

        public Random Random { get; }

        public Player Player { get; }

        public GameplayData GameplayData { get; }

        public static GameSession CreateDefault(int? seed = null, IConsoleService? console = null)
        {
            var random = seed.HasValue ? new Random(seed.Value) : new Random();
            return new GameSession(console ?? new SystemConsoleService(), random);
        }
    }
}
