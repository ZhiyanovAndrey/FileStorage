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
                name: "FileExtention",
                columns: table => new
                {
                    ExtentionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Foto = table.Column<byte>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileExtention", x => x.ExtentionId);
                });

            migrationBuilder.CreateTable(
                name: "Folder",
                columns: table => new
                {
                    FolderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    FolderParentNameId = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folder", x => x.FolderId);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Description = table.Column<string>(type: "character varying", nullable: true),
                    Content = table.Column<string>(type: "character varying", nullable: true),
                    ExtentionId = table.Column<int>(type: "integer", nullable: false),
                    FileExtentionModelExtentionId = table.Column<int>(type: "integer", nullable: false),
                    FolderId = table.Column<int>(type: "integer", nullable: false),
                    FolderModelFolderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_File_FileExtention_FileExtentionModelExtentionId",
                        column: x => x.FileExtentionModelExtentionId,
                        principalTable: "FileExtention",
                        principalColumn: "ExtentionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Folder_FolderModelFolderId",
                        column: x => x.FolderModelFolderId,
                        principalTable: "Folder",
                        principalColumn: "FolderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_FileExtentionModelExtentionId",
                table: "File",
                column: "FileExtentionModelExtentionId");

            migrationBuilder.CreateIndex(
                name: "IX_File_FolderModelFolderId",
                table: "File",
                column: "FolderModelFolderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "FileExtention");

            migrationBuilder.DropTable(
                name: "Folder");
        }
    }
}
