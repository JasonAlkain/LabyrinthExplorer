using System;
using LabyrinthExplorer;
using Enums;
using GameplayNamespace;
using LabyrinthExplorer.Data;

namespace Handlers
{
    public class Take : GameplayData
    {
        public static void RmCard(CardType card)
        {
            if (actions.Contains("Take"))
            {
                // Remove the take action for the list of actions
                actions.Remove("Take");

                //Player.Cards.Add(card);
                int count = 0;
                Card newCard;

                switch (card)
                {
                    case CardType.Omen:
                        count = BaseCardList.OmenCards.Count;
                        var rndOmen = new Random().Next(0, count - 1);
                        newCard = BaseCardList.OmenCards[rndOmen];
                        Player.Inventory.Add(newCard);
                        _Room.HasCard = false;
                        Print($"You pick up a card with the word {card} written on it.");
                        break;

                    case CardType.Item:
                        count = BaseCardList.ItemCards.Count;
                        var rndItem = new Random().Next(0, count - 1);
                        newCard = BaseCardList.ItemCards[rndItem];
                        Player.Inventory.Add(newCard);
                        _Room.HasCard = false;
                        Print($"You pick up an {card}.");
                        break;

                    default:
                        Print("There is nothing to take in this room.");
                        break;

                }

            }
            else
            {
                Print($"There is nothing to take.");
            }

        }

    }
}