using SearchEngine.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SearchEngine.DAL
{

    public class WordContext : System.Data.Entity.DbContext
    {
        public DbSet<Word> Words { get; set; }

        public DbSet<WordCount> WordCounts { get; set; }

        public DbSet<WordIndex> WordsIndex { get; set; }

        public DbSet<Document> Documents { get; set; }

        public WordContext() : base("data source=.; initial catalog =WordContext;user id=sa;password=root;multipleactiveresultsets=True")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
