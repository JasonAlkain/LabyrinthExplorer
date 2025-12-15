using System.Collections.Generic;
using Enums;
using GameplayNamespace;
using LabyrinthExplorer;
using LabyrinthExplorer.Gameplay;
using LabyrinthExplorer.Handlers;
using LabyrinthExplorer.Tests.TestUtilities;
using LabyrinthExplorer.Utilities;
using Xunit;

namespace LabyrinthExplorer.Tests
{
    public class SelectionHandlerTests
    {
        [Fact]
        public void Actions_ExitsAfterConfirmedQuit()
        {
            var console = new FakeConsoleService(new[] { "quit", "yes" });
            var session = new GameSession(console, new StaticRandomProvider());
            session.GameplayData.RoomRef = new Room
            {
                Doors = new Dictionary<string, DoorWayType>
                {
                    { "North", DoorWayType.Blocked },
                    { "East", DoorWayType.Blocked },
                    { "West", DoorWayType.Blocked },
                    { "South", DoorWayType.Blocked },
                },
                bSearched = false,
                HasCard = false,
                Card = CardType.None,
            };
            session.GameplayData.RoomCard = CardType.None;

            var gameplay = new BaseGameplay(session);
            var gameLoop = new GameLoop(session, gameplay);
            var handler = new SelectionHandler(session, gameplay, gameLoop);

            var menuReturnCount = 0;
            handler.RegisterMenu(() => menuReturnCount++);

            handler.Actions();

            Assert.Equal(0, console.RemainingInputs);
            Assert.Equal(1, menuReturnCount);
        }

        [Fact]
        public void BaseActions_UsesCanonicalCommands()
        {
            var console = new FakeConsoleService(new[] { string.Empty });
            var session = new GameSession(console, new StaticRandomProvider());
            session.GameplayData.RoomRef = new Room
            {
                Doors = new Dictionary<string, DoorWayType>(),
                bSearched = false,
                HasCard = true,
                Card = CardType.Item,
            };
            session.GameplayData.RoomCard = CardType.Item;

            var gameplay = new BaseGameplay(session);

            gameplay.BaseActions();

            var actions = session.GameplayData.UserActions;
            Assert.Contains("quit", actions);
            Assert.Contains("search", actions);
            Assert.Contains("take", actions);
            Assert.DoesNotContain("(N)orth", actions);
        }
    }
}
