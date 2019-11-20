using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Test.Domain.Entity;

namespace Project.Test.Infra.Data.Mapping
{
    public class CarroMapping : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            // Table name
            builder.ToTable("Carro");

            // Key
            builder.HasKey(x => x.Id);

            // Columns
            builder.Property(x => x.Marca).HasMaxLength(255);
            builder.Property(x => x.Modelo).HasMaxLength(255);
            builder.Property(x => x.Active);

            // Relatioships
            builder
                .HasMany(x => x.Manobras)
                .WithOne(x => x.Carro)
                .HasForeignKey(s => s.CarroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}