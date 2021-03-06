﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;
using SMItem = Smod2.API.Item;
using player = Smod2.API.Player;

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
            if (Status.gamemodeRoundActive)
            {
                if (ev.Attacker.TeamRole.Role == Role.SCP_049_2)
                {
                    ev.Damage = SOTNGamemode.pluginConfig.scp0492damage;
                }
                if (ev.Damage >= ev.Player.GetHealth() && ev.DamageType == DamageType.SCP_049_2 && ev.Attacker.TeamRole.Role == Role.SCP_049_2)
                {
                    foreach (SMItem i in ev.Player.GetInventory())
                    {
                        i.Drop();
                    }
                    Functions.SpawnRagdoll(ev.Player);
                    ev.Damage = 0;
                    ev.Player.ChangeRole(Role.SCP_049_2, true, false, false);
                    ev.Player.SetHealth(SOTNGamemode.pluginConfig.scp0492hp);
                }

            }        }
    }
}
