using AutoMapper;
using Newtonsoft.Json;
using HRM.Web.Entities;
using HRM_DevEpress.Infrastructor.Common;
using HRM_DevEpress.Infrastructor.Interface.Repository;
using HRM_DevEpress.Infrastructor.Model.Todo;

namespace HRM_DevEpress.Infrastructor.Service
{
    public class ChucVuService : IChucVuService
    {
        private readonly IChucVuRepository _chucvuRepository;
        private readonly IMapper _mapper;
        public ChucVuService(IChucVuRepository chucvuRepository, IMapper mapper)
        {
            _chucvuRepository = chucvuRepository;
            _mapper = mapper;
        }
        public async Task<Result> DeleteAsync(int key)
        {
          
            string msg;
            try
            {
                var entity = await _chucvuRepository.GetAsync(key);
                if (entity == null)
                {
                    msg = $"Không tìm thấy todo nào có id [{key}]";
                    return Result.ErrorResult(msg);
                }
                var result = await _chucvuRepository.DeleteAsync(entity);
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

        public async Task<Result<List<ChucVuModel>>> GetAllAsync()
        {
            string msg;
            try
            {
                var result = await _chucvuRepository.GetAllAsync();

                var models = _mapper.Map<List<ChucVuModel>>(result);

                return Result.SuccessResult(models);
            }
            catch (Exception ex)
            {
                msg = $"Có lỗi xảy ra khi lấy về danh sách todo";
                return Result.ExceptionResult<List<ChucVuModel>>(ex, msg);
            }
        }

        public async Task<Result> InsertAsync(string values)
        {
            string msg;
            try
            {
                var model = new ChucVuEntity();
                model.ThoiGianTao = DateTime.Now;
                //model.Id = Guid.NewGuid().ToString();

                JsonConvert.PopulateObject(values, model);

                var duplicatePosition = await _chucvuRepository.GetPositionByCode(model.MaChucVu);

                if (duplicatePosition != null)
                {
                    var error = $"Mã nhân viên [{model.MaChucVu}] đã tồn tại";
                    return Result.ErrorResult(error);
                }

                var result = await _chucvuRepository.InsertAsync(model);
                if (result <= 0)
                {
                    msg = "Thêm mới todo không thành công";
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
                var entity = await _chucvuRepository.GetAsync(key);
                if (entity == null)
                {
                    return Result.ErrorResult($"Không tìm thấy todo với id [{key}]");
                }

                JsonConvert.PopulateObject(values, entity);

                var result = await _chucvuRepository.UpdateAsync(entity);
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
