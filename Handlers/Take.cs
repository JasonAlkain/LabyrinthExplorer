using LabyrinthExplorer;
using Enums;
using GameplayNamespace;

namespace Handlers
{
    public class Take : GameplayData
    {
        public static void RmCard(CardType card)
        {
            if (actions.Contains("Search"))
            {
                Print($"You have not searched this room yet.\n");
            }
            else if (actions.Contains("Take") && card != CardType.None && card != CardType.Event)
            {
                Player.Cards.Add(card);
                actions.Remove("Take");

                if(card == CardType.Item)
                    Print($"You pick up an {card}.");
                if(card == CardType.Omen)
                    Print($"You pick up a card with word {card} written on it.");
            }
            else
            {
                Print($"There is nothing to take.");
            }

        }

    }
}