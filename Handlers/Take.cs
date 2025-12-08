using System;
using LabyrinthExplorer;
using Enums;
using LabyrinthExplorer.Data;
using LabyrinthExplorer.Gameplay;

namespace Handlers
{
    public class Take
    {
        private readonly GameSession _session;

        public Take(GameSession session)
        {
            _session = session;
        }

        public void DrawCard(CardType cardType)
        {
            if (_session.GameplayData.UserActions.Contains("Take"))
            {
                _session.GameplayData.UserActions.Remove("Take");

                switch (cardType)
                {
                    case CardType.Omen:
                        _session.Player.Inventory.Add(NewOmenCard());
                        break;

                    case CardType.Item:
                        _session.Player.Inventory.Add(NewItemCard());
                        break;

                    default:
                        _session.Console.Write("There is nothing to take in this room.");
                        break;

                }

            }
            else
            {
                _session.Console.Write($"There is nothing to take.");
            }

        }

        private Card NewOmenCard()
        {
            var rndOmenIndex = _session.Random.Next(0, BaseCardList.OmenCards.Count - 1);
            Card omenCard = BaseCardList.OmenCards[rndOmenIndex];
            _session.Player.Inventory.Add(omenCard);
            _session.GameplayData.RoomRef.HasCard = false;
            _session.Console.Write($"You pick up a card with the word Omen written on it. [{omenCard.Name}]");
            return omenCard;
        }

        private Card NewItemCard()
        {
            var rndItemIndex = _session.Random.Next(0, BaseCardList.ItemCards.Count - 1);
            Card itemCard = BaseCardList.ItemCards[rndItemIndex];
            _session.Player.Inventory.Add(itemCard);
            _session.GameplayData.RoomRef.HasCard = false;
            _session.Console.Write($"You pick up an Item. [{itemCard.Name}]");
            return itemCard;
        }
    }
}
