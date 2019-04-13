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
    class InfectionHandler : IEventHandlerPlayerDie, IEventHandlerPlayerHurt
    {
        private SOTNGamemode plugin;

        public InfectionHandler(SOTNGamemode plugin)
        {
            this.plugin = plugin;
        }

        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            
            
        }

        public void OnPlayerHurt(PlayerHurtEvent ev)
        {
            if (ev.Damage > ev.Player.GetHealth() && ev.DamageType == DamageType.SCP_049_2 && ev.Attacker.TeamRole.Role == Role.SCP_049_2)
            {
                ev.Player.ChangeRole(Role.SCP_049_2, true, false, true);
                ev.Player.SetHealth(plugin.GetConfigInt("scp049-2_hp"));
                plugin.ConfigManager.
            }
        }
    }
}
