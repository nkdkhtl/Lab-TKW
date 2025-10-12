using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOAI_SAN_PHAM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAI_SAN_PHAM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SAN_PHAM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSanPham = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaLoai = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAN_PHAM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SAN_PHAM_LOAI_SAN_PHAM_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "LOAI_SAN_PHAM",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAM_MaLoai",
                table: "SAN_PHAM",
                column: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SAN_PHAM");

            migrationBuilder.DropTable(
                name: "LOAI_SAN_PHAM");
        }
    }
}
