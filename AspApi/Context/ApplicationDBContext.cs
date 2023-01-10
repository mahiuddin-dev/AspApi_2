using AspApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspApi.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
    }
}
