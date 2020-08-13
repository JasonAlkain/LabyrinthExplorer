using System.Collections.Generic;
using Enums;
using LabyrinthExplorer.Data;
using Utilities;

namespace LabyrinthExplorer
{
    public class Player
    {
        public static List<CardType> Cards;
        public static List<Card> Inventory;
        public static void ShowInvetory()
        {
            foreach (var item in Inventory)
            {
                Utils.Print($"[ {item.Name} ] ");
            }
        }
    }


    // I don't know why this is here yet.
    // But I might someday.
    internal class PlayerImpl : Player { }
}