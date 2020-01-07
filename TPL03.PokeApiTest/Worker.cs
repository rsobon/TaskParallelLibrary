using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPL01.Service;

namespace TPL01
{
    public class Worker : IWorker
    {
        private readonly IPokemonService _pokemonService;

        public Worker(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task GetAllPokemon()
        {
            var pokemonPage = await _pokemonService.GetPokemonPageAsync().ConfigureAwait(false);

            Console.WriteLine($"Pokemon count: {pokemonPage.Count}\n");

            await ProcessAllPokemon(pokemonPage.Count).ConfigureAwait(false);
        }

        private async Task ProcessAllPokemon(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                var pokemon = await _pokemonService.GetSinglePokemonAsync(i).ConfigureAwait(false);

                var sb = new StringBuilder();
                sb.AppendLine($"Pokemon name: {pokemon.Name}");
                string[] arrayOfTypes = pokemon.Types.Select(t => t.Type.Name).ToArray();
                sb.AppendLine($"Pokemon types: {string.Join(", ", arrayOfTypes)}");

                Console.WriteLine(sb.ToString());

                await Task.Delay(1000);
            }
        }
    }
}
