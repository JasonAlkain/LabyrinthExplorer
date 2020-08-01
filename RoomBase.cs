using System;
using System.Collections.Generic;
using Enums;

namespace RoomNamespace
{
    public class RoomBase
    {
        public Dictionary<string, DoorWay> Doors;

        public CardType Card;


        public DoorWay CreateDoor()
        {
            return (DoorWay)new Random().Next(-1, 2);
        }
        public CardType CreateCard()
        {
            return (CardType)new Random().Next(0, 3);
        }
    }
}
