﻿using Newtonsoft.Json;

namespace GsTeamupChat
{
    class MessageResponse
    {
        [JsonProperty]
        internal long msg { get; set; }
    }
}
