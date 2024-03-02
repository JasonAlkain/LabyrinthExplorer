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
            GameplayData._Room = new Room();

            // Increment _Room count
            GameplayData.roomCount++;

            // Set up the Actions first available in the _Room
            BaseActions();

            // Create a new _Room for the player to explore
            GameplayData._Room.CreateRoom();

            // Once created set the current _Room card to an instance for later
            GameplayData._RoomCard = GameplayData._Room.Card;

            Thread.Sleep(1250);
            //PrintDoors();

            // Start the actions phase from the Selection Handler
            SelectionHandler.Actions();
        }
    }
}