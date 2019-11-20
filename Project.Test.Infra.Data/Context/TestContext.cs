using Microsoft.EntityFrameworkCore;
using Project.Test.Domain.Entity;
using Project.Test.Infra.Data.Mapping;
using System;

namespace Project.Test.Infra.Data.Context
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new Exception("Connection string is not configured.");
            }
        }

        public DbSet<Carro> Carro { get; set; }
        public DbSet<Manobra> Manobra { get; set; }
        public DbSet<Manobrista> Manobrista { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarroMapping());
            builder.ApplyConfiguration(new ManobristaMapping());
            builder.ApplyConfiguration(new ManobraMapping());

            base.OnModelCreating(builder);
        }
    }
}