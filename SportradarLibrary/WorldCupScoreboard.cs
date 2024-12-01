
using System.Text.RegularExpressions;

namespace SportradarLibrary
{
    // Scoreboard to manage ongoing football matches.
    public class WorldCupScoreboard
    {
        private readonly List<Match> _matches = [];


        /// <summary>
        /// Start a new match and add it to the scoreboard.
        /// </summary>
        /// <param name="homeTeam">Home team name</param>
        /// <param name="awayTeam">Away team name</param>
        /// <returns>The started match</returns>
        /// <exception cref="ArgumentException">Thrown when a match between these teams already exists</exception>
        public Match StartMatch(string homeTeam, string awayTeam)
        {
            if (string.IsNullOrWhiteSpace(homeTeam) || string.IsNullOrWhiteSpace(awayTeam))
                throw new ArgumentException("Team names cannot be null or empty.");


            var newMatch = new Match(homeTeam, awayTeam);

            if (_matches.Contains(newMatch))
            {
                throw new ArgumentException($"Match between {homeTeam} and {awayTeam} already exists");
            }

            _matches.Add(newMatch);

            return newMatch;
           
        }

        /// <summary>
        /// Find a match by home and away team names.
        /// </summary>
        private Match FindMatch(string homeTeam, string awayTeam)
        {
            var match = _matches?.FirstOrDefault(m => (string)
                m.HomeTeam == homeTeam && (string)m.AwayTeam == awayTeam);

            return match ?? throw new ArgumentException(
                $"No match found between {homeTeam} and {awayTeam}");
        }


        /// <summary>
        /// Update the score of an existing match.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when match not found</exception>
        public void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore)
        {
            var matchToUpdate = FindMatch(homeTeam, awayTeam);
            matchToUpdate.UpdateScore(homeScore, awayScore);
        }


        /// <summary>
        /// Finish and remove a match from the scoreboard.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when match not found</exception>
        public void FinishMatch(string homeTeam, string awayTeam)
        {
            var matchToRemove = FindMatch(homeTeam, awayTeam);
            _matches.Remove(matchToRemove);
        }

        /// <summary>
        /// Get summary of matches ordered by total score and start time.
        /// </summary>
        public List<Match> GetSummary()
        {
            return _matches
                .OrderByDescending(m => m.TotalScore)
                .ThenByDescending(m => m.StartTime)
                .ToList();
        }

               
    }
}
