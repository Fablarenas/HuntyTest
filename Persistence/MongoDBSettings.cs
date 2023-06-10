namespace Persistence
{
    public class MongoDBSettings: IMongoDBSettings
    {
        public string? ConnectionString
        {
            get; set;
        }
        public string? DatabaseName
        {
            get; set;
        }
        public string? MessageCollectionName { get; set; }
    }
    public interface IMongoDBSettings
    {
        string? ConnectionString
        {
            get; set;
        }
        string? DatabaseName
        {
            get; set;
        }
        public string? MessageCollectionName { get; set; }
    }
}