using Microsoft.EntityFrameworkCore;


namespace GD
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<InformationTo> InformationTos { get; set; }
        public object User { get; internal set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {         
            optionsBuilder.UseSqlite("Filename=User.sqlite");
        }

    }
}

