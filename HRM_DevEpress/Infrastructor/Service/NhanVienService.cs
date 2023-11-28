using AutoMapper;
using Newtonsoft.Json;
using HRM.Web.Entities;
using HRM_DevEpress.Infrastructor.Common;
using HRM_DevEpress.Infrastructor.Interface.Repository;
using HRM_DevEpress.Infrastructor.Model.Todo;
using HRM_DevEpress.Models;
using System.Text.RegularExpressions;

namespace HRM_DevEpress.Infrastructor.Service
{
    public class NhanVienService : INhanVienService
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IMapper _mapper;
        public NhanVienService(INhanVienRepository nhanvienRepository, IMapper mapper)
        {
            _nhanvienRepository = nhanvienRepository;
            _mapper = mapper;
        }
        public async Task<Result> DeleteAsync(int key)
        {
          
            string msg;
            try
            {
                var entity = await _nhanvienRepository.GetAsync(key);
                if (entity == null)
                {
                    msg = $"Không tìm thấy todo nào có id [{key}]";
                    return Result.ErrorResult(msg);
                }
                var result = await _nhanvienRepository.DeleteAsync(entity);
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

        public async Task<Result<List<NhanVienModel>>> GetAllAsync()
        {
            string msg;
            try
            {
                var result = await _nhanvienRepository.GetAllAsync();

                var models = _mapper.Map<List<NhanVienModel>>(result);

                return Result.SuccessResult(models);
            }
            catch (Exception ex)
            {
                msg = $"Có lỗi xảy ra khi lấy về danh sách todo";
                return Result.ExceptionResult<List<NhanVienModel>>(ex, msg);
            }
        }

        public async Task<Result> InsertAsync(string values)
        {
            string msg;
            try
            {
                var model = new NhanVienEntity();

                JsonConvert.PopulateObject(values, model);


                var duplicateEmployee = await _nhanvienRepository.GetEmployeeByCode(model.MaNhanVien);

                if(duplicateEmployee != null)
                {
                    var error = $"Mã nhân viên [{model.MaNhanVien}] đã tồn tại";
                    return Result.ErrorResult(error);
                }

                var result = await _nhanvienRepository.InsertAsync(model);
                if (result <= 0)
                {
                    msg = "Thêm mới nhân viên không thành công";
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
                var entity = await _nhanvienRepository.GetAsync(key);
                if (entity == null)
                {
                    return Result.ErrorResult($"Không tìm thấy todo với id [{key}]");
                }

                JsonConvert.PopulateObject(values, entity);

                var result = await _nhanvienRepository.UpdateAsync(entity);
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

        //public void a()
        //{
        //    var a = _nhanvienRepository.GetLastEmployee();
        //}
        public async Task<string?> GetLastEmployeeCode()
        {
            var lastEmployee = await _nhanvienRepository.GetLastEmployee();
            if (lastEmployee != null)
            {
                var numericPart = Regex.Match(lastEmployee.MaNhanVien ?? "", @"\d+$").Value;
                return !string.IsNullOrEmpty(numericPart) && numericPart.Length > 0
                    ? "NV" + (int.Parse(numericPart) + 1)
                    : null;
            }

            return "NV1";
        }
    }
}
