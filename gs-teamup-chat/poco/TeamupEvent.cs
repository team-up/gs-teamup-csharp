﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GsTeamupChat
{
    class TeamupEvent
    {
        [JsonProperty("type")]
        internal string type { get; set; }
        [JsonProperty("chat")]
        internal ChatEvent chat { get; set; }
    }
}
