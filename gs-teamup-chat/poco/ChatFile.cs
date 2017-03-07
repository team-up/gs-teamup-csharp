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
        internal String id { get; set; }
        [JsonProperty]
        internal FileType type { get; set; }
        [JsonProperty]
        internal string name { get; set; }
        [JsonProperty]
        internal long size { get; set; }
        [JsonProperty]
        internal int owner { get; set; }
    }
}
