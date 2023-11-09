using KnowledgeHubProtal.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubProtal.Models.DataAccess
{

    //update-database -Context KnowledgeHubProtal.Models.DataAccess.KHPDbContext

    //add-migration -Context KnowledgeHubProtal.Models.DataAccess.KHPDbContext

    public class KHPDbContext : DbContext
    {
        // configure the database

        public KHPDbContext(DbContextOptions<KHPDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=KHPDBEY2023;Integrated Security=True");
            }
        }

        // map the tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
