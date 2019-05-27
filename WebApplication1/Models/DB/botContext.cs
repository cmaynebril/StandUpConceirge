using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StandUpConceirge.Models.DB
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
        public virtual DbSet<BotUsers> BotUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Questions)
                    .HasColumnName("questions")
                    .HasColumnType("text");

                entity.Property(e => e.ScheduleId).HasColumnName("scheduleId");
            });

            modelBuilder.Entity<BotSchedule>(entity =>
            {
                entity.ToTable("botSchedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Creator).HasColumnType("text");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Day)
                    .HasColumnName("day")
                    .HasColumnType("text");

                entity.Property(e => e.Frequency)
                    .HasColumnName("frequency")
                    .HasColumnType("text");

                entity.Property(e => e.Friday).HasColumnType("text");

                entity.Property(e => e.Monday).HasColumnType("text");

                entity.Property(e => e.Respondents).HasColumnType("text");

                entity.Property(e => e.Saturday).HasColumnType("text");

                entity.Property(e => e.ScheduleId).HasColumnName("scheduleId");

                entity.Property(e => e.Sunday).HasColumnType("text");

                entity.Property(e => e.Thursday).HasColumnType("text");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.Tuesday).HasColumnType("text");

                entity.Property(e => e.Wednesday).HasColumnType("text");

                entity.Property(e => e.WelcomeMsg).HasColumnType("text");
            });

            modelBuilder.Entity<BotUsers>(entity =>
            {
                entity.ToTable("botUsers");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmailAdd).HasColumnType("text");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.Password).HasColumnType("text");
            });
        }
    }
}
