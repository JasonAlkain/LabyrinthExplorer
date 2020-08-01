using System;
using System.Collections.Generic;
using System.Threading;
using LabyrinthExplorer;
using GameplayNamespace;
using Enums;

namespace GameplayNamespace
{
    public class Gameplay : GameplayData
    {

        public void Setup()
        {
            gl = new GameLoop();
            Player.Cards = new List<CardType>();
        }

        protected static void Quit()
        {
            Print("\n\n~~ Thank you for playing! ~~\n\n");
            Environment.Exit(0);
        }

        protected static void NewGame()
        {
            Print("\n----------------------------------------------------\n");
            Print("~~~~~~  Welcome to the Labyrinth  ~~~~~~");
            Print("\n----------------------------------------------------\n\n");
            Print("No two rooms lead to the same place nor can you\n");
            Print("backtrack to where you were.\n");
            Print("The Labyrinth is alive and there is only one way out.\n");
            Print("Good luck adventurer! We hope you can find the way out.\n");
            Print("\n----------------------------------------------------\n");

            Thread.Sleep(3250);

            GameLoop.ExploreNewRoom();
        }

        public void SearchRoom(CardType card)
        {
            if (actions.Contains("Search"))
            {
                switch (room.Card)
                {
                    case CardType.None:
                        Print("There is nothing in this room.\n");
                        break;
                    case CardType.Event:
                        Print("Something happens.\n");
                        break;
                    case CardType.Omen:
                        Print($"A card with the word {room.Card} is written on it.\n");
                        break;
                    case CardType.Item:
                        Print($"You found an {room.Card}. Maybe it will come in handy.\n");
                        break;
                }

                if (card != CardType.None)
                    actions.Add("Take");

                actions.Remove("Search");
            }
            else
            {
                string s;
                switch (card)
                {
                    case CardType.None:
                        s = "This room had nothing in it.";
                        break;
                    case CardType.Event:
                        s = "Something already happened in this room.";
                        break;
                    case CardType.Omen:
                        s = "An Omen has appeared. Best be careful.";
                        break;
                    case CardType.Item:
                        s = "You found an item in this room.";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(card), card, null);
                }
                Print($"{s}\n");
            }

        }
        
        public static void CheckDoor(string doorName)
        {
            switch (room.Doors[doorName])
            {
                case DoorWay.Open:
                    Print("\nYou try the door and with some luck it opens.\n\n");
                    GameLoop.ExploreNewRoom();
                    break;
                case DoorWay.Blocked:
                    Print("The door is blocked board and won't budge.\n");
                    break;
                case DoorWay.Locked:
                    Print("You try the door but to no avail.\n" +
                          "It is locked and won't open.\n");
                    break;
                case DoorWay.None:
                    Print("You examine the frame and see the frame looks\n" +
                          " more like it is built into the wall.\n");
                    break;
            }

        }


    }
}