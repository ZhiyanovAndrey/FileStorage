using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FileStorage.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbSetFileExtentions",
                columns: table => new
                {
                    ExtentionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Foto = table.Column<byte>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetFileExtentions", x => x.ExtentionId);
                });

            migrationBuilder.CreateTable(
                name: "DbSetFiles",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ExtentionId = table.Column<string>(type: "text", nullable: false),
                    FolderId = table.Column<int>(type: "integer", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetFiles", x => x.FileId);
                });

            migrationBuilder.CreateTable(
                name: "DbSetFolders",
                columns: table => new
                {
                    FolderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FolderParentNameId = table.Column<string>(type: "text", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    filesFileId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSetFolders", x => x.FolderId);
                    table.ForeignKey(
                        name: "FK_DbSetFolders_DbSetFiles_filesFileId",
                        column: x => x.filesFileId,
                        principalTable: "DbSetFiles",
                        principalColumn: "FileId");
                });

            migrationBuilder.CreateTable(
                name: "FileExtentionFiles",
                columns: table => new
                {
                    fileExtentionExtentionId = table.Column<int>(type: "integer", nullable: false),
                    filesFileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileExtentionFiles", x => new { x.fileExtentionExtentionId, x.filesFileId });
                    table.ForeignKey(
                        name: "FK_FileExtentionFiles_DbSetFileExtentions_fileExtentionExtenti~",
                        column: x => x.fileExtentionExtentionId,
                        principalTable: "DbSetFileExtentions",
                        principalColumn: "ExtentionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileExtentionFiles_DbSetFiles_filesFileId",
                        column: x => x.filesFileId,
                        principalTable: "DbSetFiles",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbSetFolders_filesFileId",
                table: "DbSetFolders",
                column: "filesFileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileExtentionFiles_filesFileId",
                table: "FileExtentionFiles",
                column: "filesFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbSetFolders");

            migrationBuilder.DropTable(
                name: "FileExtentionFiles");

            migrationBuilder.DropTable(
                name: "DbSetFileExtentions");

            migrationBuilder.DropTable(
                name: "DbSetFiles");
        }
    }
}
