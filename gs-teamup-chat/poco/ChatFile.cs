using System;
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
