using System;
using System.Net.Http;
using Autofac;
using TPL01.Service;

namespace TPL01
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PokemonService>().As<IPokemonService>();
            builder.RegisterType<Worker>().As<IWorker>().SingleInstance();
            builder.Register(c => new HttpClient()).As<HttpClient>();
            var container = builder.Build();

            var worker = container.Resolve<IWorker>();

            worker.GetAllPokemon().GetAwaiter().GetResult();

            Console.WriteLine("Finished.");
            Console.ReadKey();
        }
    }
}
