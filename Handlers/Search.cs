using System;
using LabyrinthExplorer;
using Enums;
using GameplayNamespace;

namespace Handlers
{
    public class Search : Gameplay
    {
        public static void Room(CardType card)
        {
            if (actions.Contains("Search"))
            {
                switch (card)
                {
                    case CardType.None:
                        Print("There is nothing in this room.\n");
                        break;
                    case CardType.Event:
                        Print("Something happens.\n");
                        break;
                    case CardType.Omen:
                        Print($"A card with the word {card} is written on it.\n");
                        break;
                    case CardType.Item:
                        Print($"You found an {card}. Maybe it will come in handy.\n");
                        break;
                }

                if (card != CardType.None && card != CardType.Event)
                    actions.Add("Take");

                actions.Remove("Search");
            }
            else
            {
                string s;
                switch (card)
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
                        throw new ArgumentOutOfRangeException(nameof(card), card, null);
                }
                Print($"{s}\n");
            }

        }
    }
}