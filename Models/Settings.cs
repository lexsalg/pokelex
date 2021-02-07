namespace PokeLexApi.Models
{
    public class Settings
    {
        public string ConnectionString;
        public string Database;
    }

    public class PokemonDatabaseSettings : IPokemonDatabaseSettings
    {
        public string PokemonsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPokemonDatabaseSettings
    {
        string PokemonsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
