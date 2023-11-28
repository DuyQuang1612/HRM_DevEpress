using System;
using System.Collections.Generic;

namespace HRM.Web.Entities;

public partial class ChucVuEntity
{
    public int Id { get; set; }

    public string MaChucVu { get; set; } = null!;

    public string TenChucVu { get; set; } = null!;

    public int TrangThai { get; set; }

    public string? NguoiTao { get; set; }

    public DateTime? ThoiGianTao { get; set; }
}
