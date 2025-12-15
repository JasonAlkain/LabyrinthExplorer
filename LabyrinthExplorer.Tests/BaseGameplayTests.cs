using Enums;
using GameplayNamespace;
using LabyrinthExplorer;
using LabyrinthExplorer.Gameplay;
using LabyrinthExplorer.Tests.TestUtilities;
using Xunit;

namespace LabyrinthExplorer.Tests
{
    public class BaseGameplayTests
    {
        [Fact]
        public void BaseActions_AddsTake_WhenRoomHasCard()
        {
            var session = new GameSession(new FakeConsoleService([]), new StaticRandomProvider());
            session.GameplayData.RoomRef = new Room
            {
                HasCard = true,
            };

            var gameplay = new BaseGameplay(session);

            gameplay.BaseActions();

            Assert.Contains("take", session.GameplayData.UserActions);
        }

        [Fact]
        public void BaseActions_OmitsTake_WhenRoomHasNoCard()
        {
            var session = new GameSession(new FakeConsoleService([]), new StaticRandomProvider());
            session.GameplayData.RoomRef = new Room
            {
                HasCard = false,
            };

            var gameplay = new BaseGameplay(session);

            gameplay.BaseActions();

            Assert.DoesNotContain("take", session.GameplayData.UserActions);
        }

        [Fact]
        public void ExploreNewRoom_SetsRoomCardAndActionsFromGeneration()
        {
            var random = new SequenceRandomProvider(new[] { 0, 0, 3 });
            var session = new GameSession(new FakeConsoleService([]), random);
            var gameplay = new BaseGameplay(session);
            var gameLoop = new GameLoop(session, gameplay);

            gameLoop.ExploreNewRoom();

            Assert.Equal(CardType.Item, session.GameplayData.RoomRef.Card);
            Assert.True(session.GameplayData.RoomRef.HasCard);
            Assert.Equal(session.GameplayData.RoomRef.Card, session.GameplayData.RoomCard);
            Assert.Contains("take", session.GameplayData.UserActions);
        }
    }
}
