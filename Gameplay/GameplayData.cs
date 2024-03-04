using System;
using System.Collections.Generic;
using Enums;
using LabyrinthExplorer.Data;
using RoomNamespace;
using Utilities;

namespace GameplayNamespace
{
    public class GameplayData
    {
        public static Room _Room;
        [Obsolete]
        public static int roomCount;
        [Obsolete]
        public static CardType _RoomCard;
        public static List<string> actions;
        public static List<Card> CardList;

        
        public static Notifier<string> _Input;

        public static string Input
        {
            get { return _Input.Prop; }
            set { _Input.Prop = value; }
        }



        public GameplayData()
        {
            _Room = new Room();
            Input = string.Empty;
            actions = new List<string>();
            CardList = new List<Card>();
        }


        public static void Printf(string s) => new Print(s);
    }
}