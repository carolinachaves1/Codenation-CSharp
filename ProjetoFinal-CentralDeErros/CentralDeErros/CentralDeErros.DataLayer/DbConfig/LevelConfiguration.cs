using CentralDeErros.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralDeErros.DataLayer.DbConfig
{
    class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> modelBuilder)
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
                .WithOne(e => e.Level)
                .IsRequired();
        }
    }
}
