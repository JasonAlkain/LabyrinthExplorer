using System.Collections.Generic;
using Enums;
using LabyrinthExplorer.Data;
using RoomNamespace;
using Utilities;

namespace GameplayNamespace
{
    public class GameplayData : Utils
    {
        public static Room _Room;
        protected static int roomCount = 0;
        public static CardType _RoomCard;
        public static string _Input = "";
        public static List<string> actions = new List<string>();
        public static List<Card> CardList;

    }
}