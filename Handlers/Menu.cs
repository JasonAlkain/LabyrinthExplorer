using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using GameplayNamespace;
using static System.Collections.Specialized.BitVector32;

namespace Handlers
{
    public class Menu : Gameplay
    {
        public static void _Main()
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            actions = new List<string>() { "New Game", "Load", "Quit"};
            StringBuilder sb = new StringBuilder();
            actions.ForEach(action => sb.Append($"\n [{action}]"));

            Print("\n\n");
            Print($"\n[  Version: {version}  ]\n");
            Print("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Print("~~~~~~~~~~ Labyrinth Explorer ~~~~~~~~~~\n");
            Print("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            Print("~~~~~~~~~~~~~~~~~~~~~\n");
            Print("~~~~~ Main Menu ~~~~~\n");
            Print("~~~~~~~~~~~~~~~~~~~~~");
            Print($"{sb.ToString()}\n");
            Print("\n#>| ");

            _Input = Console.ReadLine() ?? " ";
            _Input = _Input.ToLower();

            switch (_Input)
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
                    Print("\n\nThis option is not ready yet.");
                    Print("\n#>| ");
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