using System.Collections.Generic;
using Enums;
using Utilities;

namespace RoomNamespace
{
    public class RoomBase
    {
        public uint RoomID;
        public string Header;
        public string Description;
        public bool bSearched;
        public bool HasCard;
        public Dictionary<string, DoorWay> Doors;
        public CardType Card;
        public void Printf(string s) => new Print(s);
    }
}
