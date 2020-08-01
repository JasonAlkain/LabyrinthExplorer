using System;
using System.Collections.Generic;
using System.Threading;
using Enums;
using Handlers;
using GameplayNamespace;

namespace GameplayNamespace
{
    public class GameLoop : Gameplay
    {

        public static void ExploreNewRoom()
        {
            // Pause for effect
            Thread.Sleep(1000);

            // Create local variables
            string roomIntro = "";
            string roomDesc = "";

            // Increment room count
            roomCount++;

            // Set up the Actions first available in the room
            actions = new List<string>()
                {
                    "North",
                    "East",
                    "West",
                    "South",
                    "Inventory",
                    "Search"
                };

            // Create a new room for the player to explore
            room.CreateRoom();

            // Check if there is at least one open door
            if (!room.Doors.ContainsValue(DoorWay.Open))
                room.Doors["North"] = DoorWay.Open; // if not make it the forward door

            // Check if this is the first room and set the opening accordingly 
            if (roomCount < 2)
            {
                roomIntro = "You have entered the Labyrinth.";

                roomDesc += "You find yourself in a square room. \n";
                roomDesc += "Each wall has a door frame.\n";
                roomDesc += "There is a table in the center of the room.\n";
                roomDesc += "On the table is an empty bag.\n";
                roomDesc += "You take the bag and sling it over your shoulders.\n";
                roomDesc += $"There is a number on the ceiling that reads {roomCount}.\n";
                roomDesc += "\n";

                room.Card = CardType.None;
                actions.Remove("Search");
            }
            else
            {
                roomIntro = "You explore a new room.";

                roomDesc += "You are in a new room. \n";
                roomDesc += "It's a little different from the previous room.\n";
                roomDesc += "The door behind you closes hard.\n";
                roomDesc += "You hear a click come from the door.\n";
                roomDesc += $"There is a number on the ceiling that reads {roomCount}.\n";
                roomDesc += "\n";
            }

            // Print the info to the console
            Print("\n----------------------------------------------------\n");
            Print($"~~~~~~  {roomIntro}  ~~~~~~");
            Print("\n----------------------------------------------------\n");
            Print(roomDesc);

            // Once created set the current room card to an instance for later
            _RoomCard = room.Card;

            Thread.Sleep(1250);
            PrintDoors();

            // Start the actions phase from the Selection Handler
            SelectionHandler.Actions();
        }

        protected static void PrintDoors()
        {

            // Print what the doors look like
            foreach (var door in room.Doors)
            {
                string doorAvail = "";
                switch (door.Value)
                {
                    case DoorWay.None:
                        doorAvail += "-] There is a frame but no door.\n";
                        doorAvail += "-] Like a random frame was put on the wall.\n";
                        break;
                    case DoorWay.Blocked:
                        doorAvail += "-] The door had a board nailed to the frame.\n";
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
    }
}