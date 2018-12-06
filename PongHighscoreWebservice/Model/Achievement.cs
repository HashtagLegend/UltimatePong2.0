using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongWebservice.Model
{
    public class Achievement
    {
        public string BrugerID { get; set; }
        public string FirstWin { get; set; }
        public string FiveWins { get; set; }
        public string TenWins { get; set; }
        public string TwentyWins { get; set; }
        public string AIFirstWin { get; set; }
        public string AIFiveWins { get; set; }
        public string AITenWins { get; set; }
        public string AITwentyWins { get; set; }

        public Achievement(string brugerId, string firstWin, string fiveWins, string tenWins, string twentyWins, string aiFirstWin, string aiFiveWins, string aiTenWins, string aiTwentyWins)
        {
            BrugerID = brugerId;
            FirstWin = firstWin;
            FiveWins = fiveWins;
            TenWins = tenWins;
            TwentyWins = twentyWins;
            AIFirstWin = aiFirstWin;
            AIFiveWins = aiFiveWins;
            AITenWins = aiTenWins;
            AITwentyWins = aiTwentyWins;
        }

        public Achievement()
        {
        }

        public override string ToString()
        {
            return $"{nameof(BrugerID)}: {BrugerID}, {nameof(FirstWin)}: {FirstWin}, {nameof(FiveWins)}: {FiveWins}, {nameof(TenWins)}: {TenWins}, {nameof(TwentyWins)}: {TwentyWins}, {nameof(AIFirstWin)}: {AIFirstWin}, {nameof(AIFiveWins)}: {AIFiveWins}, {nameof(AITenWins)}: {AITenWins}, {nameof(AITwentyWins)}: {AITwentyWins}";
        }
    }
}
