using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpoAdmin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //entities
        public DbSet<QuestionAnswerModel> Questions { get; set; }
        public DbSet<QuestionareEntry> Entries { get; set; }
        public DbSet<RegistredUser> Users { get; set; }

    }
}
