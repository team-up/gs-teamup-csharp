using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace gs_teamup_chat
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
