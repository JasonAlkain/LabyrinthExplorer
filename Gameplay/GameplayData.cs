using System;
using System.Collections.Generic;
using Enums;
using LabyrinthExplorer.Data;
using Utilities;
using System.Threading;

namespace LabyrinthExplorer.Gameplay
{
    public class GameplayData
    {
        public static Room RoomRef { get; set; }
        [Obsolete("Currently being refactored")]
        public static int RoomCount { get; set; }
        [Obsolete("Currently being refactored")]
        public static CardType RoomCard { get; set; }
        public static List<string> UserActions { get; set; }
        public static List<Card> CardList { get; set; }


        public static Notifier<string> UserInput { get; set; }
        [Obsolete("Use UserInput instead")]
        public static string Input
        {
            get { return UserInput.Prop; }
            set { UserInput.Prop = value; }
        }



        public GameplayData()
        {
            RoomRef = new Room();
            UserInput = new Notifier<string>();
            UserActions = [];
            CardList = [];
        }


        //public static void Printf(string s) => new Print(s);
    }
}