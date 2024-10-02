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
                    FileExtentionModelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Foto = table.Column<byte>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileExtention", x => x.FileExtentionModelId);
                });

            migrationBuilder.CreateTable(
                name: "Folder",
                columns: table => new
                {
                    FolderModelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    FolderParentNameId = table.Column<string>(type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folder", x => x.FolderModelId);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileModelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying", nullable: false),
                    Description = table.Column<string>(type: "character varying", nullable: true),
                    Content = table.Column<string>(type: "character varying", nullable: true),
                    FileExtentionModelId = table.Column<int>(type: "integer", nullable: false),
                    FolderModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileModelId);
                    table.ForeignKey(
                        name: "FK_File_FileExtention_FileExtentionModelId",
                        column: x => x.FileExtentionModelId,
                        principalTable: "FileExtention",
                        principalColumn: "FileExtentionModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Folder_FolderModelId",
                        column: x => x.FolderModelId,
                        principalTable: "Folder",
                        principalColumn: "FolderModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_FileExtentionModelId",
                table: "File",
                column: "FileExtentionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_File_FolderModelId",
                table: "File",
                column: "FolderModelId");
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
