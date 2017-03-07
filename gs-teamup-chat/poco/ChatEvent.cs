using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GsTeamupChat
{
    class ChatEvent
    {
        [JsonProperty]
        internal int team { get; set; }
        [JsonProperty]
        internal long room { get; set; }
        [JsonProperty]
        internal int type { get; set; }
        [JsonProperty]
        internal int user { get; set; }
        [JsonProperty]
        internal long msg { get; set; }
        [JsonProperty]
        internal int alert { get; set; }
        [JsonProperty]
        internal String name { get; set; }
    }
}
