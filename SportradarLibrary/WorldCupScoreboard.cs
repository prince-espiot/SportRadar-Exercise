
using System.Text.RegularExpressions;

namespace SportradarLibrary
{
    public class WorldCupScoreboard
    {
        private readonly List<Match> _matches = new List<Match>();

        public void NotImplementedFunction()
        {
            throw new NotImplementedException();
        }

        public Match StartMatch(string homeTeam, string awayTeam)
        {
            var newMatch = new Match(homeTeam, awayTeam);

            if (_matches.Contains(newMatch))
            {
                throw new ArgumentException($"Match between {homeTeam} and {awayTeam} already exists");
            }

            _matches.Add(newMatch);

            return newMatch;
           
        }

        public bool MatchCount()
        {
            throw new NotImplementedException();
        }

        
    }
}
