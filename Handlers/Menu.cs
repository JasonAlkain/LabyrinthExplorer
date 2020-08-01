using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using LabyrinthExplorer;
using Enums;
using GameplayNamespace;

namespace Handlers
{
    public class Menu : Gameplay
    {
        public static void _Main()
        {
            actions = new List<string>() { "New Game", "Load", "Quit"};
            StringBuilder sb = new StringBuilder();

            foreach (string action in actions)
            {
                sb.Append($"[{action}]");
            }

            Print("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Print("~~ Main Menu ~~\n");
            Print($"\n[Actions ~|{sb.ToString()}|~ ]");
            Print("\n#>| ");

            _Input = Console.ReadLine() ?? " ";
            _Input = _Input.ToLower();

            switch (_Input)
            {
                case "new":
                case "new game":
                    Console.Clear();
                    NewGame();
                    break;
                case "load":
                    Print("\n\nThis option is not ready yet.");
                    Print("\n#>| ");
                    Console.ReadKey();
                    Console.Clear();
                    Thread.Sleep(500);
                    _Main();
                    break;
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