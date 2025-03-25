namespace EstateMaster.Server.Core
{
    public class AppSettings : IAppSettings
    {
        public DatabaseOptions Database { get; set; }

        
        public AppSettings()
        {
            Database = new DatabaseOptions();
        } 
     
    }
}