
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Components;
using Exiled.Events.EventArgs.Player;
using Mirror;
using PlayerRoles;
using SCPSLAudioApi.AudioCore;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AudioEngine.API
{
    public static class Dummy
    {
        public static void SpawnDummy(int id, string name = "SpeakerSystem")
        {
            if (Main.Instance.Connections.ContainsKey(id))
            {
                return;
            }
            GameObject newPlayer = UnityEngine.Object.Instantiate(NetworkManager.singleton.playerPrefab);
            FakeConnection fakeConnection = new FakeConnection(id);
            ReferenceHub hubPlayer = newPlayer.GetComponent<ReferenceHub>();

            hubPlayer.nicknameSync.Network_myNickSync = name; 

            Main.Instance.Connections.Add(id, new Connection()
            {
                BotID = id,
                BotName = name,
                fakeConnection = fakeConnection.identity,
                audioplayer = AudioPlayerBase.Get(hubPlayer),
                hubPlayer = hubPlayer,
                Volume = 50,
                Loop = true,
            });

            NetworkServer.AddPlayerForConnection(fakeConnection, newPlayer);
            
            MEC.Timing.CallDelayed(1, () =>
            {
                try
                {
                    hubPlayer.roleManager.ServerSetRole(RoleTypeId.Overwatch, RoleChangeReason.RemoteAdmin, RoleSpawnFlags.None);
                }
                catch (Exception e)
                {

                }
                
                hubPlayer.characterClassManager.GodMode = true;
                hubPlayer.serverRoles.SetText("BOT");
                hubPlayer.serverRoles.SetColor("green");
            });
        }
    }
}
