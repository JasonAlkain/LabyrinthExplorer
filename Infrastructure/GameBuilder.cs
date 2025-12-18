using System;
using GameplayNamespace;
using Handlers;
using LabyrinthExplorer.Gameplay;
using LabyrinthExplorer.Handlers;
using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer.Infrastructure
{
    public class GameBuilderOptions
    {
        public IConsoleService? ConsoleService { get; set; }

        public IRandomProvider? RandomProvider { get; set; }

        public IGameStateStore? StateStore { get; set; }

        public PlayerData? PlayerData { get; set; }

        public int? Seed { get; set; }
    }

    public static class GameBuilder
    {
        public static GameApplication Build(GameBuilderOptions? options = null)
        {
            options ??= new GameBuilderOptions();

            var console = options.ConsoleService ?? new SystemConsoleService();
            var randomProvider = options.RandomProvider ?? new RandomProvider(options.Seed);
            var playerData = options.PlayerData ?? options.StateStore?.LoadPlayer() ?? new PlayerData();

            var session = new GameSession(console, randomProvider, playerData);
            var gameplay = new BaseGameplay(session);
            var gameLoop = new GameLoop(session, gameplay);
            var selectionHandler = new SelectionHandler(session, gameplay, gameLoop);

            var application = new GameApplication(session, gameplay, gameLoop, selectionHandler, options.StateStore);
            application.Configure();

            return application;
        }
    }

    public class GameApplication : IDisposable
    {
        private readonly GameSession _session;
        private readonly BaseGameplay _gameplay;
        private readonly GameLoop _gameLoop;
        private readonly SelectionHandler _selectionHandler;
        private readonly IGameStateStore? _stateStore;
        private bool _configured;
        private bool _disposed;

        internal GameApplication(GameSession session, BaseGameplay gameplay, GameLoop gameLoop, SelectionHandler selectionHandler, IGameStateStore? stateStore)
        {
            _session = session;
            _gameplay = gameplay;
            _gameLoop = gameLoop;
            _selectionHandler = selectionHandler;
            _stateStore = stateStore;
        }

        public GameSession Session => _session;

        public BaseGameplay Gameplay => _gameplay;

        public GameLoop GameLoop => _gameLoop;

        public SelectionHandler SelectionHandler => _selectionHandler;

        public void Configure()
        {
            if (_configured)
            {
                return;
            }

            _gameplay.RegisterGameLoop(_gameLoop);
            _gameLoop.RegisterSelectionHandler(_selectionHandler);
            _selectionHandler.RegisterMenu(RunMenu);

            _configured = true;
        }

        public void Run()
        {
            if (!_configured)
            {
                Configure();
            }

            _gameplay.Setup();
            RunMenu();
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
                PersistState();
                _session.Dispose();
            }

            _disposed = true;
        }

        private void RunMenu()
        {
            var menu = new Menu(_session, _gameplay, _gameLoop, _selectionHandler);
            menu.Run();
            PersistState();
        }

        private void PersistState()
        {
            if (_stateStore == null)
            {
                return;
            }

            var playerData = _session.CapturePlayerState();
            _stateStore.SavePlayer(playerData);
        }
    }
}
