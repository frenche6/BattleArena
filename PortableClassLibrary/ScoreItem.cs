using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena_PortableClassLibrary
{
    public class ScoreItem
    {
        public ScoreItem()
        {
            PlayerName = "Player";
            FinalScore = 0;
        }

        public ScoreItem(string aPlayerName, int aFinalScore)
        {
            PlayerName = aPlayerName;
            FinalScore = aFinalScore;
        }

        public string PlayerName { get; set; }
        public int FinalScore { get; set; }
    }
}
