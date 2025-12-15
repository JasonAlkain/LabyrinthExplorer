using System;
using System.Collections.Generic;
using Enums;
using LabyrinthExplorer.Data;
using Utilities;

namespace LabyrinthExplorer.Gameplay
{
    public class GameplayData
    {
        public Room RoomRef { get; set; }
        [Obsolete("Currently being refactored")]
        public int RoomCount { get; set; }
        public CardType RoomCard { get; set; }
        public List<string> UserActions { get; set; }
        public List<Card> CardList { get; set; }


        public Notifier<string> UserInput { get; set; }
        [Obsolete("Use UserInput instead")]
        public string Input
        {
            get { return UserInput.Prop; }
            set { UserInput.Prop = value; }
        }

        public GameplayData()
        {
            RoomRef = new Room();
            UserInput = new Notifier<string>();
            UserActions = new List<string>();
            CardList = new List<Card>();
        }
    }
}
