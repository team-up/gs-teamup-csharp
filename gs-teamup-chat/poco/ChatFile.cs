using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GsTeamupChat
{
    class ChatFile
    {
        [JsonProperty]
        internal int file { get; set; }
        [JsonProperty]
        internal int type { get; set; }
        [JsonProperty]
        internal string name { get; set; }
        [JsonProperty]
        internal int w { get; set; }
        [JsonProperty]
        internal int h { get; set; }
        [JsonProperty]
        internal int size { get; set; }
    }
}
