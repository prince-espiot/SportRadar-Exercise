
using SportradarLibrary;

namespace SportRadarLibraryTestSuite
{
    [TestFixture]
    public class Tests : PageTest
    {
        private WorldCupScoreboard _scoreboard;

        [SetUp]
        public void Setup()
        {
            _scoreboard = new WorldCupScoreboard();
        }

        [Test]
        public void StartMatch_CreatesMatchWithZeroScore()
        {
            // Arrange & Act
            var match = _scoreboard.StartMatch("Mexico", "Canada");

            // Assert
            Assert.That(match.HomeTeam, Is.EqualTo("Mexico"));
        }

    }
}
