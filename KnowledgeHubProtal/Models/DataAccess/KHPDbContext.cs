using KnowledgeHubProtal.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubProtal.Models.DataAccess
{

    //update-database -Context KnowledgeHubProtal.Models.DataAccess.KHPDbContext

    //add-migration -Context KnowledgeHubProtal.Models.DataAccess.KHPDbContext

    public class KHPDbContext : DbContext
    {
        // configure the database

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=KHPDBEY2023;Integrated Security=True");
        }

        // map the tables
        public DbSet<Category> Categories { get; set; }
    }
}
