using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer.Gameplay
{
    public class GameSession
    {
        public GameSession(IConsoleService consoleService, IRandomProvider? randomProvider = null)
        {
            Console = consoleService;
            RandomProvider = randomProvider ?? new RandomProvider();
            Player = new Player(Console);
            GameplayData = new GameplayData();
        }

        public IConsoleService Console { get; }

        public IRandomProvider RandomProvider { get; }

        public Player Player { get; }

        public GameplayData GameplayData { get; }

        public static GameSession CreateDefault(int? seed = null, IConsoleService? console = null)
        {
            var randomProvider = new RandomProvider(seed);
            return new GameSession(console ?? new SystemConsoleService(), randomProvider);
        }
    }
}
