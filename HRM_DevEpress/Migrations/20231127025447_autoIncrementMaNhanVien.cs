using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRM_DevEpress.Migrations
{
    /// <inheritdoc />
    public partial class autoIncrementMaNhanVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutoIncrementMaNhanVien",
                table: "NhanViens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoIncrementMaNhanVien",
                table: "NhanViens");
        }
    }
}
