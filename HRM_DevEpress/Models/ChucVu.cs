namespace HRM_DevEpress.Models
{
    public class ChucVu
    {
        public int Id { get; set; }

        public string MaChucVu { get; set; } = null!;

        public string TenChucVu { get; set; } = null!;

        public int TrangThai { get; set; }

        public string? NguoiTao { get; set; }

        public DateTime? ThoiGianTao { get; set; }
    }
}
