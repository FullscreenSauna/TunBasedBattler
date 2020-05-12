using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace TurnBasedBattler.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "heroes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    @class = table.Column<string>(name: "class", unicode: false, maxLength: 20, nullable: false),
                    hp = table.Column<int>(type: "int(11)", nullable: false),
                    attack = table.Column<int>(type: "int(11)", nullable: false),
                    defence = table.Column<int>(type: "int(11)", nullable: false),
                    magic = table.Column<int>(type: "int(11)", nullable: false),
                    dodge = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    player_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heroes", x => x.id);
                    table.ForeignKey(
                        name: "fk_heroes_players",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "name",
                table: "heroes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_heroes_players",
                table: "heroes",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "username",
                table: "players",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "heroes");

            migrationBuilder.DropTable(
                name: "players");
        }
    }
}
