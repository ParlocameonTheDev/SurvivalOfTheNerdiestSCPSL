﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.EventSystem.Events;

namespace SOTNGamemode.Events
{
    class RespawnHandler : IEventHandlerTeamRespawn
    {
        
        private SOTNGamemode plugin;

        public RespawnHandler(SOTNGamemode plugin)
        {
            this.plugin = plugin;
        }

        public void OnTeamRespawn(TeamRespawnEvent ev)
        {
            if (Status.gamemodeRoundActive)
            {
                ev.SpawnChaos = true;
                ev.PlayerList = new List<Player>();
            }
        }
    }
}
