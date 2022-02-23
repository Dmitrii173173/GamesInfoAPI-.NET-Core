using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesInfo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameСategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameСategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameStudios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudioName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStudios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GameDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GameCategoryId = table.Column<int>(type: "int", nullable: false),
                    GameStudioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameСategories_GameCategoryId",
                        column: x => x.GameCategoryId,
                        principalTable: "GameСategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_GameStudios_GameStudioId",
                        column: x => x.GameStudioId,
                        principalTable: "GameStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameCategoryId",
                table: "Games",
                column: "GameCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameStudioId",
                table: "Games",
                column: "GameStudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameСategories");

            migrationBuilder.DropTable(
                name: "GameStudios");
        }
    }
}
