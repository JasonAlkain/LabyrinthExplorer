using Enums;
using LabyrinthExplorer;
using LabyrinthExplorer.Gameplay;
using LabyrinthExplorer.Handlers;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;

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

            _session.GameplayData.RoomRef.GenerateRoom(_session.RandomProvider, _session.Console);
            _session.GameplayData.RoomCard = _session.GameplayData.RoomRef.Card;

            _baseGameplay.BaseActions();

            _session.Console.Sleep(1250);

            _selectionHandler?.Actions();
        }
    }
}
