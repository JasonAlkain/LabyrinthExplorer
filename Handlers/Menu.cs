using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using GameplayNamespace;

namespace Handlers
{
    public class Menu : Gameplay
    {
        public static void _Main()
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            GameplayData.actions = new List<string>() { "New Game", "Load", "Quit"};
            StringBuilder sb = new StringBuilder();
            GameplayData.actions.ForEach(action => sb.Append($"\n [{action}]"));

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

            GameplayData._Input = Console.ReadLine() ?? " ";
            GameplayData._Input = GameplayData._Input.ToLower();

            switch (GameplayData._Input)
            {
                case "n":
                case "new":
                case "new game":
                    Console.Clear();
                    NewGame();
                    break;
                case "l":
                case "load":
                case "load game":
                    Printf("\n\nThis option is not ready yet.");
                    Printf("\n#>| ");
                    Console.ReadKey();
                    Console.Clear();
                    Thread.Sleep(500);
                    _Main();
                    break;
                case "e":
                case "q":
                case "exit":
                case "quit":
                    Quit();
                    break;
                default:
                    Console.Clear();
                    _Main();
                    break;

            }
        }


    }
}