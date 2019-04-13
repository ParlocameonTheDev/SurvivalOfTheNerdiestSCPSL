using MEC;
using Smod2.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using SMDoor = Smod2.API.Door;

namespace SOTNGamemode
{
    class Functions
    {
        public static SOTNGamemode plugin;

        public static void Lockdown(bool toggle)
        {
            if (Status.activeGameType == Status.gameTypes.Regular)
            {
                Status.lockdownActive = true;
                if (toggle)
                {
                    if (Status.activeGameType == Status.gameTypes.Regular)
                    {
                        List<String> doorsToLockDown = new List<string>(new string[] { "" });
                        //foreach (Door in plugin.Server.Map.GetDoors().Where(d => door.)
                        foreach (Elevator elevator in plugin.Server.Map.GetElevators().Where(elevator => elevator.ElevatorType == ElevatorType.LiftA || elevator.ElevatorType == ElevatorType.LiftB))
                        {
                            elevator.Locked = true;
                        }
                    }
                }
                if (!toggle)
                {
                    Status.lockdownActive = false;
                    if (Status.activeGameType == Status.gameTypes.Regular)
                    {
                        foreach (Elevator elevator in plugin.Server.Map.GetElevators().Where(elevator => elevator.ElevatorType == ElevatorType.LiftA || elevator.ElevatorType == ElevatorType.LiftB))
                        {
                            elevator.Locked = false;
                        }
                    }
                }
            }
        }

        public static IEnumerator<float> ResetLCZ()
        {
            while (Status.HaltLCZD)
            {
                PlayerManager.localPlayer.GetComponent<DecontaminationLCZ>().time = 0f;
                yield return Timing.WaitForSeconds(180);
            }
        }

        public static void changeDoorPermissions(string doorname)
        {
            foreach (SMDoor d in plugin.Server.Map.GetDoors().Where(d => doorname == d.Name))
            {

            }
        }

        public static void SpawnRagdoll(Player player)
        {
            GameObject ply = (GameObject)player.GetGameObject();
            int role = (int)player.TeamRole.Role;
            Class c = PlayerManager.localPlayer.GetComponent<CharacterClassManager>().klasy[role];
            GameObject ragdoll = UnityEngine.Object.Instantiate(c.model_ragdoll, ply.transform.position + c.ragdoll_offset.position, Quaternion.Euler(ply.transform.rotation.eulerAngles + c.ragdoll_offset.rotation));
            NetworkServer.Spawn(ragdoll);
            ragdoll.GetComponent<Ragdoll>().SetOwner(new Ragdoll.Info(player.PlayerId.ToString(), player.Name, new PlayerStats.HitInfo(), role, player.PlayerId));
            }

    public static List<Vector> FetchSpawnpoints(ZoneType zoneType, List<RoomType> excludedRoomTypes = null)
    {
        List<Vector> spawns = new List<Vector>();
        //Gets and iterates through all rooms in (ZoneType)
        //and checks for excluded rooms
        foreach (Room room in plugin.Server.Map.Get079InteractionRooms(Scp079InteractionType.CAMERA).Where(rm => rm.ZoneType == zoneType && !excludedRoomTypes.Contains(rm.RoomType)))
        {
            spawns.Add(room.Position + (Vector.Up * 2));
        }
        return spawns;
    }

}
}
