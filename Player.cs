using System.Collections.Generic;
using Enums;
using LabyrinthExplorer.Data;
using Utilities;

namespace LabyrinthExplorer
{
    public class Player
    {
        public static string Name { get; set; }
        public static int Sanity { get; set; }


        //public static List<CardType> Cards;
        public static List<Card> Inventory;
        
        
        public Player()
        {
            Name = "";
            Sanity = 10;
            Inventory = new List<Card>();
        }
        
        public static void ShowInvetory()
        {
            Inventory.ForEach(item => Utils.Print($"[ {item.Name} ] "));
        }

        public override string ToString()
        {
            string result;
            result = $"{Name}";


            return base.ToString();
        }
    }

    internal class PlayerImpl : Player { }
}