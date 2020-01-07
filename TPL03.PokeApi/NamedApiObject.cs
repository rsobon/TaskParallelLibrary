using System;
using Newtonsoft.Json;

namespace PokeApi
{
    public class NamedApiObject
    {
        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("url")]
        public Uri Url { get; internal set; }
    }
}
