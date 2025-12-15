using System;
using System.Collections.Generic;
using Enums;
using LabyrinthExplorer.Data;
using LabyrinthExplorer.Utilities;

namespace LabyrinthExplorer.Gameplay
{
    public class BaseGameplay
    {
        private readonly GameSession _session;
        private readonly IConsoleService _console;
        private GameLoop? _gameLoop;

        public BaseGameplay(GameSession session)
        {
            _session = session;
            _console = session.Console;
        }

        public void RegisterGameLoop(GameLoop gameLoop)
        {
            _gameLoop = gameLoop;
        }

        public void Setup()
        {
            int nameIndex = _session.RandomProvider.Next(0, Names.ListOfNames.Count - 1);
            _session.Player.Name = Names.ListOfNames[nameIndex];
        }

        public void Quit()
        {
            _console.Clear();
            Printf("\n\n\n\n");
            Printf("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Printf("~~~~~ Thank you for playing! ~~~~~\n");
            Printf("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            _console.Sleep(1500);
            Environment.Exit(0);
        }

        public void NewGame()
        {
            if (_gameLoop == null)
            {
                throw new InvalidOperationException("Game loop must be registered before starting a new game.");
            }

            Printf("\n----------------------------------------------------\n");
            Printf("~~~~~~  Welcome to the Labyrinth  ~~~~~~");
            Printf("\n----------------------------------------------------\n\n");
            Printf("No two rooms lead to the same place nor can you\n");
            Printf("backtrack to where you were.\n");
            Printf("The Labyrinth is alive and there is only one way out.\n");
            Printf("Good luck adventurer! We hope you can find the way out.\n");
            Printf("\n----------------------------------------------------\n");

            _console.Sleep(3250);

            var bag = new Card() { Name = "Bag", Description = "Somthing to hold things." };

            _session.Player.Inventory.Add(bag);

            _gameLoop.ExploreNewRoom();
        }

        public void BaseActions()
        {
            var actions = new List<string>
            {
                "quit",
                "look",
                "north",
                "east",
                "west",
                "south",
                "inventory"
            };

            if (_session.GameplayData.RoomRef.bSearched == false)
                actions.Add("Search");

            if (_session.GameplayData.RoomRef.HasCard)
                actions.Add("Take");

            _session.GameplayData.UserActions = actions;
        }

        public void CheckDoor(string doorName)
        {
            switch (_session.GameplayData.RoomRef.Doors[doorName])
            {
                case DoorWayType.Open:
                    Printf("\nYou try the door and with some luck it opens.\n\n");
                    _gameLoop?.ExploreNewRoom();
                    break;
                case DoorWayType.Blocked:
                    Printf("The door is blocked board and won't budge.\n");
                    break;
                case DoorWayType.Locked:
                    Printf("You try the door but to no avail.\n" +
                          "It is locked and won't open.\n");
                    break;
                case DoorWayType.None:
                    Printf("You examine the frame and see it looks\n" +
                          " more like it is built into the wall.\n");
                    break;
            }

        }

        public void PrintDoors()
        {

            foreach (var door in _session.GameplayData.RoomRef.Doors)
            {
                string doorAvail = "";
                switch (door.Value)
                {
                    case DoorWayType.None:
                        doorAvail += "-] There is a frame but no door.\n";
                        doorAvail += "-] Like a random frame was put on the wall.\n";
                        break;
                    case DoorWayType.Blocked:
                        doorAvail += "-] The door has a board nailed to the frame.\n";
                        doorAvail += "-] Covering the door and preventing it from moving.\n";
                        break;
                    case DoorWayType.Open:
                        doorAvail += "-] This door has a normal looking handle.\n";
                        doorAvail += "-] Maybe it will lead somewhere.\n";
                        break;
                    case DoorWayType.Locked:
                        doorAvail += "-] This door has a normal looking handle.\n";
                        doorAvail += "-] Maybe it will lead somewhere.\n";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Printf($"The door frame {door.Key}:\n{doorAvail}\n");

                _console.Sleep(1250);
            }
        }

        public string ReadInput()
        {
            string renderedActions = CommandRegistry.FormatActions(_session.GameplayData.UserActions);

            Printf($"\n[Actions ~|{renderedActions}|~ ]");

            Printf("\n#>| ");
            var userIn = _console.ReadLine() ?? string.Empty;
            var normalized = CommandRegistry.Normalize(userIn);
            _session.GameplayData.UserInput.Prop = normalized;

            _console.Sleep(500);

            return normalized;
        }

        public void Printf(string s) => _console.Write(s);
    }
}
