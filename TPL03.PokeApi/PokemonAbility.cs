using Newtonsoft.Json;

namespace PokeApi
{
    public class PokemonAbility
    {
        [JsonProperty("is_hidden")]
        public bool IsHidden { get; internal set; }

        [JsonProperty("slot")]
        public int Slot { get; internal set; }

        [JsonProperty("ability")]
        public NamedApiObject Ability { get; internal set; }
    }
}