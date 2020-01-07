using Newtonsoft.Json;

namespace PokeApi
{
    public abstract class ApiObject : NamedApiObject
    {
        [JsonProperty("id")]
        public int Id { get; internal set; }
    }
}
