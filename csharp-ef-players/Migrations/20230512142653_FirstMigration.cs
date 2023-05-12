using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_ef_players.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "playerList",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Punteggio = table.Column<double>(type: "float", nullable: false),
                    PartiteGiocate = table.Column<int>(type: "int", nullable: false),
                    PartiteVinte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerList", x => x.PlayerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_playerList_PlayerId",
                table: "playerList",
                column: "PlayerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playerList");
        }
    }
}
