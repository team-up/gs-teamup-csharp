using Newtonsoft.Json;

namespace GsTeamupChat
{
    class Message
    {
        [JsonProperty]
        internal string content { get; set; }

        [JsonProperty]
        internal Extras extras { get; set; }

        public Message(string msg, Extras exstras = null)
        {
            this.content = msg;
            this.extras = exstras;
        }
    }
}
