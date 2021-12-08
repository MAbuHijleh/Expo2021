using Expotech2021.Models;
using Microsoft.EntityFrameworkCore;

namespace Expotech2021
{
    public class ApplicationBDContext : DbContext
    {
        public ApplicationBDContext(DbContextOptions<ApplicationBDContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<QuestionAnswerModel> Questions { get; set; }
        public DbSet<QuestionareEntry> Entries { get; set; }

    }
}
