using System;
using Enums;
using LabyrinthExplorer.Gameplay;

namespace Handlers
{
    public class Search
    {
        private readonly GameSession _session;
        private readonly BaseGameplay _baseGameplay;

        public Search(GameSession session, BaseGameplay baseGameplay)
        {
            _session = session;
            _baseGameplay = baseGameplay;
        }

        public void Room()
        {
            if (!_session.GameplayData.RoomRef.bSearched)
            {
                _session.GameplayData.RoomRef.bSearched = true;

                switch (_session.GameplayData.RoomRef.Card)
                {
                    case CardType.None:
                        _baseGameplay.Printf("There is nothing in this room.\n");
                        break;
                    case CardType.Event:
                        _baseGameplay.Printf("Something happens.\n");
                        break;
                    case CardType.Omen:
                        _baseGameplay.Printf($"A card with the word {_session.GameplayData.RoomRef.Card} is written on it.\n");
                        _session.GameplayData.RoomRef.HasCard = true;
                        break;
                    case CardType.Item:
                        _baseGameplay.Printf($"You found an {_session.GameplayData.RoomRef.Card}. Maybe it will come in handy.\n");
                        _session.GameplayData.RoomRef.HasCard = true;
                        break;
                }

            }
            else
            {
                string s;
                switch (_session.GameplayData.RoomRef.Card)
                {
                    case CardType.None:
                        s = "This room had nothing in it.";
                        break;
                    case CardType.Event:
                        s = "Something already happened in this room.";
                        break;
                    case CardType.Omen:
                        s = "An Omen has appeared. Best be careful.";
                        break;
                    case CardType.Item:
                        s = "You found an item in this room.";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(_session.GameplayData.RoomRef.Card), _session.GameplayData.RoomRef.Card, null);
                }
                _baseGameplay.Printf($"{s}\n");
            }

        }
    }
}
