using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InClass08.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tvcLoaiSanPham",
                columns: table => new
                {
                    tvcId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tvcMaLoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    tvcTenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tvcTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tvcLoaiSanPham", x => x.tvcId);
                });

            migrationBuilder.CreateTable(
                name: "tvcSanPham",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tvcMaSanPham = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    tvcTenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvcHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tvcSoLuong = table.Column<int>(type: "int", nullable: false),
                    tvcDonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tvcLoaiSanPhamId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tvcSanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tvcSanPham_tvcLoaiSanPham_tvcLoaiSanPhamId",
                        column: x => x.tvcLoaiSanPhamId,
                        principalTable: "tvcLoaiSanPham",
                        principalColumn: "tvcId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tvcLoaiSanPham_tvcMaLoai",
                table: "tvcLoaiSanPham",
                column: "tvcMaLoai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tvcSanPham_tvcLoaiSanPhamId",
                table: "tvcSanPham",
                column: "tvcLoaiSanPhamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tvcSanPham");

            migrationBuilder.DropTable(
                name: "tvcLoaiSanPham");
        }
    }
}
