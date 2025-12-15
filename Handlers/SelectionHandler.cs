using System;
using GameplayNamespace;
using LabyrinthExplorer;
using LabyrinthExplorer.Data;
using LabyrinthExplorer.Gameplay;
using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer.Handlers
{
    public class SelectionHandler
    {
        private readonly GameSession _session;
        private readonly BaseGameplay _baseGameplay;
        private readonly GameLoop _gameLoop;
        private readonly Search _search;
        private readonly Take _take;
        private Action? _returnToMenu;

        public SelectionHandler(GameSession session, BaseGameplay baseGameplay, GameLoop gameLoop)
        {
            _session = session;
            _baseGameplay = baseGameplay;
            _gameLoop = gameLoop;
            _search = new Search(session, baseGameplay);
            _take = new Take(session);
        }

        public void RegisterMenu(Action returnToMenu)
        {
            _returnToMenu = returnToMenu;
        }

        public void Actions()
        {
            bool running = true;

            while (running)
            {
                _baseGameplay.BaseActions();
                running = InterpretInput(_baseGameplay.ReadInput());
            }
        }

        internal bool InterpretInput(string input)
        {
            if (!CommandRegistry.TryMapGameplay(input, out var command) ||
                !_session.GameplayData.UserActions.Contains(command))
            {
                PrintUnrecognized();
                return true;
            }

            switch (command)
            {
                case "dev":
                    HandleDevOptions();
                    return true;
                case "north":
                case "east":
                case "west":
                case "south":
                    _baseGameplay.CheckDoor(char.ToUpper(command[0]) + command[1..]);
                    return true;
                case "use":
                    _baseGameplay.Printf("Not available yet.\n");
                    return true;
                case "look":
                    _baseGameplay.Printf("\n");
                    _baseGameplay.PrintDoors();
                    return true;
                case "search":
                    _search.Room();
                    return true;
                case "take":
                    _take.DrawCard(_session.GameplayData.RoomCard);
                    return true;
                case "inventory":
                    _session.Player.ShowInventory();
                    return true;
                case "quit":
                    return HandleLeaveGame();
                default:
                    PrintUnrecognized();
                    return true;
            }
        }

        private void HandleDevOptions()
        {
            _session.GameplayData.UserActions = ["item", "omen", "leave"];
            bool inDevMode = true;

            while (inDevMode)
            {
                int index;
                _baseGameplay.Printf("What would you like to do?");
                string input = _baseGameplay.ReadInput();

                if (!CommandRegistry.TryMapDev(input, out var command) ||
                    !_session.GameplayData.UserActions.Contains(command))
                {
                    PrintUnrecognized();
                    continue;
                }

                switch (command)
                {
                    case "item":
                        index = _session.RandomProvider.Next(0, BaseCardList.ItemCards.Count - 1);
                        _session.Player.Inventory.Add(BaseCardList.ItemCards[index]);
                        _baseGameplay.Printf("~{Added an item to your inventory}~.\n");
                        _baseGameplay.Printf($"~{BaseCardList.ItemCards[index].Name}~.\n");
                        break;
                    case "omen":
                        index = _session.RandomProvider.Next(0, BaseCardList.OmenCards.Count - 1);
                        _session.Player.Inventory.Add(BaseCardList.OmenCards[index]);
                        _baseGameplay.Printf("~{Added an Omen card to your inventory}~.\n");
                        _baseGameplay.Printf($"~{BaseCardList.OmenCards[index].Name}~.\n");
                        break;
                    case "leave":
                        inDevMode = false;
                        break;
                }
            }

        }

        private bool HandleLeaveGame()
        {
            _baseGameplay.Printf("Are you sure you want to leave the game?");
            _baseGameplay.Printf("You will have to start from square one if you do.");

            _session.GameplayData.UserActions = ["yes", "no"];

            while (true)
            {
                var input = _baseGameplay.ReadInput();

                if (!CommandRegistry.TryMapConfirmation(input, out var response) ||
                    !_session.GameplayData.UserActions.Contains(response))
                {
                    PrintUnrecognized();
                    continue;
                }

                if (response == "yes")
                {
                    _session.Console.Clear();
                    _returnToMenu?.Invoke();
                    return false;
                }

                return true;
            }
        }

        private void PrintUnrecognized()
        {
            _baseGameplay.Printf("\nThat command is not recognized.");
            _session.Console.ReadKey(true);
            _baseGameplay.Printf("\n\n");
        }
    }
}
