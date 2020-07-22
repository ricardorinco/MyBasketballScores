using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBasketballScores.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameDate = table.Column<DateTime>(nullable: false),
                    TotalScore = table.Column<int>(nullable: false),
                    IsRecord = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Score");
        }
    }
}
