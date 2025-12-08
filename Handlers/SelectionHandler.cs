using System;
using Enums;
using LabyrinthExplorer;
using GameplayNamespace;
using LabyrinthExplorer.Data;
using LabyrinthExplorer.Gameplay;

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
            while (true)
            {
                _baseGameplay.BaseActions();
                InterpretInput(_baseGameplay.ReadInput());
            }
        }

        protected void InterpretInput(string input)
        {
            if (_session.GameplayData.UserActions.Contains(input))
            {
                if (input == "Dev")
                {
                    DevOptions();
                    return;
                }

                switch (input)
                {
                    case "N":
                    case "North":
                        input = "North";
                        _baseGameplay.CheckDoor(input);
                        break;
                    case "E":
                    case "East":
                        input = "East";
                        _baseGameplay.CheckDoor(input);
                        break;
                    case "W":
                    case "West":
                        input = "West";
                        _baseGameplay.CheckDoor(input);
                        break;
                    case "S":
                    case "South":
                        input = "South";
                        _baseGameplay.CheckDoor(input);
                        break;
                    case "Use":
                        _baseGameplay.Printf("Not available yet.\n");
                        break;
                    case "Look":
                        _baseGameplay.Printf("\n");
                        _baseGameplay.PrintDoors();
                        break;
                    case "Search":
                        _search.Room();
                        break;
                    case "Take":
                        _take.DrawCard(_session.GameplayData.RoomCard);
                        break;
                    case "I":
                    case "Inventory":
                        _session.Player.ShowInventory();
                        break;
                    case "Q":
                    case "L":
                    case "Quit":
                    case "Leave":
                        LeaveGame();
                        break;
                    default:
                        _baseGameplay.Printf("\nThat command is not recognized.");
                        _session.Console.ReadKey(true);
                        _baseGameplay.Printf("\n\n");
                        break;
                }
            }
            else
            {
                _baseGameplay.Printf("\nThat command is not recognized.");
                _session.Console.ReadKey(true);
                _baseGameplay.Printf("\n\n");
            }


        }

        protected void DevOptions()
        {
            _session.GameplayData.UserActions = ["Item", "Omen", "Leave"];
            while (true)
            {
                int index;
                _baseGameplay.Printf("What would you like to do?");
                string input = _baseGameplay.ReadInput();

                switch (input)
                {
                    case "Item":
                        index = _session.Random.Next(0, BaseCardList.ItemCards.Count - 1);
                        _session.Player.Inventory.Add(BaseCardList.ItemCards[index]);
                        _baseGameplay.Printf("~{Added an item to your inventory}~.\n");
                        _baseGameplay.Printf($"~{BaseCardList.ItemCards[index].Name}~.\n");
                        break;
                    case "Omen":
                        index = _session.Random.Next(0, BaseCardList.OmenCards.Count - 1);
                        _session.Player.Inventory.Add(BaseCardList.OmenCards[index]);
                        _baseGameplay.Printf("~{Added an Omen card to your inventory}~.\n");
                        _baseGameplay.Printf($"~{BaseCardList.OmenCards[index].Name}~.\n");
                        break;
                    case "Leave":
                        Actions();
                        break;
                    default:
                        _baseGameplay.Printf("\nThat command is not recognized.");
                        _session.Console.ReadKey(true);
                        _baseGameplay.Printf("\n\n");
                        break;
                }
            }

        }

        public void LeaveGame()
        {
            _baseGameplay.Printf("Are you sure you want to leave the game?");
            _baseGameplay.Printf("You will have to start from square one if you do.");

            _session.GameplayData.UserActions = ["Yes", "No"];

            switch (_baseGameplay.ReadInput())
            {
                case "Yes":
                    _session.Console.Clear();
                    _returnToMenu?.Invoke();
                    break;
                case "No":
                    Actions();
                    break;
                default:
                    _baseGameplay.Printf("\nThat command is not recognized.");
                    _session.Console.ReadKey(true);
                    _baseGameplay.Printf("\n\n");
                    break;
            }


        }
    }
}
