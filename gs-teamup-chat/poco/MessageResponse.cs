using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace gs_teamup_chat
{
    class MessageResponse
    {
        [JsonProperty]
        private int msg { get; set; }
    }
}
