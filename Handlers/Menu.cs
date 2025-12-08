using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using LabyrinthExplorer.Gameplay;
using LabyrinthExplorer.Utilities;

namespace Handlers
{
    public class Menu
    {
        private readonly GameSession _session;
        private readonly BaseGameplay _gameplay;
        private readonly GameLoop _gameLoop;
        private readonly SelectionHandler _selectionHandler;

        public Menu(GameSession session, BaseGameplay gameplay, GameLoop gameLoop, SelectionHandler selectionHandler)
        {
            _session = session;
            _gameplay = gameplay;
            _gameLoop = gameLoop;
            _selectionHandler = selectionHandler;
        }

        public void Run()
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            _session.GameplayData.UserActions = new List<string>() { "New Game", "Load", "Quit" };
            StringBuilder sb = new StringBuilder();
            _session.GameplayData.UserActions.ForEach(action => sb.Append($"\n [{action}]"));

            Printf("\n\n");
            Printf($"\n[  Version: {version}  ]\n");
            Printf("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Printf("~~~~~~~~~~ Labyrinth Explorer ~~~~~~~~~~\n");
            Printf("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            Printf("~~~~~~~~~~~~~~~~~~~~~\n");
            Printf("~~~~~ Main Menu ~~~~~\n");
            Printf("~~~~~~~~~~~~~~~~~~~~~");
            Printf($"{sb.ToString()}\n");
            Printf("\n#>| ");

            _session.GameplayData.Input = _session.Console.ReadLine();
            _session.GameplayData.Input = _session.GameplayData.Input.ToLower();

            switch (_session.GameplayData.Input)
            {
                case "n":
                case "new":
                case "new game":
                    _session.Console.Clear();
                    _gameplay.NewGame();
                    break;
                case "l":
                case "load":
                case "load game":
                    Printf("\n\nThis option is not ready yet.");
                    Printf("\n#>| ");
                    _session.Console.ReadKey(true);
                    _session.Console.Clear();
                    _session.Console.Sleep(500);
                    Run();
                    break;
                case "e":
                case "q":
                case "exit":
                case "quit":
                    _gameplay.Quit();
                    break;
                default:
                    _session.Console.Clear();
                    Run();
                    break;

            }
        }

        private void Printf(string s) => _session.Console.Write(s);
    }
}
