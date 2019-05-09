﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models.DB;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(botContext))]
    [Migration("20190509052809_dbMigration1")]
    partial class dbMigration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.DB.BotAnswers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("text");

                    b.Property<int?>("BotQuestionId")
                        .HasColumnName("botQuestionID");

                    b.Property<int?>("RespondentId")
                        .HasColumnName("RespondentID");

                    b.Property<DateTime?>("TimeStamp")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("botAnswers");
                });

            modelBuilder.Entity("WebApplication1.Models.DB.BotQuestions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BotScheduleId")
                        .HasColumnName("botScheduleID");

                    b.Property<string>("Question")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("botQuestions");
                });

            modelBuilder.Entity("WebApplication1.Models.DB.BotSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DayOccur")
                        .HasColumnType("text");

                    b.Property<string>("FrequencyOccur")
                        .HasColumnType("text");

                    b.Property<string>("Respondents")
                        .HasColumnType("text");

                    b.Property<DateTime?>("StartDay")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("TimeOccur");

                    b.HasKey("Id");

                    b.ToTable("botSchedule");
                });
#pragma warning restore 612, 618
        }
    }
}