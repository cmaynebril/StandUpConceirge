using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class dbMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "botAnswers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    botQuestionID = table.Column<int>(nullable: true),
                    RespondentID = table.Column<int>(nullable: true),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_botAnswers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "botQuestions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(type: "text", nullable: true),
                    botScheduleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_botQuestions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "botSchedule",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDay = table.Column<DateTime>(type: "date", nullable: true),
                    TimeOccur = table.Column<TimeSpan>(nullable: true),
                    DayOccur = table.Column<string>(type: "text", nullable: true),
                    FrequencyOccur = table.Column<string>(type: "text", nullable: true),
                    Respondents = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_botSchedule", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "botAnswers");

            migrationBuilder.DropTable(
                name: "botQuestions");

            migrationBuilder.DropTable(
                name: "botSchedule");
        }
    }
}
