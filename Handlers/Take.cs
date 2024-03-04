using System;
using LabyrinthExplorer;
using Enums;
using GameplayNamespace;
using LabyrinthExplorer.Data;
using Utilities;

namespace Handlers
{
    public class Take
    {
        public static void Printf(string s) => new Print(s);
        public static void DrawCard(CardType cardType)
        {
            if (GameplayData.actions.Contains("Take"))
            {
                // Remove the take action for the list of actions
                GameplayData.actions.Remove("Take");
                //
                switch (cardType)
                {
                    case CardType.Omen:
                        Player.Inventory.Add(NewOmenCard());
                        break;

                    case CardType.Item:
                        Player.Inventory.Add(NewItemCard());
                        break;

                    default:
                        Printf("There is nothing to take in this room.");
                        break;

                }

            }
            else
            {
                Printf($"There is nothing to take.");
            }

        }

        private static Card NewOmenCard()
        {
            var rndOmenIndex = new Random().Next(0, BaseCardList.OmenCards.Count - 1);
            Card omenCard = BaseCardList.OmenCards[rndOmenIndex];
            Player.Inventory.Add(omenCard);
            GameplayData._Room.HasCard = false;
            Printf($"You pick up a card with the word Omen written on it. [{omenCard.Name}]");
            return omenCard;
        }

        private static Card NewItemCard()
        {
            var rndItemIndex = new Random().Next(0, BaseCardList.ItemCards.Count - 1);
            Card itemCard = BaseCardList.ItemCards[rndItemIndex];
            Player.Inventory.Add(itemCard);
            GameplayData._Room.HasCard = false;
            Printf($"You pick up an Item. [{itemCard.Name}]");
            return itemCard;
        }
    }
}