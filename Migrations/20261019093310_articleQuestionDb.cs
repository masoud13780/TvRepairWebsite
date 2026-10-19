using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TvRepairWebsite.Migrations
{
    /// <inheritdoc />
    public partial class articleQuestionDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Articles",
                newName: "Meta_Description");

            migrationBuilder.AddColumn<string>(
                name: "ArticleAddress",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Articles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Conclusion",
                table: "Articles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "Articles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Little_Description",
                table: "Articles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ArticleQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Awnser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleQuestions_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleQuestions_ArticleId",
                table: "ArticleQuestions",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleQuestions");

            migrationBuilder.DropColumn(
                name: "ArticleAddress",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Conclusion",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Little_Description",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Meta_Description",
                table: "Articles",
                newName: "Description");
        }
    }
}
