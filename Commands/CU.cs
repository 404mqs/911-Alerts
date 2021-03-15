using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMS
{

    public class ClearAlerts : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "cu";
        public string Help => "";
        public string Syntax => throw new NotImplementedException();
        public List<string> Aliases => new List<string>() { "clearalerts" };
        public List<string> Permissions => new List<string> { "cu.usage" };
        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer playerid = UnturnedPlayer.FromName(caller.ToString());

            EffectManager.askEffectClearByID(8500, playerid.CSteamID);
            EffectManager.askEffectClearByID(8501, playerid.CSteamID);
            EffectManager.askEffectClearByID(8502, playerid.CSteamID);
            EffectManager.askEffectClearByID(8503, playerid.CSteamID);

        }
    }
}