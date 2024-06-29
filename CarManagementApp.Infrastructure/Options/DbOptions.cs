namespace CarManagementApp.Infrastructure.Options
{
    public class DbOptions
    {
        public static string SECTION = "DbOptions";
        public string ConnectionString { get; set; } = null!;
    }
}
