using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Test.Domain.Entity;

namespace Project.Test.Infra.Data.Mapping
{
    public class ManobraMapping : IEntityTypeConfiguration<Manobra>
    {
        public void Configure(EntityTypeBuilder<Manobra> builder)
        {
            // Table name
            builder.ToTable("Manobra");

            // Key
            builder.HasKey(x => x.Id);

            // Columns
            builder.Property(x => x.CarroId);
            builder.Property(x => x.ManobristaId);
            builder.Property(x => x.Active);
        }
    }
}