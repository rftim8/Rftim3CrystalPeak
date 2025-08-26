namespace Rftim3WinFormsCL
{
    public class RftDatabaseConnections(string? northwindConnection = null,
        string? leetCodeConnection = null,
        string? sqliteConnection = null,
        string? repairConnection = null)
    {
        private readonly string? northwindConnection = northwindConnection;
        public string? NorthwindConnection => northwindConnection;

        private readonly string? leetCodeConnection = leetCodeConnection;
        public string? LeetCodeConnection => leetCodeConnection;

        private readonly string? sqliteConnection = sqliteConnection;
        public string? SqliteConnection => sqliteConnection;

        private readonly string? repairConnection = repairConnection;
        public string? RepairConnection => repairConnection;
    }
}
