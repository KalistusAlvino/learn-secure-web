using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecureWeb.Migrations
{
    /// <inheritdoc />
    public partial class Tambah_Table_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nama",
                table: "Mahasiswas",
                newName: "Nama");

            migrationBuilder.RenameColumn(
                name: "alamat",
                table: "Mahasiswas",
                newName: "Alamat");

            migrationBuilder.RenameColumn(
                name: "nim",
                table: "Mahasiswas",
                newName: "Nim");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "Nama",
                table: "Mahasiswas",
                newName: "nama");

            migrationBuilder.RenameColumn(
                name: "Alamat",
                table: "Mahasiswas",
                newName: "alamat");

            migrationBuilder.RenameColumn(
                name: "Nim",
                table: "Mahasiswas",
                newName: "nim");
        }
    }
}
