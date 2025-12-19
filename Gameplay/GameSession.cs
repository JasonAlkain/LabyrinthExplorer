using System;
using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer.Gameplay
{
    public class GameSession : IDisposable
    {
        private bool _disposed;

        public GameSession(
            IConsoleService consoleService,
            IRandomProvider? randomProvider = null,
            PlayerData? playerData = null,
            IPlayerObserver? playerObserver = null,
            IPlayerStateMapper? playerStateMapper = null)
        {
            Console = consoleService;
            RandomProvider = randomProvider ?? new RandomProvider();
            var mapper = playerStateMapper ?? new PlayerStateMapper();
            var observer = playerObserver ?? new ConsolePlayerObserver(Console);
            Player = new Player(mapper, observer, playerData ?? new PlayerData());
            GameplayData = new GameplayData();
        }

        public IConsoleService Console { get; }

        public IRandomProvider RandomProvider { get; }

        public Player Player { get; }

        public GameplayData GameplayData { get; }

        public PlayerData CapturePlayerState()
        {
            return Player.ToData();
        }

        public void RestorePlayerState(PlayerData playerData)
        {
            Player.LoadFromData(playerData);
        }

        public static GameSession CreateDefault(int? seed = null, IConsoleService? console = null)
        {
            var randomProvider = new RandomProvider(seed);
            return new GameSession(console ?? new SystemConsoleService(), randomProvider);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Player.Dispose();
            }

            _disposed = true;
        }

        ~GameSession()
        {
            Dispose(false);
        }
    }
}
