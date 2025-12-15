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

            bool running = true;

            while (running)
            {
                _session.GameplayData.UserActions = new List<string>() { "new", "load", "quit" };
                StringBuilder sb = new StringBuilder();
                sb.Append(CommandRegistry.FormatActions(_session.GameplayData.UserActions));

                Printf("\n\n");
                Printf($"\n[  Version: {version}  ]\n");
                Printf("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                Printf("~~~~~~~~~~ Labyrinth Explorer ~~~~~~~~~~\n");
                Printf("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
                Printf("~~~~~~~~~~~~~~~~~~~~~\n");
                Printf("~~~~~ Main Menu ~~~~~\n");
                Printf("~~~~~~~~~~~~~~~~~~~~~");
                Printf($"{sb}\n");
                Printf("\n#>| ");

                string input = _session.Console.ReadLine();

                if (!CommandRegistry.TryMapMenu(input, out var command))
                {
                    _session.Console.Clear();
                    continue;
                }

                switch (command)
                {
                    case "new":
                        _session.Console.Clear();
                        _gameplay.NewGame();
                        running = false;
                        break;
                    case "load":
                        Printf("\n\nThis option is not ready yet.");
                        Printf("\n#>| ");
                        _session.Console.ReadKey(true);
                        _session.Console.Clear();
                        _session.Console.Sleep(500);
                        break;
                    case "quit":
                        _gameplay.Quit();
                        running = false;
                        break;
                }
            }
        }

        private void Printf(string s) => _session.Console.Write(s);
    }
}
