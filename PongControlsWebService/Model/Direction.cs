using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongControlsWebService.Model
{
    public class Direction
    {
        public static string action = "stop";

        public Direction()
        {
            
        }

        public Direction(string Action)
        {
            action = Action;
        }


    }

}

