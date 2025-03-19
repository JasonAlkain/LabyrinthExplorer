using System;
using System.Collections.Generic;
using Enums;
using GameplayNamespace;
using LabyrinthExplorer.Utilities;
using LabyrinthExplorer;

namespace LabyrinthExplorer
{
    public class Room : RoomBase
    {
        static Dictionary<string, DoorWayType> mDoor { get; set; }
        /// <summary>
        /// Creates a new room from scratch.
        /// </summary>
        [Obsolete("Use GenerateRoom instead")]
        public void CreateRoom()
        {
            if(RoomID < uint.MaxValue-1)
                RoomID++;

            bSearched = false;

            Doors = new Dictionary<string, DoorWayType>
            {
                { "North", GenerateDoorType() },
                { "East", GenerateDoorType() },
                { "West", GenerateDoorType() },
                { "South", GenerateDoorType() }
            };

            // Check if there is at least one open door
            if (!Doors.ContainsValue(DoorWayType.Open))
                Doors["North"] = DoorWayType.Open; // if not make it the forward door

            Header = SetRoomHeader();
            Description = SetRoomDesc();

            // Print the info to the console
            string s = "\n----------------------------------------------------\n";
            s += $"~~~~~~  {Header}  ~~~~~~";
            s += "\n----------------------------------------------------\n";
            s += Description;
            s += "----------------------------------------------------\n";
            GameConsole.Printf(s);

            Card = RoomID > 0 ? GenerateCardType() : CardType.None;

            //Have an Event happen when the room has an event card type
        }
        // Improved method for Room.cs
        public void GenerateRoom()
        {
            if (RoomID < uint.MaxValue - 1)
                RoomID++;

            bSearched = false;

            // Initialize all doors as None
            Doors = new Dictionary<string, DoorWayType>
            {
                { "North", DoorWayType.None },
                { "East", DoorWayType.None },
                { "West", DoorWayType.None },
                { "South", DoorWayType.None }
            };

            // Generate a random number of doors (1-3)
            int doorCount = new Random().Next(1, 4);
            List<string> directions = ["North", "East", "West", "South"];

            // Ensure at least one door is open
            string randomDirection = directions[new Random().Next(directions.Count)];
            Doors[randomDirection] = DoorWayType.Open;
            directions.Remove(randomDirection);
            doorCount--;

            // Add additional doors randomly
            while (doorCount > 0 && directions.Count > 0)
            {
                randomDirection = directions[new Random().Next(directions.Count)];
                Doors[randomDirection] = (DoorWayType)new Random().Next(0, 3); // Exclude None (-1)
                directions.Remove(randomDirection);
                doorCount--;
            }

            Header = SetRoomHeader();
            Description = SetRoomDesc();

            // Print room information to console
            string roomInfo = $"\n----------------------------------------------------\n";
            roomInfo += $"~~~~~~  {Header}  ~~~~~~\n";
            roomInfo += "----------------------------------------------------\n";
            roomInfo += $"{Description}";
            roomInfo += "----------------------------------------------------\n";
            GameConsole.Printf(roomInfo);

            Card = RoomID > 0 ? GenerateCardType() : CardType.None;
        }


        string SetRoomHeader()
        {
            // Check if this is the first _Room and set the opening accordingly 
            return RoomID < 2 ? "You have entered the Labyrinth." : "You explore a new room.";
        }

        string SetRoomDesc()
        {
            string roomDesc = "";

            // Check if this is the first _Room and set the opening accordingly 
            if (RoomID < 2)
            {

                roomDesc += "You find yourself in a square room. \n";
                roomDesc += "Each wall has a door frame.\n";
                roomDesc += "There is a table in the center of the room.\n";
                roomDesc += "On the table is an empty bag.\n";
                roomDesc += "You take the bag and sling it over your shoulders.\n";
                roomDesc += $"There is a number on the ceiling, {RoomID}.\n";
                roomDesc += "\n";
            }
            else
            {
                roomDesc += "This room is unsettling similar to the last. \n";
                roomDesc += "It's a little different from the previous room.\n";
                roomDesc += "The door behind you closes hard.\n";
                roomDesc += "You hear a click come from the door.\n";
                roomDesc += $"There is a number on the ceiling, {RoomID}.\n\n";
            }

            return roomDesc;
        }

        /// <summary>
        /// Returns a random DoorType
        /// </summary>
        /// <returns>Random DoorType</returns>
        public static DoorWayType GenerateDoorType()
        {
            return (DoorWayType)new Random().Next(-1, 3);
        }

        /// <summary>
        /// Returns a random CardType.
        /// </summary>
        /// <returns>Random CardType</returns>
        public static CardType GenerateCardType()
        {
            return (CardType)new Random().Next(0, 4);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="doorName"></param>
        [Obsolete("Please check else where?")]
        public static void CheckDoor(string doorName, Dictionary<string, DoorWayType> doors)
        {
            switch (doors[doorName])
            {
                case DoorWayType.Open:
                    GameConsole.Printf("\nYou try the door and with some luck it opens.\n\n");
                    GameLoop.ExploreNewRoom();
                    break;
                case DoorWayType.Blocked:
                    GameConsole.Printf("The door is blocked board and won't budge.\n");
                    break;
                case DoorWayType.Locked:
                    GameConsole.Printf("You try the door but to no avail.\n" +
                          "It is locked and won't open.\n");
                    break;
                case DoorWayType.None:
                    GameConsole.Printf("You examine the frame and see it looks\n" +
                          " more like it is built into the wall.\n");
                    break;
            }

        }
    }
}
