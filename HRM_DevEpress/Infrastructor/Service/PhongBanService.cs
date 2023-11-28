using AutoMapper;
using HRM.Web.Entities;
using HRM_DevEpress.Infrastructor.Common;
using HRM_DevEpress.Infrastructor.Interface.Repository;
using HRM_DevEpress.Infrastructor.Model.Todo;
using Newtonsoft.Json;

namespace HRM_DevEpress.Infrastructor.Service
{
    public class PhongBanService : IUserService
    {
        private readonly IPhongBanRepository _phongbanRepository;
        private readonly IMapper _mapper;
        public PhongBanService(IPhongBanRepository phongbanRepository, IMapper mapper)
        {
            _phongbanRepository = phongbanRepository;
            _mapper = mapper;
        }
        public async Task<Result> DeleteAsync(int key)
        {
          
            string msg;
            try
            {
                var entity = await _phongbanRepository.GetAsync(key);
                if (entity == null)
                {
                    msg = $"Không tìm thấy todo nào có id [{key}]";
                    return Result.ErrorResult(msg);
                }
                var result = await _phongbanRepository.DeleteAsync(entity);
                if (result <= 0)
                {
                    msg = $"Xóa bản ghi không thành công với có id [{key}]";
                    return Result.ErrorResult(msg);
                }
                return Result.SuccessResult();
            }
            catch (Exception ex)
            {
                msg = $"Có lỗi xảy ra khi xóa todo có id [{key}]";
                return Result.ExceptionResult(ex, msg);
            }
        }

        public async Task<Result<List<PhongBanModel>>> GetAllAsync()
        {
            string msg;
            try
            {
                var result = await _phongbanRepository.GetAllAsync();

                var models = _mapper.Map<List<PhongBanModel>>(result);

                return Result.SuccessResult(models);
            }
            catch (Exception ex)
            {
                msg = $"Có lỗi xảy ra khi lấy về danh sách todo";
                return Result.ExceptionResult<List<PhongBanModel>>(ex, msg);
            }
        }

        public async Task<Result> InsertAsync(string values)
        {
            string msg;
            try
            {
                var model = new PhongBanEntity();
                model.ThoiGianTao = DateTime.Now;
                //model.Id = Guid.NewGuid().ToString();

                JsonConvert.PopulateObject(values, model);

                var duplicateDepartment = await _phongbanRepository.GetDepartmentByCode(model.MaPhongBan);

                if (duplicateDepartment != null)
                {
                    var error = $"Mã nhân viên [{model.MaPhongBan}] đã tồn tại";
                    return Result.ErrorResult(error);
                }


                var result = await _phongbanRepository.InsertAsync(model);
                if (result <= 0)
                {
                    msg = "Thêm mới phòng ban không thành công";
                    return Result.ErrorResult(msg);
                }
                return Result.SuccessResult();
            }
            catch (Exception ex)
            {
                msg = "Có lỗi xảy ra khi thêm mới bản ghi";
                return Result.ExceptionResult(ex, msg);
            }
        }

        public async Task<Result> UpdateAsync(int key, string values)
        {
           
            string msg;
            try
            {
                var entity = await _phongbanRepository.GetAsync(key);
                if (entity == null)
                {
                    return Result.ErrorResult($"Không tìm thấy todo với id [{key}]");
                }

                JsonConvert.PopulateObject(values, entity);

                var result = await _phongbanRepository.UpdateAsync(entity);
                if (result <= 0)
                {
                    msg = "Cập nhật todo không thành công";
                    return Result.ErrorResult(msg);
                }
                return Result.SuccessResult();
            }
            catch (Exception ex)
            {
                msg = "Có lỗi xảy ra khi sửa mới bản ghi";
                return Result.ExceptionResult(ex, msg);
            }
        }
    }
}
