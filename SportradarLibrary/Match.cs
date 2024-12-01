using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportradarLibrary
{
    public class Match
    {
        public string HomeTeam { get; }
        public string AwayTeam { get; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }

        public DateTime StartTime { get; }

        public Match(string homeTeam, string awayTeam)
        {
            HomeTeam = (homeTeam ?? throw new ArgumentNullException(nameof(homeTeam), "Home team cannot be null"));
            AwayTeam = (awayTeam ?? throw new ArgumentNullException(nameof(awayTeam), "Away team cannot be null"));
            HomeScore = 0;
            AwayScore = 0;
            StartTime = DateTime.UtcNow;
        }

        public void UpdateScore(int homeScore, int awayScore)
        {
            if (homeScore< 0 ||  awayScore< 0)
            {
                throw new ArgumentException("Score cannot be Negative");
            }

            HomeScore = homeScore;
            AwayScore = awayScore;
        }

        public int TotalScore => HomeScore + AwayScore;


        // Override Equals method
        public override bool Equals(object? obj)
        {
            if (obj is Match match)
            {
                return HomeTeam == match.HomeTeam && AwayTeam == match.AwayTeam;
            }
            return false;
        }

        // Override GetHashCode method
        public override int GetHashCode()
        {
            return HashCode.Combine(HomeTeam, AwayTeam);
        }
    }



}
