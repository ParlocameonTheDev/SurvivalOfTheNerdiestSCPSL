using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOTNGamemode
{
    class Status
    {
        public static bool gamemodeEnabled = false;
        public static bool lockdownActive = false;
        public static int generatorsFinished = 0;
        public static bool HaltLCZD = false;
        public static gameTypes activeGameType = gameTypes.NoType;
        public enum gameTypes
        {
            NoType = -1,
            Regular = 1,
            Doctor = 2
        }
    }
}
