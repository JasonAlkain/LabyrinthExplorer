using System;
using System.Collections.Generic;
using Enums;
using GameplayNamespace;

namespace RoomNamespace
{
    public class Room : RoomBase
    {
        /// <summary>
        /// Creates a new room from scratch.
        /// </summary>
        public void CreateRoom()
        {
            if(RoomID < uint.MaxValue-1)
                RoomID++;

            bSearched = false;

            Doors = new Dictionary<string, DoorWay>
            {
                { "North", GenerateDoorType() },
                { "East", GenerateDoorType() },
                { "West", GenerateDoorType() },
                { "South", GenerateDoorType() }
            };

            // Check if there is at least one open door
            if (!Doors.ContainsValue(DoorWay.Open))
                Doors["North"] = DoorWay.Open; // if not make it the forward door

            Header = SetRoomHeader();
            Description = SetRoomDesc();

            // Print the info to the console
            Printf("\n----------------------------------------------------\n");
            Printf($"~~~~~~  {Header}  ~~~~~~");
            Printf("\n----------------------------------------------------\n");
            Printf(Description);
            Printf("----------------------------------------------------\n");


            Card = RoomID > 0 ? GenerateCardType() : CardType.None;

            //Have an Event happen when the room has an event card type
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
        public DoorWay GenerateDoorType()
        {
            return (DoorWay)new Random().Next(-1, 3);
        }

        /// <summary>
        /// Returns a random CardType.
        /// </summary>
        /// <returns>Random CardType</returns>
        public CardType GenerateCardType()
        {
            return (CardType)new Random().Next(0, 4);
        }
    }
}
