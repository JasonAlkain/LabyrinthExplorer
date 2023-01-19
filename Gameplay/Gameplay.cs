using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using LabyrinthExplorer;
using Enums;
using LabyrinthExplorer.Data;

namespace GameplayNamespace
{
    public class Gameplay : GameplayData
    {

        public void Setup()
        {
            Player.Cards = new List<CardType>();
            Player.Inventory = new List<Card>();

            GameplayData.CardList = new List<Card>();
        }

        protected static void Quit()
        {
            Console.Clear();
            Print("\n\n\n\n");
            Print("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Print("~~~~~ Thank you for playing! ~~~~~\n");
            Print("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            Thread.Sleep(1500);
            Environment.Exit(0);
        }

        protected static void NewGame()
        {
            Print("\n----------------------------------------------------\n");
            Print("~~~~~~  Welcome to the Labyrinth  ~~~~~~");
            Print("\n----------------------------------------------------\n\n");
            Print("No two rooms lead to the same place nor can you\n");
            Print("backtrack to where you were.\n");
            Print("The Labyrinth is alive and there is only one way out.\n");
            Print("Good luck adventurer! We hope you can find the way out.\n");
            Print("\n----------------------------------------------------\n");

            Thread.Sleep(3250);

            Player.Inventory.Add(new Card(){Name = "Bag"});

            GameLoop.ExploreNewRoom();
        }

        protected static void BaseActions()
        {

            // Set up basic Actions for each new _Room
            actions = new List<string>();
            
            actions.Add("(L)eave/(Q)uit");
            actions.Add("Look");
            actions.Add("(N)orth");
            actions.Add("(E)ast");
            actions.Add("(W)est");
            actions.Add("(S)outh");
            actions.Add("(I)nventory");
            
            if(_Room.bSearched == false)
                actions.Add("Search");

            if(_Room.HasCard)
                actions.Add("Take");
        }

        public static void CheckDoor(string doorName)
        {
            switch (_Room.Doors[doorName])
            {
                case DoorWay.Open:
                    Print("\nYou try the door and with some luck it opens.\n\n");
                    GameLoop.ExploreNewRoom();
                    break;
                case DoorWay.Blocked:
                    Print("The door is blocked board and won't budge.\n");
                    break;
                case DoorWay.Locked:
                    Print("You try the door but to no avail.\n" +
                          "It is locked and won't open.\n");
                    break;
                case DoorWay.None:
                    Print("You examine the frame and see the frame looks\n" +
                          " more like it is built into the wall.\n");
                    break;
            }

        }

        public static void PrintDoors()
        {

            // Print what the doors look like
            foreach (var door in _Room.Doors)
            {
                string doorAvail = "";
                switch (door.Value)
                {
                    case DoorWay.None:
                        doorAvail += "-] There is a frame but no door.\n";
                        doorAvail += "-] Like a random frame was put on the wall.\n";
                        break;
                    case DoorWay.Blocked:
                        doorAvail += "-] The door has a board nailed to the frame.\n";
                        doorAvail += "-] Covering the door and preventing it from moving.\n";
                        break;
                    case DoorWay.Open:
                        doorAvail += "-] This door has a normal looking handle.\n";
                        doorAvail += "-] Maybe it will lead somewhere.\n";
                        break;
                    case DoorWay.Locked:
                        doorAvail += "-] This door has a normal looking handle.\n";
                        doorAvail += "-] Maybe it will lead somewhere.\n";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Print($"The door frame {door.Key}:\n{doorAvail}\n");

                Thread.Sleep(1250);
            }
        }

        public static string ReadInput()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string action in actions)
            {
                sb.Append($"[{action}]");
            }

            Print($"\n[Actions ~|{sb}|~ ]");

            Print("\n#>| ");
            _Input = Console.ReadLine() ?? "";

            Thread.Sleep(500);

            return Capitalize(_Input.ToLower());
        }
    }
}