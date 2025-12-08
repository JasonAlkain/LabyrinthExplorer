using Enums;
using LabyrinthExplorer.Gameplay;
using LabyrinthExplorer.Handlers;

namespace GameplayNamespace
{
    public class GameLoop
    {
        private readonly GameSession _session;
        private readonly BaseGameplay _baseGameplay;
        private SelectionHandler? _selectionHandler;

        public GameLoop(GameSession session, BaseGameplay baseGameplay)
        {
            _session = session;
            _baseGameplay = baseGameplay;
        }

        public void RegisterSelectionHandler(SelectionHandler selectionHandler)
        {
            _selectionHandler = selectionHandler;
        }

        public void ExploreNewRoom()
        {
            _session.Console.Sleep(1000);
            _session.GameplayData.RoomRef = new Room();

            _baseGameplay.BaseActions();

            _session.GameplayData.RoomRef.GenerateRoom(_session.Random, _session.Console);

            _session.Console.Sleep(1250);

            _selectionHandler?.Actions();
        }
    }
}
