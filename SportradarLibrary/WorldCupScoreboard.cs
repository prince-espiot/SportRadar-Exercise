
using System.Text.RegularExpressions;

namespace SportradarLibrary
{
    public class WorldCupScoreboard
    {
        private readonly List<Match> _matches = [];
       public int MatchCount => _matches.Count;

        private Match FindMatch(string homeTeam, string awayTeam)
        {
            var match = _matches?.FirstOrDefault(m => (string)
                m.HomeTeam == homeTeam && (string) m.AwayTeam == awayTeam);

            return match ?? throw new ArgumentException(
                $"No match found between {homeTeam} and {awayTeam}");
        }

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

        public void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore)
        {
            var matchToUpdate = FindMatch(homeTeam, awayTeam);
            matchToUpdate.UpdateScore(homeScore, awayScore);
        }

        public void FinishMatch(string homeTeam, string awayTeam)
        {
            var matchToRemove = FindMatch(homeTeam, awayTeam);
            _matches.Remove(matchToRemove);
        }
        

        public List<Match> GetSummary()
        {
            return _matches
                .OrderByDescending(m => m.TotalScore)
                .ThenByDescending(m => m.StartTime)
                .ToList();
        }

        /*public int MatchCount()
        {
            return _matches.Count;
        }*/

        
    }
}
