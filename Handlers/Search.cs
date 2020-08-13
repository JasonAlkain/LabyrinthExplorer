using System;
using Enums;
using GameplayNamespace;

namespace Handlers
{
    public class Search : Gameplay
    {
        /// <summary>
        /// This function handles what happens when you search a room.
        /// </summary>
        public static void Room()
        {
            // Check if the room has been searched.
            if (!_Room.bSearched)
            {
                // Set this room to searched.
                _Room.bSearched = true;

                // Display what the player found in the room.
                switch (_Room.Card)
                {
                    case CardType.None:
                        Print("There is nothing in this room.\n");
                        break;
                    case CardType.Event:
                        Print("Something happens.\n");
                        break;
                    case CardType.Omen:
                        Print($"A card with the word {_Room.Card} is written on it.\n");
                        _Room.HasCard = true;
                        break;
                    case CardType.Item:
                        Print($"You found an {_Room.Card}. Maybe it will come in handy.\n");
                        _Room.HasCard = true;
                        break;
                }

            }
            else
            {
                // If the player has already searched the room
                // let them now what they found if anything.
                string s;
                switch (_Room.Card)
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
                        throw new ArgumentOutOfRangeException(nameof(_Room.Card), _Room.Card, null);
                }
                Print($"{s}\n");
            }

        }
    }
}