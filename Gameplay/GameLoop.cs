using System;
using System.Threading;
using Enums;
using Handlers;
using RoomNamespace;

namespace GameplayNamespace
{
    public class GameLoop : Gameplay
    {

        public static void ExploreNewRoom()
        {
            // Pause for effect
            Thread.Sleep(1000);
            _Room = new Room();

            // Increment _Room count
            if(roomCount < UInt32.MaxValue-1)
                roomCount++;
            else
            {
                Print("You have found the way out!!");

                Menu._Main();
            }

            // Set up the Actions first available in the _Room
            BaseActions();

            // Create a new _Room for the player to explore
            _Room.CreateRoom();

            // Check if there is at least one open door
            if (!_Room.Doors.ContainsValue(DoorWay.Open))
                _Room.Doors["North"] = DoorWay.Open; // if not make it the forward door

            

            // Once created set the current _Room card to an instance for later
            _RoomCard = _Room.Card;

            Thread.Sleep(1250);
            //PrintDoors();

            // Start the actions phase from the Selection Handler
            SelectionHandler.Actions();
        }
    }
}