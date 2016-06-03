using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace gs_teamup_chat
{
    class ChatMessage
    {
        [JsonProperty]
        internal int team { get; set; }
        [JsonProperty]
        internal int user { get; set; }
        [JsonProperty]
        internal int type { get; set; }
        [JsonProperty]
        internal int len { get; set; }
        [JsonProperty]
        internal string content { get; set; }
        [JsonProperty]
        internal long created { get; set; }
        [JsonProperty]
	    internal ChatFile fileinfo { get; set; }
    }
}
