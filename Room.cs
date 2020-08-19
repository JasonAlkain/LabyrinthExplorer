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
                RoomID = GameplayData.roomCount;

            bSearched = false;

            Doors = new Dictionary<string, DoorWay>();

            Doors.Add("North", GenerateDoorType());
            Doors.Add("East", GenerateDoorType());
            Doors.Add("West", GenerateDoorType());
            Doors.Add("South", GenerateDoorType());
            
            SetRoomHeader();
            SetRoomDesc();

            // Print the info to the console
            Print("\n----------------------------------------------------\n");
            Print($"~~~~~~  {Header}  ~~~~~~");
            Print("\n----------------------------------------------------\n");
            Print(Description);
            Print("----------------------------------------------------\n");


            Card = RoomID > 0 ? GenerateCardType() : CardType.None;
        }

        void SetRoomHeader()
        {
            // Check if this is the first _Room and set the opening accordingly 
            Header = RoomID < 2 ? "You have entered the Labyrinth." : "You explore a new room.";
        }

        void SetRoomDesc()
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
                roomDesc += $"There is a number on the ceiling that reads {RoomID}.\n";
                roomDesc += "\n";
            }
            else
            {
                roomDesc += "This room is unsettling similar to the last. \n";
                roomDesc += "It's a little different from the previous room.\n";
                roomDesc += "The door behind you closes hard.\n";
                roomDesc += "You hear a click come from the door.\n";
                roomDesc += $"There is a number on the ceiling that reads {RoomID}.\n\n";
            }

            Description = roomDesc;
        }

        /// <summary>
        /// Returns a random DoorType
        /// </summary>
        /// <returns>Random DoorType</returns>
        public DoorWay GenerateDoorType()
        {
            return (DoorWay)new Random().Next(-1, 2);
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
