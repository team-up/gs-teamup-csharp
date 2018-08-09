using Newtonsoft.Json;

namespace GsTeamupChat
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
        [JsonProperty]
        internal Extras extras { get; set; }

        public string GetExtraUserResponseId()
        {
            if (extras == null || extras.extra == null)
                return "";
            if (extras.extra.type != "user")
                return "";
            return extras.extra.response_id ?? "";
        }
    }
}
