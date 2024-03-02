using System;
using LabyrinthExplorer;
using Enums;
using GameplayNamespace;
using LabyrinthExplorer.Data;
using Utilities;

namespace Handlers
{
    public class Take : GameplayData
    {
        public static void DrawCard(CardType cardType)
        {
            if (actions.Contains("Take"))
            {
                // Remove the take action for the list of actions
                actions.Remove("Take");

                //Player.Cards.Add(cardType);
                int count = 0;
                Card newCard;
                int omenCount = BaseCardList.OmenCards.Count + 1;
                int itemCount = BaseCardList.ItemCards.Count + 1;
                Random rnd = new Random();

                switch (cardType)
                {
                    case CardType.Omen:
                        var rndOmen = rnd.Next(0, omenCount);
                        newCard = BaseCardList.OmenCards[rndOmen];
                        Player.Inventory.Add(newCard);
                        _Room.HasCard = false;
                        Utils.Print($"You pick up a card with the word {cardType} written on it.");
                        break;

                    case CardType.Item:
                        count = BaseCardList.ItemCards.Count;
                        var rndItem = new Random().Next(0, itemCount);
                        newCard = BaseCardList.ItemCards[rndItem];
                        Player.Inventory.Add(newCard);
                        _Room.HasCard = false;
                        Utils.Print($"You pick up an {cardType}.");
                        break;

                    default:
                        Utils.Print("There is nothing to take in this room.");
                        break;

                }

            }
            else
            {
                Utils.Print($"There is nothing to take.");
            }

        }

    }
}