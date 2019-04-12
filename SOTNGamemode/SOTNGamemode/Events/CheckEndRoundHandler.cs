﻿using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOTNGamemode.Events
{
    class CheckEndRoundHandler : IEventHandlerCheckRoundEnd
    {
        private SOTNGamemode plugin;

        public CheckEndRoundHandler(SOTNGamemode plugin)
        {
            this.plugin = plugin;
        }

        
        public void OnCheckRoundEnd(CheckRoundEndEvent ev)
        {
            bool scpAlive = false;
            bool humanAlive = true;
            foreach (Player player in ev.Server.GetPlayers())
            {
                if (player.TeamRole.Team == Smod2.API.Team.SCP)
                {
                    scpAlive = true; continue;
                }
                else if (player.TeamRole.Team == Team.CLASSD)
                {
                    humanAlive = true;
                }
            }

            if (ev.Server.GetPlayers().Count > 1)
            {
                if (scpAlive && humanAlive)
                {
                    ev.Status = ROUND_END_STATUS.ON_GOING;
                }
                else if (scpAlive && humanAlive == false)
                {
                    ev.Status = ROUND_END_STATUS.SCP_VICTORY;
                }
                else if (scpAlive == false && humanAlive)
                {
                    ev.Status = ROUND_END_STATUS.OTHER_VICTORY;
                }
            }

            ev.Status = ROUND_END_STATUS.ON_GOING;
        }
    }
}