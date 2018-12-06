using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongWebservice.Model
{
    public class Bruger
    {
        public string Id { get; set; }
        public string Brugernavn { get; set; }
        public string Description { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int AI_Wins { get; set; }
        public int AI_Loses { get; set; }

        public Bruger(string id, string brugernavn, string description, int wins, int loses, int aiWins, int aiLoses)
        {
            Id = id;
            Brugernavn = brugernavn;
            Description = description;
            Wins = wins;
            Loses = loses;
            AI_Wins = aiWins;
            AI_Loses = aiLoses;
        }

        public Bruger()
        {
            
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Brugernavn)}: {Brugernavn}, {nameof(Description)}: {Description}, {nameof(Wins)}: {Wins}, {nameof(Loses)}: {Loses}, {nameof(AI_Wins)}: {AI_Wins}, {nameof(AI_Loses)}: {AI_Loses}";
        }
    }
}
