using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.DbContext
{
    public class Context : Microsoft.EntityFrameworkCore.DbContext
    {
        public Context(DbContextOptions option) : base(option)
        {}

        public DbSet<Movie> Movies { get; set; }
    }
}
