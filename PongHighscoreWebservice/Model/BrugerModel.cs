using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongWebservice.Model
{
    public class BrugerModel
    {
        public int ID { get; set; }
        public string Brugernavn { get; set; }

        public BrugerModel(int id, string brugernavn)
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
