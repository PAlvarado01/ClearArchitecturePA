using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWind.Entities.POCOEntities;

namespace NorthWind.Repositories.EFCore.EntityConfigurations
{
    public class ArchivoConfiguration : IEntityTypeConfiguration<Archivo> 
    {
        public void Configure(EntityTypeBuilder<Archivo> builder)
        {
            builder.Property(c => c.Id)
                .HasMaxLength(5)
                .IsFixedLength();

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Extension)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.Tamanio)
                .IsRequired()
                .HasMaxLength(53);

            builder.Property(c => c.Ubicacion)
                .IsRequired();
        }
    }
}
