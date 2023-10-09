using Microsoft.EntityFrameworkCore;
using Scryfall_Admin.Models;
using System.Collections.Generic;

namespace Scryfall_Admin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Carta> Cartas { get; set; }
        public DbSet<CartaImagensUris> ImageUris { get; set; } // DbSet para a entidade ImageUris
        public DbSet<CartaLegalidades> Legalidades { get; set; } // DbSet para a entidade Legalidades

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carta>()
               .HasOne(c => c.Legalidades)
               .WithMany(c => c.Cartas)
                .HasForeignKey(p => p.LegalidadesId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Carta>()
               .HasOne(c => c.ImagemUris)
               .WithMany(c => c.Cartas)
               .HasForeignKey(p => p.ImagemUrisId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartaImagensUris>()
               .HasMany(c => c.Cartas)
               .WithOne(c => c.ImagemUris)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartaLegalidades>()
              .HasMany(c => c.Cartas)
              .WithOne(c => c.Legalidades)
              .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
