using System;
using System.Collections.Generic;

namespace HRM.Web.Entities;

public partial class LuongNhanVienEntity
{
    public int Id { get; set; }

    public string? MaNhanVien { get; set; }

    public decimal? TienLuong { get; set; }

    public DateTime? ThoiGianBatDau { get; set; }

    public DateTime? ThoiGianKetThuc { get; set; }

    public int? Nam { get; set; }

    public DateTime? ThoiGianTao { get; set; }

    public string? NguoiTao { get; set; }
}
