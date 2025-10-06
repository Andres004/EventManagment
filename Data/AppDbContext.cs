using EventManagment.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EventManagment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Event> Events => Set<Event>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(t =>
            {
                t.HasKey(x => x.Id);

                // Configuración para almacenar List<string> en la base de datos
                t.Property(x => x.Notes)
                    .HasConversion(
                        v => v == null ? null : string.Join(';', v),
                        v => string.IsNullOrEmpty(v) ? new List<string>() : v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                    )
                    .HasMaxLength(500); // Longitud máxima para el campo en la BD
            });

            modelBuilder.Entity<Event>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).IsRequired().HasMaxLength(100);
            });

        }
    }
}