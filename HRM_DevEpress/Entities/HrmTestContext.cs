using System;
using System.Collections.Generic;
using HRM_DevEpress.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRM.Web.Entities;

public partial class HrmTestContext : DbContext
{
    public HrmTestContext()
    {
    }

    public HrmTestContext(DbContextOptions<HrmTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChucVuEntity> ChucVus { get; set; }

    public virtual DbSet<LuongNhanVienEntity> LuongNhanViens { get; set; }

    public virtual DbSet<NhanVienEntity> NhanViens { get; set; }

    public virtual DbSet<PhongBanEntity> PhongBans { get; set; }
    public virtual DbSet<LoginEntity> Logins { get; set; }
    public virtual DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChucVuEntity>(entity =>
        {
            entity.ToTable("ChucVu");

            entity.Property(e => e.MaChucVu)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenChucVu).HasMaxLength(50);
            entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");
        });

        modelBuilder.Entity<LuongNhanVienEntity>(entity =>
        {
            entity.ToTable("LuongNhanVien");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGianBatDau).HasColumnType("date");
            entity.Property(e => e.ThoiGianKetThuc).HasColumnType("date");
            entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");
            entity.Property(e => e.TienLuong).HasColumnType("decimal(18, 0)");
        });

        //modelBuilder.Entity<NhanVienEntity>(entity =>
        //{
        //    entity.ToTable("NhanVien");

        //    entity.Property(e => e.DienThoai)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.Email)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.GioiTinh).HasMaxLength(5);
        //    entity.Property(e => e.MaChucVu)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.MaNhanVien)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.MaPhongBan)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.NgayKyHopDongChinhThuc).HasColumnType("date");
        //    entity.Property(e => e.NgaySinh).HasColumnType("date");
        //    entity.Property(e => e.NgayVaoCongTy).HasColumnType("date");
        //    entity.Property(e => e.NguoiTao)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.QueQuan).HasMaxLength(50);
        //    entity.Property(e => e.SoCanCuoc)
        //        .HasMaxLength(50)
        //        .IsUnicode(false);
        //    entity.Property(e => e.TenNhanVien).HasMaxLength(50);
        //    entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");
        //});

        modelBuilder.Entity<PhongBanEntity>(entity =>
        {
            entity.ToTable("PhongBan");

            entity.Property(e => e.MaPhongBan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenPhongBan).HasMaxLength(50);
            entity.Property(e => e.ThoiGianTao).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
