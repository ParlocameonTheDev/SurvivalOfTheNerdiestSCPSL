using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;

namespace SOTNGamemode.Events
{
    class InfectionHandler : IEventHandlerPlayerDie
    {
        private SOTNGamemode plugin;

        public InfectionHandler(SOTNGamemode plugin)
        {
            this.plugin = plugin;
        }

        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            if (ev.DamageTypeVar == DamageType.SCP_049_2 && ev.Killer.TeamRole.Role == Role.SCP_049_2)
            {
                ev.Player.ChangeRole(Role.SCP_049_2, false, true, true);
            }
            
        }
    }
}
