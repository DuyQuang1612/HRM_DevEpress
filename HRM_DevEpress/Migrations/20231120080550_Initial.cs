using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_DevEpress.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaChucVu = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LuongNhanVien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TienLuong = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(type: "date", nullable: true),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "date", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LuongNhanVien", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaPhongBan = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MaChucVu = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    QueQuan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoCanCuoc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NgayVaoCongTy = table.Column<DateTime>(type: "date", nullable: false),
                    NgayKyHopDongChinhThuc = table.Column<DateTime>(type: "date", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhongBan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhongBan = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    NguoiTao = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBan", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "LuongNhanVien");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "PhongBan");
        }
    }
}
