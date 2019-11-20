using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Test.Domain.Entity;

namespace Project.Test.Infra.Data.Mapping
{
    public class ManobristaMapping : IEntityTypeConfiguration<Manobrista>
    {
        public void Configure(EntityTypeBuilder<Manobrista> builder)
        {
            // Table name
            builder.ToTable("Manobrista");

            // Key
            builder.HasKey(x => x.Id);

            // Columns
            builder.Property(x => x.Nome).HasMaxLength(255);
            builder.Property(x => x.CPF).HasMaxLength(11);
            builder.Property(x => x.DataNascimento);
            builder.Property(x => x.Active);

            // Relatioships
            builder
                .HasMany(x => x.Manobras)
                .WithOne(x => x.Manobrista)
                .HasForeignKey(s => s.ManobristaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}