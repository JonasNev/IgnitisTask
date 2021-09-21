using IgnitisTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgnitisTask.Data
{
    public class DataContext : DbContext
    {
        public DbSet<AnswerModel> Answers { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<Junction> Junctions { get; set; }
        public IEnumerable<object> SelectedValues { get; internal set; }

        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Junction>()
                .HasKey(j => new { j.QuestionId, j.AnswerId, j.FormId });
            modelBuilder.Entity<Junction>()
                .HasOne(bc => bc.Question)
                .WithMany(b => b.Junctions)
                .HasForeignKey(bc => bc.QuestionId);
            modelBuilder.Entity<Junction>()
                .HasOne(bc => bc.Answer)
                .WithMany(c => c.Junctions)
                .HasForeignKey(bc => bc.AnswerId);

        }
    }
}
