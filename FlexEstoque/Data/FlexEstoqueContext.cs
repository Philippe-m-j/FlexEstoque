using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlexEstoque.Models;

namespace FlexEstoque.Data
{
    public class FlexEstoqueContext : DbContext
    {
        public FlexEstoqueContext (DbContextOptions<FlexEstoqueContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlexEstoqueContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
                optionsBuilder.EnableSensitiveDataLogging()
                    .UseSqlite("Data Source=FlexEstoque.db");
        }

        public DbSet<FlexEstoque.Models.Produto> Produto { get; set; } = default!;
    }
}
