
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
            Assert.Multiple(() =>
            {
                Assert.That(match.HomeTeam, Is.EqualTo("Mexico"));
                Assert.That(match.AwayTeam, Is.EqualTo("Canada"));
                Assert.That(match.HomeScore, Is.EqualTo(0));
                Assert.That(match.AwayScore, Is.EqualTo(0));
            });
        }

        [Test]
        public void StartMatch_ButPreventDuplicateMatches()
        {
            _scoreboard.StartMatch("Mexico", "Canada");
            Assert.Throws<ArgumentException>(() =>
                _scoreboard.StartMatch("Mexico", "Canada"));

        }

        [Test]
        public void UpdateScore_UpdatesMatchScore()
        {
            // Arrange
            _scoreboard.StartMatch("Mexico", "Canada");

            // Act
            _scoreboard.UpdateScore("Mexico", "Canada", 2, 1);

            // Assert
            var summary = _scoreboard.GetSummary();
            var updatedMatch = summary.First();

            Assert.Multiple(() => {
                Assert.That(updatedMatch.HomeScore, Is.EqualTo(2));
                Assert.That(updatedMatch.AwayScore, Is.EqualTo(1));
            });
        }


        [Test]
        public void UpdateScore_NegativeScores_ThrowsException()
        {
            // Arrange
            _scoreboard.StartMatch("Spain", "Brazil");

            // Assert
            Assert.That(() => _scoreboard.UpdateScore("Spain", "Brazil", -1, 2),
                Throws.ArgumentException);
            Assert.That(() => _scoreboard.UpdateScore("Spain", "Brazil", 1, -2),
                Throws.ArgumentException);
        }

        [Test]
        public void FinishMatch_ShouldThrowException_WhenMatchNotFound()
        {
            Assert.Throws<ArgumentException>(() =>
                _scoreboard.FinishMatch("Germany", "France"));
        }

        [Test]
        public void FinishedMatch_RemovalTest() 
        {
            // Arrange
            _scoreboard.StartMatch("Germany", "France");
            _scoreboard.StartMatch("Spain", "Brazil");

            _scoreboard.FinishMatch("Spain", "Brazil");


            // Assert
            var summary = _scoreboard.GetSummary();
            Assert.That(summary, Has.Count.EqualTo(1));
        }
    }
}
