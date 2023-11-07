using Bulkybookweb.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulkybookweb.Data
{
    public class ApplicationDbContext :DbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
 
        }

        public DbSet<Category> Categories { get; set; }
    }
}
