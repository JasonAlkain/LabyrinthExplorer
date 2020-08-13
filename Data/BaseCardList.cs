using System.Collections.Generic;
using Enums;

namespace LabyrinthExplorer.Data
{
    public class BaseCardList
    {
        public static List<Card> OmenCards = new List<Card>()
            {
                new Card() {
                        _CardType = CardType.Omen,
                        Name = "A Poker Card",
                        Description = "A card from a deck of playing cards with Omen written over the top of it.",
                        ID = 0
                    },
                new Card() {
                        _CardType = CardType.Omen,
                        Name = "Tarot Card",
                        Description = "",
                        ID = 0
                    },
                new Card() {
                        _CardType = CardType.Omen,
                        Name = "A Note",
                        Description = "",
                        ID = 0
                    },
                new Card() {
                        _CardType = CardType.Omen,
                        Name = "A Letter",
                        Description = "",
                        ID = 0
                    },
                new Card() {
                        _CardType = CardType.Omen,
                        Name = "A Torn Page",
                        Description = "",
                        ID = 0
                    },

            };
        public static List<Card> ItemCards = new List<Card>()
            {
                new Card() {
                        _CardType = CardType.Item,
                        Name = "A Dull Knife",
                        Description = "It may not be sharpe but it still cuts.",
                        ID = 0
                    },
                new Card() {
                        _CardType = CardType.Item,
                        Name = "A Metal Coffee Mug",
                        Description = "",
                        ID = 0
                    },
                new Card() {
                        _CardType = CardType.Item,
                        Name = "A Board Game",
                        Description = "",
                        ID = 0
                    },
                new Card() {
                        _CardType = CardType.Item,
                        Name = "A Crystal Ball",
                        Description = "",
                        ID = 0
                    },
                new Card() {
                        _CardType = CardType.Item,
                        Name = "A Necklace",
                        Description = "",
                        ID = 0
                    },

            };


    }
}