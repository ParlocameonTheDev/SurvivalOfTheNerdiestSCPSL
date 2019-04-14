using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMTeam = Smod2.API.Team;

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
            if (Status.gamemodeRoundActive)
            {
                bool scpAlive = false;
                bool humanAlive = false;
                foreach (Player player in ev.Server.GetPlayers())
                {
                    if (player.TeamRole.Team == SMTeam.SCP)
                    {
                        scpAlive = true;
                    }
                    if (player.TeamRole.Team == SMTeam.CLASSD)
                    {
                        humanAlive = true;
                    }
                }

                if (scpAlive && humanAlive)
                {
                    ev.Status = ROUND_END_STATUS.ON_GOING;
                    return;
                }
                else if (scpAlive && humanAlive == false && ev.Round.Stats.ClassDEscaped<1)
                {
                    ev.Status = ROUND_END_STATUS.SCP_VICTORY; ev.Round.EndRound();
                    return;
                }
                else if (scpAlive == false && humanAlive)
                {
                    int dclassalive = ev.Server.GetPlayers().Where(p => p.TeamRole.Role==Role.CLASSD).Count();
                    ev.Round.Stats.ClassDEscaped += dclassalive;
                    ev.Status = ROUND_END_STATUS.OTHER_VICTORY; ev.Round.EndRound();
                    return;
                }



                ev.Status = ROUND_END_STATUS.ON_GOING;
                return;
            }
        }
    }
}
