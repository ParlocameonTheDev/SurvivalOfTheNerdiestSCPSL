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
    class RoundEventHandler : IEventHandlerRoundStart, IEventHandlerRoundEnd, IEventHandlerRoundRestart
    {
        private SOTNGamemode plugin;

        public RoundEventHandler(SOTNGamemode plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundStart(RoundStartEvent ev)
        {
            Map map = plugin.Server.Map;
            if(Status.gamemodeEnabled)
            {
                List<Player> players = ev.Server.GetPlayers();
                int numberOfStartingInfected = 0;
                if (players.Count < 5)
                {
                    numberOfStartingInfected = 1;
                }
                else if (15 > players.Count && players.Count > 7)
                {
                    numberOfStartingInfected = 2;
                }
                else
                {
                    numberOfStartingInfected = 5;
                }
                Random getInfectedIndex = new Random();
                List<Player> playersToInfect = new List<Player>();
                for(int i = 0; i < numberOfStartingInfected; i++)
                {
                    int newfriendIndex = getInfectedIndex.Next(0, players.Count);
                    playersToInfect.Add(players[newfriendIndex]);
                    players.Remove(players[newfriendIndex]);
                }
                List<Vector> spawnpoints = map.GetSpawnPoints(Role.SCIENTIST);
                int spawnPIndex = 0;
                foreach (Player player in playersToInfect)
                {
                    
                    player.ChangeRole(Role.SCP_049_2, false, true, true);
                    if (spawnpoints.Count == spawnPIndex) spawnPIndex = 0;
                    player.Teleport(map.GetSpawnPoints(Role.SCIENTIST)[spawnPIndex]);
                    spawnPIndex++;
                    
                }
                foreach(Player player in players)
                {
                    player.ChangeRole(Role.CLASSD, true, true, true);
                }
                List<Door> doors = plugin.Server.Map.GetDoors();
                foreach(Door d in doors)
                {
                    plugin.Info(d.Name);
                }
            }
        }

        public void OnRoundEnd(RoundEndEvent ev)
        {

        }

        public void OnRoundRestart(RoundRestartEvent ev)
        {

        }
    }
}
