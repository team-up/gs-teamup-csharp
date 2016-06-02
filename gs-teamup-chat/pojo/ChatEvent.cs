using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace gs_teamup_chat
{
    class ChatEvent
    {
        [JsonProperty]
        internal int team { get; set; }
        [JsonProperty]
        internal int room { get; set; }
        [JsonProperty]
        internal int type { get; set; }
        [JsonProperty]
        internal int msg { get; set; }
        [JsonProperty]
        internal int user { get; set; }
    }
}
