public interface IAppSettings
{ 
    DatabaseOptions Database { get; set; }
} 

public class DatabaseOptions{
    public string ConnectionString { get; set; }
}