using System;
using System.Threading.Tasks;
using PokeApi;

namespace TPL01.Service
{
    public interface IPokemonService : IDisposable
    {
        Task<PagingObject> GetPokemonPageAsync();

        Task<Pokemon> GetSinglePokemonAsync(int pokemonId);
    }
}