using BookRadarBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookRadarBackEnd.Configuration
{
    public class BooksConfiguration : IEntityTypeConfiguration<HistorialBusquedasModel>
    {
        public void Configure(EntityTypeBuilder<HistorialBusquedasModel> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("Books");
            builder.Property(e => e.Id).HasColumnName("Id");
            builder.Property(e => e.Titulo)
                .HasMaxLength(255)
                .HasColumnName("Titulo");
            builder.Property(e => e.AnioPublicacion)
                .HasMaxLength(15)
                .HasColumnName("AnioPublicacion");
            builder.Property(e => e.Editorial)
                .HasMaxLength(255)
                .HasColumnName("Editorial");
            builder.Property(e => e.Autor)
                .HasMaxLength(255)
                .HasColumnName("Autor");
            builder.Property(e => e.FechaConsulta).HasColumnName("FechaConsulta");
        }
    }
}
