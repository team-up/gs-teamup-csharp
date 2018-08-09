using Newtonsoft.Json;

namespace GsTeamupChat
{
    class Extras
    {
        [JsonProperty(PropertyName = "2")] // version 2
        internal Extra extra { get; set; }

        public Extras(Extra extra)
        {
            this.extra = extra;
        }
    }
}