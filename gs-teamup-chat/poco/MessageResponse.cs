using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GsTeamupChat
{
    class MessageResponse
    {
        [JsonProperty]
        private int msg { get; set; }
    }
}
