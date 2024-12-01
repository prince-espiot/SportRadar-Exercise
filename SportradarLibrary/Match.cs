using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportradarLibrary
{
    public class Match
    {
        public object HomeTeam { get; }
        public object AwayTeam { get; }
        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }

        public DateTime StartTime { get; }

        public Match(object homeTeam, object awayTeam)
        {
            HomeTeam = homeTeam ?? throw new ArgumentNullException(nameof(homeTeam), "Home team cannot be null");
            AwayTeam = awayTeam ?? throw new ArgumentNullException(nameof(awayTeam), "Away team cannot be null");
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
    }



}
