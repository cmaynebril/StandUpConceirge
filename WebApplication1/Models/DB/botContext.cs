using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models.DB
{
    public partial class botContext : DbContext
    {
        public botContext()
        {
        }

        public botContext(DbContextOptions<botContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BotAnswers> BotAnswers { get; set; }
        public virtual DbSet<BotQuestions> BotQuestions { get; set; }
        public virtual DbSet<BotSchedule> BotSchedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=bot;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<BotAnswers>(entity =>
            {
                entity.ToTable("botAnswers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Answer).HasColumnType("text");

                entity.Property(e => e.BotQuestionId).HasColumnName("botQuestionID");

                entity.Property(e => e.RespondentId).HasColumnName("RespondentID");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<BotQuestions>(entity =>
            {
                entity.ToTable("botQuestions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BotScheduleId).HasColumnName("botScheduleID");

                entity.Property(e => e.Question).HasColumnType("text");
            });

            modelBuilder.Entity<BotSchedule>(entity =>
            {
                entity.ToTable("botSchedule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DayOccur).HasColumnType("text");

                entity.Property(e => e.FrequencyOccur).HasColumnType("text");

                entity.Property(e => e.Respondents).HasColumnType("text");

                entity.Property(e => e.StartDay).HasColumnType("date");

                entity.Property(e => e.WelcomeMsg).HasColumnType("text");
            });
        }
    }
}
