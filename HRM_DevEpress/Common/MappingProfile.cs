using AutoMapper;
using HRM.Web.Entities;
using HRM_DevEpress.Infrastructor.Model.Todo;
using HRM_DevEpress.Models;

namespace HRM_DevEpress.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {   //Map PhongBan
            CreateMap<PhongBanEntity, PhongBanModel>();
            CreateMap<PhongBanModel, PhongBanEntity>();
            CreateMap<PhongBanModel, PhongBan>();

            //Map ChucVu
            CreateMap<ChucVuEntity, ChucVuModel>();
            CreateMap<ChucVuModel, ChucVuEntity>();
            CreateMap<ChucVuModel, ChucVu>();

            //Map NhanVien
            CreateMap<NhanVienEntity, NhanVienModel>();
            CreateMap<NhanVienModel, NhanVienEntity>();
            CreateMap<NhanVienModel, NhanVien>();
        }
    }
}
