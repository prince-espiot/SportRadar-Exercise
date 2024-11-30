
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

          
            return newMatch;
           
        }

        public bool MatchCount()
        {
            throw new NotImplementedException();
        }

        
    }
}
