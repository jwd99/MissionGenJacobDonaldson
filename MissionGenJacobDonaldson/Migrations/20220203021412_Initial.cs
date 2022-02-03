using Microsoft.EntityFrameworkCore.Migrations;

namespace MissionGenJacobDonaldson.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    DirectorFirstName = table.Column<string>(nullable: false),
                    DirectorLastName = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Action" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "SciFi" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Drama/History" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieId", "CategoryId", "DirectorFirstName", "DirectorLastName", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Christopher", "Nolan", false, "", "Ches this is the best!", "PG-13", "The Dark Night", 2008 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieId", "CategoryId", "DirectorFirstName", "DirectorLastName", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 2, "George", "Lucas", false, "", "#r/prequelmemes for life", "PG-13", "Star Wars Episode III: Revenge of the Sith", 2005 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "MovieId", "CategoryId", "DirectorFirstName", "DirectorLastName", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 3, "Bryan", "Singer", false, "", "WWII Conspiracy Plot", "PG-13", "Valkyrie", 2008 });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoryId",
                table: "Responses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
