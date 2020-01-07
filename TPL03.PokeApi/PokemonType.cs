
using Newtonsoft.Json;

namespace PokeApi
{
    public class PokemonType
    {
        [JsonProperty("slot")]
        public int Slot { get; internal set; }

        [JsonProperty("type")]
        public NamedApiObject Type { get; internal set; }

    }
}