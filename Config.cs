
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using System.Threading.Tasks;

namespace EMS
{

    public class Config : IRocketPluginConfiguration

    {
        public bool SpanishUIs;
        public bool EnglishUIs;
        public bool TextMode;

        public string EMSMessage { get; set; }
        public string EMSMessageSent { get; set; }
        public string PoliceMessage { get; set; }
        public string PoliceMessageSent { get; set; }


        public void LoadDefaults()
        {

             EMSMessage = "{color=#FF4536}{b}[EMS] ALERT FROM !playerName!: !Message!{/b}{/color}";
             EMSMessageSent = "{color=#FF4536}{b}The Message was sent to the EMS! {/b}{/color}";
             PoliceMessage = "{color=#006CFF}{b}[POLICE] ALERT FROM !playerName!: !Message!{/b}{/color}";
             PoliceMessageSent = "{color=#006CFF}{b}The Message was sent to the Police. {/b}{/color}";
             TextMode = false;
             SpanishUIs = false;
             EnglishUIs = true;


            
        }
    }
}
