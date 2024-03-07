using System;
using System.Collections.Generic;
using System.ComponentModel;
using Enums;
using LabyrinthExplorer.Data;
using Utilities;
using static System.Formats.Asn1.AsnWriter;

namespace LabyrinthExplorer
{
    public class Player : PlayerData
    {
        public static string Name { get; set; }
        internal static Notifier<int> _Sanity = new Notifier<int>();

        public static int Sanity
        {
            get { return _Sanity.Prop; }
            set { _Sanity.Prop = value; }
        }

        //public static List<CardType> Cards;
        public static List<Card> Inventory = new();

        public Player()
        {
            Name = string.Empty;
            Sanity = 10;
            
            Inventory = [];
            _Sanity.PropertyChanged += Score_PropertyChanged;
        }

        private void Score_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // This method will be called whenever the Score property changes.
            // You can update the UI or perform other actions here.
            new Print($"Sanity changed to: {Sanity}");
        }

        public static void ShowInvetory() => 
            Inventory.ForEach(item => new Print($"[ {item.Name} ] "));

        public override string ToString()
        {
            string result;
            result = $"{Name}";


            return base.ToString();
        }
    }

    public class PlayerData
    {
    }
}