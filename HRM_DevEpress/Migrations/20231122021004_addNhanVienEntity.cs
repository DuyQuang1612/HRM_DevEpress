using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_DevEpress.Migrations
{
    /// <inheritdoc />
    public partial class addNhanVienEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    ChucVuId = table.Column<int>(type: "int", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QueQuan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DienThoai = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    MaChucVu = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MaNhanVien = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MaPhongBan = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NgayKyHopDongChinhThuc = table.Column<DateTime>(type: "date", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    NgayVaoCongTy = table.Column<DateTime>(type: "date", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QueQuan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoCanCuoc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                });
        }
    }
}
