using System;
using System.Text;
using System.Threading;
using LabyrinthExplorer;
using GameplayNamespace;
using Handlers;
using Utilities;

namespace Handlers
{
    public class SelectionHandler : GameplayNamespace.Gameplay
    {
        public new void NewGame()
        {
            Print("\n----------------------------------------------------\n");
            Print("~~~~~~  Welcome to the Labyrinth  ~~~~~~");
            Print("\n----------------------------------------------------\n\n");
            Print("No two rooms lead to the same place nor can you\n");
            Print("backtrack to where you were.\n");
            Print("The Labyrinth is alive and there is only one way out.\n");
            Print("Good luck adventurer! We hope you can find the way out.\n");
            Print("\n----------------------------------------------------\n");
            GameLoop.ExploreNewRoom();
        }

        public static void Actions()
        {
            while (true)
            {
                StringBuilder sb = new StringBuilder();

                foreach (string action in actions)
                {
                    sb.Append($"[{action}]");
                }

                Print($"\n[Actions ~|{sb.ToString()}|~ ]");

                Print("\n#>| ");
                _Input = Console.ReadLine() ?? "";
                _Input = Capitalize(_Input.ToLower());

                Thread.Sleep(500);

                ReadInput(_Input);
            }
        }

        protected static void ReadInput(string input)
        {
            switch (input)
            {
                case "Search":
                    Search.Room(_RoomCard);
                    break;
                case "Take":
                    Take.RmCard(_RoomCard);
                    break;
                case "Inventory":
                    Player.ShowInvetory();
                    break;
                case "North":
                    CheckDoor(input);
                    break;
                case "East":
                    CheckDoor(input);
                    break;
                case "West":
                    CheckDoor(input);
                    break;
                case "South":
                    CheckDoor(input);
                    break;
                case "Quit":
                case "Leave":
                    Console.Clear();
                    Menu._Main();
                    break;
                default:
                    Print("\nThat command is not recognized.");
                    Console.ReadKey();
                    Print("\n\n");
                    break;
            }

        }
    }
}