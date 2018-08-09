using Newtonsoft.Json;

namespace GsTeamupChat
{
    class Extra
    {
        [JsonProperty]
        internal string type { get; set; }        

        [JsonProperty]
        internal Button[] message_buttons { get; set; }

        [JsonProperty]
        internal Button[] scroll_buttons { get; set; }

        [JsonProperty]
        internal Bottom bottom { get; set; }        

        [JsonProperty]
        internal string response_id { get; set; }

        static public Extra NewInstance(Button[] message_buttons = null, Button[] scroll_buttons = null, Bottom bottom = null)
        {
            if (message_buttons == null && scroll_buttons == null && bottom == null)
            {
                return null;
            }

            return new Extra
            {
                type = "bot",
                message_buttons = message_buttons,
                scroll_buttons = scroll_buttons,
                bottom = bottom
            };
        }
    }
}
