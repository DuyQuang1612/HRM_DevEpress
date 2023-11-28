using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HRM_DevEpress.Infrastructor.Model.Todo
{
    public class NhanVienModel
    {
        public int Id { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int PhongBanId { get; set; }
        public int ChucVuId { get; set; }

        [DataType(DataType.Date)]

        public DateTime? NgaySinh { get; set; }
        public int GioiTinh { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? QueQuan { get; set; }
        public string? CCCD { get; set; }
        public DateTime? NgayTao { get; set; }
        public string NguoiTao { get; set; }
        public List<SelectListItem> PhongBans { get; set; }
        public List<SelectListItem> ChucVus { get; set; }
    }
}
