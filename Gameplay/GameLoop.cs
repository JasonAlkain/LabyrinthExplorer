using System.Threading;
using Enums;
using LabyrinthExplorer.Gameplay;
using LabyrinthExplorer.Handlers;
using LabyrinthExplorer;

namespace GameplayNamespace
{
    public class GameLoop
    {

        public static void ExploreNewRoom()
        {
            // Pause for effect
            Thread.Sleep(1000);
            GameplayData.RoomRef = new Room();

            // Increment _Room count
            //GameplayData.roomCount++;

            // Set up the Actions first available in the _Room
            BaseGameplay.BaseActions();

            // Create a new _Room for the player to explore
            GameplayData.RoomRef.GenerateRoom();

            // Once created set the current _Room card to an instance for later
            //GameplayData._RoomCard = GameplayData._Room.Card;

            Thread.Sleep(1250);
            //PrintDoors();

            // Start the actions phase from the Selection Handler
            SelectionHandler.Actions();
        }
    }
}