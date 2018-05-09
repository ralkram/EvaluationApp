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
    }
}
