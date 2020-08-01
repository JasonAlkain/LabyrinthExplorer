using System.Collections.Generic;
using Enums;

namespace RoomNamespace
{
    public class Room : RoomBase
    {
        public void CreateRoom()
        {
            Card = CreateCard();
            Doors = new Dictionary<string, DoorWay>();

            Doors.Add("North", CreateDoor());
            Doors.Add("East", CreateDoor());
            Doors.Add("West", CreateDoor());
            Doors.Add("South", CreateDoor());
        }
    }
}
