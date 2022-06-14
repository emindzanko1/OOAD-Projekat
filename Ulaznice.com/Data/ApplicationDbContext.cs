using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Ulaznice.com.Models;

namespace Ulaznice.com.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Karta> Karta { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Lokacija> Lokacija { get; set; }
        public DbSet<Manifestacija> Manifestacija { get; set; }
        public DbSet<NacinPlacanja> NacinPlacanjata { get; set; }
        public DbSet<Nagrada> Nagrada { get; set; }
        public DbSet<NagradnaIgra> NagradnaIgra { get; set; }
        public DbSet<PorukaDobitnik> PorukaDobitnik { get; set; }
        public DbSet<PovratniMail> PovratniMail { get; set; }
        public DbSet<SlobodnaMjesta> SlobodnaMjesta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Karta>().ToTable("Karta");
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Lokacija>().ToTable("Lokacija");
            modelBuilder.Entity<Manifestacija>().ToTable("Manifestacija");
            modelBuilder.Entity<NacinPlacanja>().ToTable("NacinPlacanja");
            modelBuilder.Entity<Nagrada>().ToTable("Nagrada");
            modelBuilder.Entity<NagradnaIgra>().ToTable("NagradnaIgra");
            modelBuilder.Entity<PorukaDobitnik>().ToTable("PorukaDobitnik");
            modelBuilder.Entity<PovratniMail>().ToTable("PovratniMail");
            modelBuilder.Entity<SlobodnaMjesta>().ToTable("SlobodnaMjesta");
            base.OnModelCreating(modelBuilder);
        }
    }
}
