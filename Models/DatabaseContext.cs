
using Microsoft.EntityFrameworkCore;

namespace LeadManager.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.SetCommandTimeout(180);
        }
    }
}