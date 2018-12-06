using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongWebservice.Model
{
    public class ScoreMaker
    {
        public string Id { get; set; }
        public string Brugernavn { get; set; }
        public string Gamemode { get; set; }
        public string Description { get; set; }
        public int Win { get; set; }
        public int Loss { get; set; }

        public ScoreMaker(string id, string brugernavn, string gamemode, string description, int win, int loss)
        {
            Id = id;
            Brugernavn = brugernavn;
            Gamemode = gamemode;
            Description = description;
            Win = win;
            Loss = loss;
        }

        public ScoreMaker()
        {
            
        }
    }
}
