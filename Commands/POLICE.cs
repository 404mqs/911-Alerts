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

    public class POLICE_CALL : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public string Name => "101";
        public string Help => "";
        public string Syntax => throw new NotImplementedException();
        public List<string> Aliases => new List<string>() { "callpolice", "callcops" };
        public List<string> Permissions => new List<string> { "police.call" };

        public List<UnturnedPlayer> GetPlayersWithPermission(string permission)
        {
            return Provider.clients.Select(UnturnedPlayer.FromSteamPlayer).Where(player => player.HasPermission(permission)).ToList();
        }

        public void Execute(IRocketPlayer caller, string[] args)
        {
            var name = caller.DisplayName;
            var playername = "!playerName!";
            var text = "!Message!";
            var message = string.Join(" ", args);
            var players = GetPlayersWithPermission("police.message");
            foreach (var player in players)
            {
                if (MQSPlugin.Instance.Configuration.Instance.TextMode)
                {
                    UnturnedChat.Say(caller, MQSPlugin.Instance.Configuration.Instance.PoliceMessage.Replace('{', '<').Replace('}', '>').Replace(playername, name).Replace(text, message), true);
                }
                else
                {
                    if (MQSPlugin.Instance.Configuration.Instance.EnglishUIs)
                    {
                        EffectManager.sendUIEffect(8503, 4205, player.CSteamID, true, message, name);
                    }
                    if (MQSPlugin.Instance.Configuration.Instance.SpanishUIs)
                    {
                        EffectManager.sendUIEffect(8502, 4205, player.CSteamID, true, message, name);
                    }
                }
            }
            UnturnedChat.Say(caller, MQSPlugin.Instance.Configuration.Instance.PoliceMessageSent.Replace('{', '<').Replace('}', '>'), true);
        }

    }

}