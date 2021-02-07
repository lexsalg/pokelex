using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeLexApi.Interfaces;
using PokeLexApi.Models;
using PokeLexApi.Models.Seed;

namespace PokeLexApi.Services
{
    public class LoadDataService : ILoadDataService
    {

        private readonly IPokemonRepository _pokemonRepository;
        private readonly IPokemonMoveRepository _pokemonMoveRepository;
        private readonly IPokemonTypeRepository _pokemonTypeRepository;
        private readonly IImageRepository _imageRepository;

        public LoadDataService(
            IPokemonRepository pokemonRepository,
            IPokemonMoveRepository pokemonMoveRepository,
            IPokemonTypeRepository pokemonTypeRepository,
            IImageRepository imageRepository)
        {
            _pokemonRepository = pokemonRepository;
            _pokemonMoveRepository = pokemonMoveRepository;
            _pokemonTypeRepository = pokemonTypeRepository;
            _imageRepository = imageRepository;
        }


        public async Task LoadData()
        {
            var tasks = new List<Task>();

            tasks.Add(loadData<PokemonSeed>("pokedex"));
            tasks.Add(loadData<PokemonMove>("moves"));
            tasks.Add(loadData<PokemonType>("types"));
            tasks.Add(loadImages());

            await Task.WhenAll(tasks);
        }

        private Task loadData<T>(string nameFile)
        {
            return Task.Run(() =>
            {
                var file = System.IO.File.ReadAllText("SeedData/" + nameFile + ".json");
                var list = JsonConvert.DeserializeObject<List<T>>(file);

                if (typeof(T).Equals(typeof(PokemonSeed)))
                {
                    var pokemonsSeed = (List<PokemonSeed>)(object)list;
                    _pokemonRepository.AddPokemons(mapTo(pokemonsSeed));
                }
                else if (typeof(T).Equals(typeof(PokemonMove)))
                {
                    _pokemonMoveRepository.AddPokemonMoves((List<PokemonMove>)(object)list);
                }
                else if (typeof(T).Equals(typeof(PokemonType)))
                {
                    _pokemonTypeRepository.AddPokemonTypes((List<PokemonType>)(object)list);
                }
            });
        }

        private List<Pokemon> mapTo(List<PokemonSeed> pokemonsSeed)
        {
            var pokemons = new List<Pokemon>();
            foreach (var p in pokemonsSeed)
            {
                pokemons.Add(new Pokemon
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.Type,
                    Base = new PokemonBase
                    {
                        Hp = p.Base.Hp,
                        Attack = p.Base.Attack,
                        Defense = p.Base.Defense,
                        SpAttack = p.Base.SpAttack,
                        SpDefense = p.Base.SpDefense,
                        Speed = p.Base.Speed,
                    }
                });
            }
            return pokemons;
        }

        private Task loadImages()
        {
            return Task.Run(() =>
            {
                DirectoryInfo dir = new DirectoryInfo("SeedData/images");
                var i = 1;

                var images = new List<Image>();

                foreach (FileInfo file in dir.GetFiles())
                {
                    byte[] bytes = System.IO.File.ReadAllBytes($"SeedData/images/{file.Name}");
                    images.Add(new Image { Id = i.ToString(), ContentImage = bytes });
                    i++;
                }
                _imageRepository.AddPokemonImages(images);
            });
        }

        public async Task DeleteData()
        {
            await this._pokemonRepository.RemoveAllPokemons();
            await this._pokemonMoveRepository.RemoveAll();
            await this._pokemonTypeRepository.RemoveAll();
            await this._imageRepository.RemoveAll();
        }
    }
}
