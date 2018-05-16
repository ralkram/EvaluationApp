using EvaluationApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluationApp.Persistence.EF
{
    public class EvaluationDbContext : DbContext
    {
        public EvaluationDbContext(DbContextOptions<EvaluationDbContext> options)
          : base(options)
        {

        }

        public virtual DbSet<Evaluation> Evaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Evaluation>()
                .HasMany<Section>(e => e.Sections)
                .WithOne(s => s.Evaluation);
        }
    }
}
