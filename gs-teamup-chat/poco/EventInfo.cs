using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GsTeamupChat
{
    class EventInfo
    {
        [JsonProperty("version")]
        internal string version { get; set; }
        [JsonProperty("lp_idle_time")]
        internal int lpIdleTime { get; set; }
        [JsonProperty("lp_wait_timeout")]
        internal int lpWaitTimeout { get; set; }

    }
}