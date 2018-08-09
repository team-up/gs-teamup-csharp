using Newtonsoft.Json;

namespace GsTeamupChat
{
    class Bottom
    {
        [JsonProperty]
        internal string type { get; set; }

        [JsonProperty]
        internal string id { get; set; }

        [JsonProperty]
        internal bool? range { get; set; }

        [JsonProperty]
        internal Button[] buttons { get; set; }

        static public Bottom NewTextInstance(string text_id = null)
        {
            Bottom bottom = new Bottom
            {
                type = "text",
                id = text_id
            };
            return bottom;
        }

        static public Bottom NewCalendarInstance(bool range, string calendar_id = null)
        {
            Bottom bottom = new Bottom
            {
                type = "calendar",
                range = range,
                id = calendar_id
            };
            return bottom;
        }

        static public Bottom NewButtonInstance(Button[] buttons)
        {
            Bottom bottom = new Bottom
            {
                type = "button",
                buttons = buttons
            };
            return bottom;
        }
    }
}
