using Microsoft.EntityFrameworkCore;
using Zula.API.Models;

namespace Zula.API.EFCore
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
