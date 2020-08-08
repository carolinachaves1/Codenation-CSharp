using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CentralDeErros.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using CentralDeErros.DataLayer.DbConfig;

namespace CentralDeErros.DataLayer
{
    public class CentralDeErrosContext : IdentityDbContext
    {
        public DbSet<Error> Errors { get; set; }
        public DbSet<Environment> Categories { get; set; }
        public DbSet<Level> Levels { get; set; }

        public CentralDeErrosContext(DbContextOptions<CentralDeErrosContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=DBCentralDeErros;Integrated Security=True", b => b.MigrationsAssembly("CentralDeErros.DataLayer"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EnvironmentConfiguration());
            modelBuilder.ApplyConfiguration(new ErrorConfiguration());
            modelBuilder.ApplyConfiguration(new LevelConfiguration());
        }
    }

   
}
