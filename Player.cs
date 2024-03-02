using System.Collections.Generic;
using Enums;
using LabyrinthExplorer.Data;
using Utilities;

namespace LabyrinthExplorer
{
    public class Player
    {
        string Name { get; set; }
        public static List<CardType> Cards;
        public static List<Card> Inventory;
        public static void ShowInvetory()
        {
            Inventory.ForEach(item => Utils.Print($"[ {item.Name} ] "));
        }
    }

    internal class PlayerImpl : Player { }
}