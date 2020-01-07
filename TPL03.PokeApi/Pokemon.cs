
using Newtonsoft.Json;

namespace PokeApi
{
    public class Pokemon : ApiObject
    {
        [JsonProperty("base_experience")]
        public int BaseExperience { get; internal set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; internal set; }

        [JsonProperty("height")]
        public int Height { get; internal set; }

        [JsonProperty("weight")]
        public int Mass { get; internal set; }

        [JsonProperty("order")]
        public int Order { get; internal set; }

        [JsonProperty("abilities")]
        public PokemonAbility[] Abilities { get; internal set; }

        [JsonProperty("types")]
        public PokemonType[] Types { get; internal set; }
    }
}