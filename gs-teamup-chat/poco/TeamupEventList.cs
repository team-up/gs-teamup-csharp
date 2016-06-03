using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gs_teamup_chat
{
    class TeamupEventList
    {
        [JsonProperty("events")]
        internal TeamupEvent[] events { get; set;}
    }
}
