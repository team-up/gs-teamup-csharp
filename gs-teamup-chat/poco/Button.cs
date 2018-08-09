using Newtonsoft.Json;

namespace GsTeamupChat
{
    class Button
    {
        [JsonProperty]
        internal string type { get; set; }

        [JsonProperty]
        internal string id { get; set; }

        [JsonProperty]
        internal string url { get; set; }

        [JsonProperty]
        internal string button_text { get; set; }

        [JsonProperty]
        internal string response_text { get; set; }

        static public Button NewTextInstance(string button_text, string button_id = null, string response_text = null)
        {
            Button button = new Button
            {
                type = "text",
                button_text = button_text,
                id = button_id ?? "",
                response_text = response_text ?? button_text
            };
            return button;
        }

        static public Button NewUrlInstance(string button_text, string url)
        {
            return new Button
            {
                type = "url",
                button_text = button_text,
                url = url
            };
        }
    }
}
