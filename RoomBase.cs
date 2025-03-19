using System.Collections.Generic;
using Enums;
using Utilities;

namespace LabyrinthExplorer
{
    public class RoomBase
    {
        public uint RoomID;
        public string Header;
        public string Description;
        public bool bSearched;
        public bool HasCard;
        public Dictionary<string, DoorWayType> Doors;
        public CardType Card;
        //public static void Printf(string s) => new Print(s);
    }
}
