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
        public static int roomCount;
        public static CardType _RoomCard;
        public static string _Input;
        public static List<string> actions;
        public static List<Card> CardList;

        public GameplayData()
        {
            _Room = new Room();
            roomCount = 0;
            _RoomCard = CardType.None;
            _Input = string.Empty;
            actions = new List<string>();
            CardList = new List<Card>();
        }
    }
}