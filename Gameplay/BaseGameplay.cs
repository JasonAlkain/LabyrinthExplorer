using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Enums;
using LabyrinthExplorer.Data;
using LabyrinthExplorer.Utilities;
using Utilities;
using GameplayNamespace;

namespace LabyrinthExplorer.Gameplay
{
    public class BaseGameplay
    {
        // ====================================================================================================
        // Functions
        // ====================================================================================================
        public static void Printf(string s) => GameConsole.Printf(s);
        
        

        /// <summary>
        /// 
        /// </summary>
        public static void Setup()
        {
            //new Player();
            int nameIndex = new Random().Next(0, Names.ListOfNames.Count - 1);
            new Player();

            Player.Name = Names.ListOfNames[nameIndex];
            new GameplayData();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Quit()
        {
            Console.Clear();
            Printf("\n\n\n\n");
            Printf("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Printf("~~~~~ Thank you for playing! ~~~~~\n");
            Printf("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            Thread.Sleep(1500);
            Environment.Exit(0);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void NewGame()
        {
            Printf("\n----------------------------------------------------\n");
            Printf("~~~~~~  Welcome to the Labyrinth  ~~~~~~");
            Printf("\n----------------------------------------------------\n\n");
            Printf("No two rooms lead to the same place nor can you\n");
            Printf("backtrack to where you were.\n");
            Printf("The Labyrinth is alive and there is only one way out.\n");
            Printf("Good luck adventurer! We hope you can find the way out.\n");
            Printf("\n----------------------------------------------------\n");

            Thread.Sleep(3250);

            var bag = new Card() { Name = "Bag", Description = "Somthing to hold things." };

            Player.Inventory.Add(bag);

            GameLoop.ExploreNewRoom();
        }

        public static void BaseActions()
        {
            // Set up basic Actions for each new _Room
            var actions = new List<string>
            {
                "(L)eave/(Q)uit",
                "Look",
                "(N)orth",
                "(E)ast",
                "(W)est",
                "(S)outh",
                "(I)nventory"
            };
            
            if(GameplayData.RoomRef.bSearched == false)
                actions.Add("Search");

            if(GameplayData.RoomRef.HasCard)
                actions.Add("Take");

            GameplayData.UserActions = actions;
        }

        public static void CheckDoor(string doorName)
        {
            switch (GameplayData.RoomRef.Doors[doorName])
            {
                case DoorWayType.Open:
                    Printf("\nYou try the door and with some luck it opens.\n\n");
                    GameLoop.ExploreNewRoom();
                    break;
                case DoorWayType.Blocked:
                    Printf("The door is blocked board and won't budge.\n");
                    break;
                case DoorWayType.Locked:
                    Printf("You try the door but to no avail.\n" +
                          "It is locked and won't open.\n");
                    break;
                case DoorWayType.None:
                    Printf("You examine the frame and see it looks\n" +
                          " more like it is built into the wall.\n");
                    break;
            }

        }

        public static void PrintDoors()
        {

            // Print what the doors look like
            foreach (var door in GameplayData.RoomRef.Doors)
            {
                string doorAvail = "";
                switch (door.Value)
                {
                    case DoorWayType.None:
                        doorAvail += "-] There is a frame but no door.\n";
                        doorAvail += "-] Like a random frame was put on the wall.\n";
                        break;
                    case DoorWayType.Blocked:
                        doorAvail += "-] The door has a board nailed to the frame.\n";
                        doorAvail += "-] Covering the door and preventing it from moving.\n";
                        break;
                    case DoorWayType.Open:
                        doorAvail += "-] This door has a normal looking handle.\n";
                        doorAvail += "-] Maybe it will lead somewhere.\n";
                        break;
                    case DoorWayType.Locked:
                        doorAvail += "-] This door has a normal looking handle.\n";
                        doorAvail += "-] Maybe it will lead somewhere.\n";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Printf($"The door frame {door.Key}:\n{doorAvail}\n");

                Thread.Sleep(1250);
            }
        }

        public static string ReadInput()
        {
            StringBuilder sb = new();

            foreach (string action in GameplayData.UserActions)
            {
                sb.Append($"[{action}]");
            }

            Printf($"\n[Actions ~|{sb}|~ ]");

            Printf("\n#>| ");
            //GameplayData.Input = Console.ReadLine() ?? "";
            var userIn = Console.ReadLine() ?? "";
            GameplayData.UserInput.Prop = userIn;

            Thread.Sleep(500);

            return Utils.Capitalize(GameplayData.UserInput.Prop.ToLower());
        }
    }
}