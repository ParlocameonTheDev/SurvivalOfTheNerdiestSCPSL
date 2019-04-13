using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.EventSystem.Events;
using SMTeam = Smod2.API.Team;

namespace SOTNGamemode.Events
{
    class DoorEventHandler : IEventHandlerDoorAccess
    {
        private SOTNGamemode plugin;

        public DoorEventHandler(SOTNGamemode plugin)
        {
            this.plugin = plugin;
        }

        public void OnDoorAccess(PlayerDoorAccessEvent ev)
        {
            Player player = ev.Player;
            if (Status.gamemodeEnabled)
            {
                if (ev.Door.Name == "CHECKPOINT_ENT")
                {
                    if (player.GetCurrentItem().ItemType == ItemType.O5_LEVEL_KEYCARD) { ev.Allow = true; return; }
                    else if (player.TeamRole.Team == SMTeam.SCP && Status.lockdownActive) { ev.Allow = false; return; }
                    else if (player.TeamRole.Team == SMTeam.SCP && Status.lockdownActive == false) { ev.Allow = true; return; }
                    else if (player.GetBypassMode()) { ev.Allow = true; return; }
                    else ev.Allow = false;
                }
            }
            
        }
    }

}
