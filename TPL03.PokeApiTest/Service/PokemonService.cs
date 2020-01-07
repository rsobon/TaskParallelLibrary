using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeApi;

namespace TPL01.Service
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _apiUri = new Uri("https://pokeapi.co/api/v2/");

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PagingObject> GetPokemonPageAsync()
        {
            var uri = new Uri(_apiUri, "pokemon");
            var allPokemon = await GetApiObjectAsync<PagingObject>(uri.ToString()).ConfigureAwait(false);
            return allPokemon;
        }

        public async Task<Pokemon> GetSinglePokemonAsync(int pokemonId)
        {
            var uri = new Uri(_apiUri, $"pokemon/{pokemonId}");
            var pokemon = await GetApiObjectAsync<Pokemon>(uri.ToString()).ConfigureAwait(false);
            return pokemon;
        }

        private async Task<T> GetApiObjectAsync<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _httpClient.Dispose();
        }
    }
}
