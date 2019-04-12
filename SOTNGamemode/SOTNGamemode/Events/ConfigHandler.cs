using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.EventSystem.Events;

namespace SOTNGamemode.Events
{
    class ConfigHandler : IEventHandlerSetConfig, IEventHandlerSetSCPConfig
    {

        private SOTNGamemode plugin;

        public ConfigHandler(SOTNGamemode plugin)
        {
            this.plugin = plugin;
        }

        public void OnSetConfig(SetConfigEvent ev)
        {

        }

        public void OnSetSCPConfig(SetSCPConfigEvent ev)
        {
            if(Status.gamemodeEnabled)
            {
                
            }
            if (Status.gamemodeEnabled && Status.activeGameType==Status.gameTypes.Regular)
            {
                ev.Ban079 = true;
                ev.Ban096 = true;
                ev.Ban106 = true;
                ev.Ban173 = true;
                ev.Ban939_53 = true;
                ev.Ban939_89 = true;
            
            }
            else if (Status.gamemodeEnabled && Status.activeGameType==Status.gameTypes.Doctor)
            {
                ev.Ban079 = true;
                ev.Ban096 = true;
                ev.Ban106 = true;
                ev.Ban173 = true;
                ev.Ban939_53 = true;
                ev.Ban939_89 = true;
            }
        }
    }
}
