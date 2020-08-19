using System;
using System.Collections.Generic;
using Enums;
using LabyrinthExplorer;
using GameplayNamespace;

namespace Handlers
{
    public class SelectionHandler : Gameplay
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
                BaseActions();
                InterpretInput(ReadInput());
            }
        }

        protected static void InterpretInput(string input)
        {

            switch (input)
            {
                case "Dev":
                    DevOptions();
                    break;
                case "Use":
                    Print("Not available yet.\n");
                    break;
                case "Look":
                    Print("\n");
                    PrintDoors();
                    break;
                case "Search":
                    Search.Room();
                    break;
                case "Take":
                    Take.RmCard(_RoomCard);
                    break;
                case "I":
                case "Inventory":
                    Player.ShowInvetory();
                    break;
                case "N":
                case "North":
                    input = "North";
                    CheckDoor(input);
                    break;
                case "E":
                case "East":
                    input = "East";
                    CheckDoor(input);
                    break;
                case "W":
                case "West":
                    input = "West";
                    CheckDoor(input);
                    break;
                case "S":
                case "South":
                    input = "South";
                    CheckDoor(input);
                    break;
                case "Q":
                case "L":
                case "Quit":
                case "Leave":
                    LeaveGame();
                    break;
                default:
                    Print("\nThat command is not recognized.");
                    Console.ReadKey();
                    Print("\n\n");
                    break;
            }

        }

        protected static void DevOptions()
        {
            actions = new List<string>();
            actions.Add("Item");
            actions.Add("Omen");
            actions.Add("Leave");
            actions.Add("Set Max Room Count");
            while (true)
            {

                Print("What would you like to do?");
                string input = ReadInput();
                input = Capitalize(input);

                switch (input)
                {
                    case "Item":
                        Player.Cards.Add(CardType.Item);
                        Print("~{Added an item to your inventory}~.\n");
                        break;
                    case "Omen":
                        Player.Cards.Add(CardType.Omen);
                        Print("~{Added an Omen card to your inventory}~.\n");
                        break;
                    case "Leave":
                        Actions();
                        break;
                    case "Max":
                        roomCount = UInt32.MaxValue-1;
                        break;
                    default:
                        Print("\nThat command is not recognized.");
                        Console.ReadKey();
                        Print("\n\n");
                        break;
                }
            }

        }

        public static void LeaveGame()
        {
            Print("Are you sure you want to leave the game?");
            Print("You will have to start from square one if you do.");

            actions = new List<string>() { "Yes", "No" };

            switch (ReadInput())
            {
                case "Yes":
                    Console.Clear();
                    Menu._Main();
                    break;
                case "No":
                    Actions();
                    break;
                default:
                    Print("\nThat command is not recognized.");
                    Console.ReadKey();
                    Print("\n\n");
                    break;
            }


        }
    }

    // I don't know why this is here yet.
    // But I might someday.
    internal class SelectionHandlerImpl : SelectionHandler
    {
    }
}
