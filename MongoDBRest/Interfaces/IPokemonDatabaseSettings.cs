namespace MongoDBRest.Interfaces
{
	public interface IPokemonDatabaseSettings
	{
		string SpeciesCollectionName { get; set; }
		string MovesCollectionName { get; set; }
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
	}
}