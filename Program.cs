using GameplayNamespace;
using Handlers;
using LabyrinthExplorer.Gameplay;
using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var console = new SystemConsoleService();
            var session = GameSession.CreateDefault(console: console);

            var gameplay = new BaseGameplay(session);
            var gameLoop = new GameLoop(session, gameplay);
            var selectionHandler = new SelectionHandler(session, gameplay, gameLoop);

            gameplay.RegisterGameLoop(gameLoop);
            gameLoop.RegisterSelectionHandler(selectionHandler);
            selectionHandler.RegisterMenu(() =>
            {
                var menuFromGame = new Menu(session, gameplay, gameLoop, selectionHandler);
                menuFromGame.Run();
            });

            gameplay.Setup();

            var menu = new Menu(session, gameplay, gameLoop, selectionHandler);
            menu.Run();
        }
    }
}
