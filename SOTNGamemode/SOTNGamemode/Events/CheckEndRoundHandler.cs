using Smod2;
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
            if (Status.gamemodeEnabled)
            {
                bool scpAlive = false;
                bool humanAlive = false;
                foreach (Player player in ev.Server.GetPlayers())
                {
                    if (player.TeamRole.Team == Smod2.API.Team.SCP)
                    {
                        scpAlive = true;
                    }
                    if (player.TeamRole.Team == Team.CLASSD)
                    {
                        humanAlive = true;
                    }
                }

                if (scpAlive && humanAlive)
                {
                    ev.Status = ROUND_END_STATUS.ON_GOING;
                    return;
                }
                else if (scpAlive && humanAlive == false)
                {
                    ev.Status = ROUND_END_STATUS.SCP_VICTORY;
                    return;
                }
                else if (scpAlive == false && humanAlive)
                {
                    ev.Status = ROUND_END_STATUS.CI_VICTORY;
                    return;
                }



                ev.Status = ROUND_END_STATUS.ON_GOING;
                return;
            }
        }
    }
}
