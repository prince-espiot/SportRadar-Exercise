
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

            Assert.Multiple(() =>
            {
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

        [Test]
        public void GetSummary_SortsMatchesByScoreAndStartTime()
        {
            // Arrange: Simulate the example from the problem description
            _scoreboard.StartMatch("Mexico", "Canada");
            _scoreboard.UpdateScore("Mexico", "Canada", 0, 5);

            _scoreboard.StartMatch("Spain", "Brazil");
            _scoreboard.UpdateScore("Spain", "Brazil", 10, 2);

            _scoreboard.StartMatch("Germany", "France");
            _scoreboard.UpdateScore("Germany", "France", 2, 2);

            _scoreboard.StartMatch("Uruguay", "Italy");
            _scoreboard.UpdateScore("Uruguay", "Italy", 6, 6);

            _scoreboard.StartMatch("Argentina", "Australia");
            _scoreboard.UpdateScore("Argentina", "Australia", 3, 1);

            // Act
            var summary = _scoreboard.GetSummary().ToList();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(summary, Has.Count.EqualTo(5));

                // First match (highest total score)
                Assert.That(summary[0].HomeTeam, Is.EqualTo("Uruguay"));
                Assert.That(summary[0].AwayTeam, Is.EqualTo("Italy"));
                Assert.That(summary[0].HomeScore, Is.EqualTo(6));
                Assert.That(summary[0].AwayScore, Is.EqualTo(6));

                // Second match
                Assert.That(summary[1].HomeTeam, Is.EqualTo("Spain"));
                Assert.That(summary[1].AwayTeam, Is.EqualTo("Brazil"));

                // Third match
                Assert.That(summary[2].HomeTeam, Is.EqualTo("Mexico"));
                Assert.That(summary[2].AwayTeam, Is.EqualTo("Canada"));

                // Fourth match
                Assert.That(summary[3].HomeTeam, Is.EqualTo("Argentina"));
                Assert.That(summary[3].AwayTeam, Is.EqualTo("Australia"));

                // Last match
                Assert.That(summary[4].HomeTeam, Is.EqualTo("Germany"));
                Assert.That(summary[4].AwayTeam, Is.EqualTo("France"));
            });
        }
    }
}
