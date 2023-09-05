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
        public DbSet<ImageUris> ImageUris { get; set; } // DbSet para a entidade ImageUris
        public DbSet<Legalidades> Legalidades { get; set; } // DbSet para a entidade Legalidades

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
