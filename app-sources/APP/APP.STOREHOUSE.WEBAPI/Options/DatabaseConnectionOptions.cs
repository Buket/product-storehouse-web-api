namespace APP.STOREHOUSE.WEBAPI.Options
{
    public class DatabaseConnectionOptions
    {
        public const string DatabaseConnection = "DatabaseConnection";

        public string ConnectionString { get; set; } = string.Empty;
    }
}
