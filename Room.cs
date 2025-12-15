using System;
using System.Collections.Generic;
using Enums;
using GameplayNamespace;
using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer
{
    public class Room : RoomBase
    {
        static Dictionary<string, DoorWayType> mDoor { get; set; }
        [Obsolete("Use GenerateRoom instead")]
        public void CreateRoom(IRandomProvider randomProvider)
        {
            if (RoomID < uint.MaxValue - 1)
                RoomID++;

            bSearched = false;

            Doors = new Dictionary<string, DoorWayType>
            {
                { "North", GenerateDoorType(randomProvider) },
                { "East", GenerateDoorType(randomProvider) },
                { "West", GenerateDoorType(randomProvider) },
                { "South", GenerateDoorType(randomProvider) }
            };

            if (!Doors.ContainsValue(DoorWayType.Open))
                Doors["North"] = DoorWayType.Open;

            Header = SetRoomHeader();
            Description = SetRoomDesc();

            string s = "\n----------------------------------------------------\n";
            s += $"~~~~~~  {Header}  ~~~~~~";
            s += "\n----------------------------------------------------\n";
            s += Description;
            s += "----------------------------------------------------\n";
            GameConsole.Printf(s);

            Card = RoomID > 0 ? GenerateCardType(randomProvider) : CardType.None;
        }

        public void GenerateRoom(IRandomProvider randomProvider, IConsoleService console)
        {
            if (RoomID < uint.MaxValue - 1)
                RoomID++;

            bSearched = false;

            Doors = new Dictionary<string, DoorWayType>
            {
                { "North", DoorWayType.None },
                { "East", DoorWayType.None },
                { "West", DoorWayType.None },
                { "South", DoorWayType.None }
            };

            int doorCount = randomProvider.Next(1, 4);
            List<string> directions = new() { "North", "East", "West", "South" };

            string randomDirection = directions[randomProvider.Next(directions.Count)];
            Doors[randomDirection] = DoorWayType.Open;
            directions.Remove(randomDirection);
            doorCount--;

            while (doorCount > 0 && directions.Count > 0)
            {
                randomDirection = directions[randomProvider.Next(directions.Count)];
                Doors[randomDirection] = (DoorWayType)randomProvider.Next(0, 3);
                directions.Remove(randomDirection);
                doorCount--;
            }

            Header = SetRoomHeader();
            Description = SetRoomDesc();

            string roomInfo = $"\n----------------------------------------------------\n";
            roomInfo += $"~~~~~~  {Header}  ~~~~~~\n";
            roomInfo += "----------------------------------------------------\n";
            roomInfo += $"{Description}";
            roomInfo += "----------------------------------------------------\n";
            console.Write(roomInfo);

            Card = RoomID > 0 ? GenerateCardType(randomProvider) : CardType.None;
        }


        string SetRoomHeader()
        {
            return RoomID < 2 ? "You have entered the Labyrinth." : "You explore a new room.";
        }

        string SetRoomDesc()
        {
            string roomDesc = "";

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

        public static DoorWayType GenerateDoorType(IRandomProvider randomProvider)
        {
            return (DoorWayType)randomProvider.Next(-1, 3);
        }

        public static CardType GenerateCardType(IRandomProvider randomProvider)
        {
            return (CardType)randomProvider.Next(0, 4);
        }


        [Obsolete("Please check else where?")]
        public static void CheckDoor(string doorName, Dictionary<string, DoorWayType> doors)
        {
            switch (doors[doorName])
            {
                case DoorWayType.Open:
                    GameConsole.Printf("\nYou try the door and with some luck it opens.\n\n");
                    new GameLoop(Gameplay.GameSession.CreateDefault(), new Gameplay.BaseGameplay(Gameplay.GameSession.CreateDefault())).ExploreNewRoom();
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
