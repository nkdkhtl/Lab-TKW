using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class InitDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HOA_DON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoaDon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaKhachHang = table.Column<int>(type: "int", nullable: true),
                    NgayHoaDon = table.Column<DateTime>(type: "date", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "date", nullable: true),
                    HoTenKhachHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TongTriGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOA_DON", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HOA_DON_KHACH_HANG_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KHACH_HANG",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "QUAN_TRI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUAN_TRI", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CT_HOA_DON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoaDonID = table.Column<int>(type: "int", nullable: true),
                    SanPhamID = table.Column<int>(type: "int", nullable: true),
                    SoLuongMua = table.Column<int>(type: "int", nullable: true),
                    DonGiaMua = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CT_HOA_DON", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CT_HOA_DON_HOA_DON_HoaDonID",
                        column: x => x.HoaDonID,
                        principalTable: "HOA_DON",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CT_HOA_DON_SAN_PHAM_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SAN_PHAM",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CT_HOA_DON_HoaDonID",
                table: "CT_HOA_DON",
                column: "HoaDonID");

            migrationBuilder.CreateIndex(
                name: "IX_CT_HOA_DON_SanPhamID",
                table: "CT_HOA_DON",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_HOA_DON_MaKhachHang",
                table: "HOA_DON",
                column: "MaKhachHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CT_HOA_DON");

            migrationBuilder.DropTable(
                name: "QUAN_TRI");

            migrationBuilder.DropTable(
                name: "HOA_DON");
        }
    }
}
