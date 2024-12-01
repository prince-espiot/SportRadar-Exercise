
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
            Assert.Multiple(() => {
                Assert.That(match.HomeTeam, Is.EqualTo("Mexico"));
                Assert.That(match.AwayTeam, Is.EqualTo("Canada"));
                Assert.That(match.HomeScore, Is.EqualTo(0));
                Assert.That(match.AwayScore, Is.EqualTo(0));
            });
        }

    }
}
