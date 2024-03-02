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
            if (!GameplayData._Room.bSearched)
            {
                // Set this room to searched.
                GameplayData._Room.bSearched = true;

                // Display what the player found in the room.
                switch (GameplayData._Room.Card)
                {
                    case CardType.None:
                        Printf("There is nothing in this room.\n");
                        break;
                    case CardType.Event:
                        Printf("Something happens.\n");
                        break;
                    case CardType.Omen:
                        Printf($"A card with the word {GameplayData._Room.Card} is written on it.\n");
                        GameplayData._Room.HasCard = true;
                        break;
                    case CardType.Item:
                        Printf($"You found an {GameplayData._Room.Card}. Maybe it will come in handy.\n");
                        GameplayData._Room.HasCard = true;
                        break;
                }

            }
            else
            {
                // If the player has already searched the room
                // let them now what they found if anything.
                string s;
                switch (GameplayData._Room.Card)
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
                        throw new ArgumentOutOfRangeException(nameof(GameplayData._Room.Card), GameplayData._Room.Card, null);
                }
                Printf($"{s}\n");
            }

        }
    }
}