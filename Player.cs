using System.Collections.Generic;
using Enums;
using Utilities;

namespace LabyrinthExplorer
{
    public class Player : Utils
    {
        public static List<CardType> Cards;
        public static void ShowInvetory()
        {

            foreach (CardType card in Cards)
            {
                Print($"[ {card} ] ");
            }
        }
    }
}