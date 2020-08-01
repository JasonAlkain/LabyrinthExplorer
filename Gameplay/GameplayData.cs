using System.Collections.Generic;
using LabyrinthExplorer;
using Enums;
using GameplayNamespace;
using RoomNamespace;
using Utilities;

namespace GameplayNamespace
{
    public class GameplayData : Utils
    {
    public static Room room = new Room();
    protected static int roomCount = 0;
    public static List<string> actions = new List<string>();
    public static Player player;
    public static CardType _RoomCard;
    protected static GameLoop gl;
    public static string _Input = " ";
    }
}