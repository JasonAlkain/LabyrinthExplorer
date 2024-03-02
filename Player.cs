using System.Collections.Generic;
using Enums;
using LabyrinthExplorer.Data;
using Utilities;

namespace LabyrinthExplorer
{
    public class Player
    {
        public static string Name { get; set; }
        private static Notifier<int> _Sanity;

        public static int Sanity { 
            get { return _Sanity.Prop; }
            set { _Sanity.Prop = value; }
        }




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