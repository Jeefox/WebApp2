using System.Data.Entity;

namespace WebApplication2
{
    public class FileContext : DbContext
    {
        public FileContext()
            : base("DbConnection")
        { }

        public DbSet<File> Files { get; set; }
    }
}
