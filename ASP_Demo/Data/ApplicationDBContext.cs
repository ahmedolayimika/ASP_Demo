using ASP_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Demo.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; }
    }
}