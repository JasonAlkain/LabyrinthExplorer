using System;
using System.Collections.Generic;
using Enums;
using LabyrinthExplorer;
using GameplayNamespace;
using LabyrinthExplorer.Data;
using System.Diagnostics;

namespace Handlers
{
    public class SelectionHandler : Gameplay
    {

        public string userInput = string.Empty;

        [Obsolete("Use NewGame funtion from the Gameplay class instead.")]
        public new void NewGame()
        {
            Printf("\n----------------------------------------------------\n");
            Printf("~~~~~~  Welcome to the Labyrinth  ~~~~~~");
            Printf("\n----------------------------------------------------\n\n");
            Printf("No two rooms lead to the same place nor can you\n");
            Printf("backtrack to where you were.\n");
            Printf("The Labyrinth is alive and there is only one way out.\n");
            Printf("Good luck adventurer! We hope you can find the way out.\n");
            Printf("\n----------------------------------------------------\n");
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
            if (GameplayData.actions.Contains(input))
            {
                if (input == "Dev")
                {
                    DevOptions();
                    return;
                }

                switch (input)
                {
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
                    case "Use":
                        Printf("Not available yet.\n");
                        break;
                    case "Look":
                        Printf("\n");
                        PrintDoors();
                        break;
                    case "Search":
                        Search.Room();
                        break;
                    case "Take":
                        Take.DrawCard(GameplayData._RoomCard);
                        break;
                    case "I":
                    case "Inventory":
                        Player.ShowInvetory();
                        break;
                    case "Q":
                    case "L":
                    case "Quit":
                    case "Leave":
                        LeaveGame();
                        break;
                    default:
                        Printf("\nThat command is not recognized.");
                        Console.ReadKey();
                        Printf("\n\n");
                        break;
                }
            }
            else
            {
                Printf("\nThat command is not recognized.");
                Console.ReadKey();
                Printf("\n\n");
            }


        }

        protected static void DevOptions()
        {
            GameplayData.actions = ["Item", "Omen", "Leave"];
            Random rnd = new Random();
            while (true)
            {
                int index = 0;
                Printf("What would you like to do?");
                string input = ReadInput();

                switch (input)
                {
                    case "Item":
                        index = rnd.Next(0, BaseCardList.ItemCards.Count-1);
                        Player.Inventory.Add(BaseCardList.ItemCards[index]);
                        Printf("~{Added an item to your inventory}~.\n");
                        Printf($"~{BaseCardList.ItemCards[index].Name}~.\n");
                        break;
                    case "Omen":
                        index = rnd.Next(0, BaseCardList.OmenCards.Count-1);
                        Player.Inventory.Add(BaseCardList.OmenCards[index]);
                        Printf("~{Added an Omen card to your inventory}~.\n");
                        Printf($"~{BaseCardList.OmenCards[index].Name}~.\n");
                        break;
                    case "Leave":
                        Actions();
                        break;
                    default:
                        Printf("\nThat command is not recognized.");
                        Console.ReadKey();
                        Printf("\n\n");
                        break;
                }
            }

        }

        public static void LeaveGame()
        {
            Printf("Are you sure you want to leave the game?");
            Printf("You will have to start from square one if you do.");

            GameplayData.actions = new List<string>() { "Yes", "No" };

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
                    Printf("\nThat command is not recognized.");
                    Console.ReadKey();
                    Printf("\n\n");
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
