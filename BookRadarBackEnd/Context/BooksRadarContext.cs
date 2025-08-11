using BookRadarBackEnd.Configuration;
using BookRadarBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRadarBackEnd.Context
{
    public partial class BooksRadarContext : DbContext
    {
        public BooksRadarContext(DbContextOptions<BooksRadarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BooksModel> Books { get; set; }
        public virtual DbSet<HistorialBusquedasModel> HistorialBusquedas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HistorialBusquedasConfiguration());
        }
    }
}
