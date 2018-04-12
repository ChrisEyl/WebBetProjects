using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebBet.Migrations
{
    public partial class UpdateWebBetDbBetMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(nullable: false),
                    IdCrypt = table.Column<Guid>(nullable: false),
                    OddDraw = table.Column<int>(nullable: false),
                    OddTeam1 = table.Column<int>(nullable: false),
                    OddTeam2 = table.Column<int>(nullable: false),
                    Team1 = table.Column<string>(nullable: false),
                    Team2 = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paris",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    IdCrypt = table.Column<Guid>(nullable: false),
                    MatchId = table.Column<int>(nullable: false),
                    Result = table.Column<int>(nullable: false),
                    State = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paris_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paris_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paris_MatchId",
                table: "Paris",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Paris_UserId",
                table: "Paris",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paris");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
