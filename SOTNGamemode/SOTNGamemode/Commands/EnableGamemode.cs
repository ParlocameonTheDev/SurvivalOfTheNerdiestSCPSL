using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smod2;
using Smod2.Commands;

namespace SOTNGamemode.Commands
{

    class EnableGamemode : ICommandHandler
    {
        private readonly SOTNGamemode plugin;

        public EnableGamemode(SOTNGamemode plugin)
        {
            this.plugin = plugin;
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            if (Status.gamemodeEnabled)
            {
                Status.gamemodeEnabled = false;
                return new string[] { "Gamemode disabled" };

            }
            else
            {
                
                if (args.Length == 1)
                {
                    Status.gamemodeEnabled = true;
                    Status.activeGameType = (Status.gameTypes)int.Parse(args[0]);
                    return new string[] { "Gamemode enabled, and will start next round" };
                }
                else
                {
                    return new string[] { "Missing gametype or has too many args" };
                }
                
            }
            
        }

        public string GetUsage()
        {
            return "USAGE: sotnenable [gamemode type], gamemode type 1(no doctor), gamemode type 2(doctor)";
        }
        public string GetCommandDescription()
        {
            return "Enables Survival of the Nerdiest for the next round.";
        }
    }
}
