using System;
using Newtonsoft.Json;

namespace PokeApi
{
    public class PagingObject
    {
        [JsonProperty("count")]
        public int Count { get; internal set; }

        [JsonProperty("next")]
        public Uri Next { get; internal set; }

        [JsonProperty("previous")]
        public Uri Previous { get; internal set; }

        [JsonProperty("results")]
        public NamedApiObject[] Results { get; internal set; }

    }
}
