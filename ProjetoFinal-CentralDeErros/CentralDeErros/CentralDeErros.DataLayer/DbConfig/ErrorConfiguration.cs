
using CentralDeErros.DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CentralDeErros.DataLayer.DbConfig
{
    class ErrorConfiguration : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> modelBuilder)
        {
            modelBuilder
                .HasKey(x => x.Id);
            modelBuilder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder
                .Property(x => x.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            modelBuilder
                .HasOne(x => x.Level)
                .WithMany(e => e.Errors)
                .IsRequired();
            modelBuilder
               .HasOne(x => x.Environment)
               .WithMany(e => e.Errors)
               .IsRequired();
        }

    }
}
