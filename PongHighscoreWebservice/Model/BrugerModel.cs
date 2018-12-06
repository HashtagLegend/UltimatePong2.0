using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongWebservice.Model
{
    public class BrugerModel
    {
        public string ID { get; set; }
        public string Brugernavn { get; set; }

        public BrugerModel(string id, string brugernavn)
        {
            ID = id;
            Brugernavn = brugernavn;
        }
        //bare slet mig
        public BrugerModel()
        {

        }
    }
}
