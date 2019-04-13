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
            String gameInstructions = "Each round consists of at least one 049-2, with a max of 4.\nIf one of the 049-2 kills you, you become one of them.\nIf you want to survive, either kill all of the zombies and supress the infection, or power on all of the generators to lift the lockdown and get an O5,\nwhich can open the entrance zone.";

            if(Status.gamemodeEnabled)
            {
                List<Player> players = ev.Server.GetPlayers();
                if (Status.activeGameType == Status.gameTypes.Regular)
                {
                    foreach(Player p in players)
                    {
                        p.SendConsoleMessage(gameInstructions);
                    }
                    int numberOfStartingInfected = 0;
                    if (players.Count < 5)
                    {
                        numberOfStartingInfected = 1;
                    }
                    else if (10 > players.Count && players.Count > 5)
                    {
                        numberOfStartingInfected = 2;
                    }
                    else if(players.Count > 10)
                    {
                        numberOfStartingInfected = 3;
                    }
                    else if (players.Count > 13)
                    {
                        numberOfStartingInfected = 4;
                    }
                    Random getInfectedIndex = new Random();
                    List<Player> playersToInfect = new List<Player>();
                    int newfriendIndex = 0;
                    for (int i = 0; i < numberOfStartingInfected; i++)
                    {
                        newfriendIndex = getInfectedIndex.Next(0, players.Count);
                        playersToInfect.Add(players[newfriendIndex]);
                        players.Remove(players[newfriendIndex]);
                     
                    }
                    List<RoomType> genericExcluded = new List<RoomType>(new RoomType[] {RoomType.HCZ_ARMORY,RoomType.SCP_106,RoomType.SCP_939,RoomType.TESLA_GATE,RoomType.MICROHID,RoomType.CHECKPOINT_B,RoomType.CHECKPOINT_A});
                    List<Vector> humanSpawnPoints = Functions.FetchSpawnpoints(ZoneType.HCZ,genericExcluded);
                    int spawnPIndex = 0;
                    foreach (Player player in playersToInfect)
                    {

                        player.ChangeRole(Role.SCP_049_2, true, false, true);
                        
                        player.Teleport(plugin.Server.Map.GetSpawnPoints(Role.SCP_049)[0]);
                        

                    }
                    foreach (Player player in players)
                    {
                        player.ChangeRole(Role.CLASSD, true, false, true);
                        if (humanSpawnPoints.Count == spawnPIndex) spawnPIndex = 0;
                        player.Teleport(humanSpawnPoints[spawnPIndex]);

                    }
                    List<RoomType> generatorExcluded = new List<RoomType>(new RoomType[] { RoomType.HCZ_ARMORY, RoomType.SCP_939, RoomType.TESLA_GATE, RoomType.MICROHID, RoomType.CHECKPOINT_B, RoomType.CHECKPOINT_A, RoomType.SCP_372,RoomType.SERVER_ROOM});
                    List<Vector> tabletSpawnPoints = Functions.FetchSpawnpoints(ZoneType.HCZ, generatorExcluded);
                    Random tabletSpawnRNG = new Random();
                    for(int i=0;i<5;i++)
                    {
                        int tabletSpawnIndex = tabletSpawnRNG.Next(0, tabletSpawnPoints.Count);
                        map.SpawnItem(ItemType.WEAPON_MANAGER_TABLET, tabletSpawnPoints[tabletSpawnIndex], Vector.Zero);
                        tabletSpawnPoints.Remove(tabletSpawnPoints[tabletSpawnIndex]);
                    }
                    Functions.Lockdown(true);
                    map.Broadcast(10, "Welcome to <b>Survival of The Nerdiest!</b>\nIf you've never played this gamemode before, please press `/~", false);
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
