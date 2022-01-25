using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcProject.Migrations.MvcProject
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Localization = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.LeagueId);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Nickname = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    CountryOfBirth = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Seazon",
                columns: table => new
                {
                    SeazonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LeagueId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seazon", x => x.SeazonId);
                    table.ForeignKey(
                        name: "FK_Seazon_League_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "League",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    SeazonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Classification = table.Column<int>(type: "INTEGER", nullable: false),
                    TopPlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    JungPlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    MidPlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdcPlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    SuppPlayerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Player_AdcPlayerId",
                        column: x => x.AdcPlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Player_JungPlayerId",
                        column: x => x.JungPlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Player_MidPlayerId",
                        column: x => x.MidPlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Player_SuppPlayerId",
                        column: x => x.SuppPlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Player_TopPlayerId",
                        column: x => x.TopPlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Seazon_SeazonId",
                        column: x => x.SeazonId,
                        principalTable: "Seazon",
                        principalColumn: "SeazonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seazon_LeagueId",
                table: "Seazon",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_AdcPlayerId",
                table: "Team",
                column: "AdcPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_JungPlayerId",
                table: "Team",
                column: "JungPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_MidPlayerId",
                table: "Team",
                column: "MidPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_SeazonId",
                table: "Team",
                column: "SeazonId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_SuppPlayerId",
                table: "Team",
                column: "SuppPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_TopPlayerId",
                table: "Team",
                column: "TopPlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Seazon");

            migrationBuilder.DropTable(
                name: "League");
        }
    }
}
