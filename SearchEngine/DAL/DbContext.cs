namespace SearchEngine.DAL
{

    public class DbContext
    {
        private string connectionString;

        public DbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}