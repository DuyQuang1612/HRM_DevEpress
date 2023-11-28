namespace HRM_DevEpress.Models
{
    public class PhongBan
    {
        public int Id { get; set; }

        public string MaPhongBan { get; set; } = null!;

        public string TenPhongBan { get; set; } = null!;

        public int TrangThai { get; set; }

        public string? NguoiTao { get; set; }

        public DateTime? ThoiGianTao { get; set; }
    }
}
