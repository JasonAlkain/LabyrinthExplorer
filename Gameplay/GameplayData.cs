using System.Collections.Generic;
using Enums;
using LabyrinthExplorer.Data;
using RoomNamespace;
using Utilities;

namespace GameplayNamespace
{
    public class GameplayData : Utils
    {
        public static Room _Room { get; set; }
        public static uint roomCount { get; set; }
        public static CardType _RoomCard { get; set; }
        public static string _Input { get; set; }
        public static List<string> actions { get; set; }
        public static List<Card> CardList { get; set; }
    }
}