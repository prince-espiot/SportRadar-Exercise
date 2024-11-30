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
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = 0;
            AwayScore = 0;
            StartTime = DateTime.UtcNow;
        }
    }



}
