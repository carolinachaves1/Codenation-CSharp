using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CentralDeErros.DataLayer.DbConfig
{
    class EnvironmentConfiguration : IEntityTypeConfiguration<Models.Environment>
    {
        public void Configure(EntityTypeBuilder<Models.Environment> modelBuilder)
        {
            modelBuilder
                .Property(x => x.Name).IsRequired()
                .HasMaxLength(100);
            modelBuilder
                .HasKey(x => x.Id);
            modelBuilder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder
                .HasMany(x => x.Errors)
                .WithOne(e => e.Environment)
                .IsRequired();
        }
    }
}
