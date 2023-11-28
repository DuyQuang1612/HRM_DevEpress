using HRM_DevEpress.Common;
using HRM_DevEpress.Infrastructor.Model;
using HRM_DevEpress.Infrastructor.Service;
using HRM_DevEpress.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRM_DevEpress.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly INhanVienService _nhanvienService;
        private readonly IChucVuService _chucVu;
        private readonly IUserService _phongBan;


        public NhanVienController(INhanVienService nhanvienService, IChucVuService chucVu, IUserService phongBan)
        {
            _nhanvienService = nhanvienService;
            _chucVu = chucVu;
            _phongBan = phongBan;
        }

        //[Authorize]
        public async Task<IActionResult> Index()
        {
            DateTime currentDate = DateTime.Now;

            var model = new NhanVien
            {
                //FromDate = new DateTime(currentDate.Year, currentDate.Month, 1),
                //// DateTime.DaysInMonth - xác định số ngày trong tháng dựa vào năm và tháng
                //ToDate = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month)),
            };
        //    model.GioiTinh = new List<StringAsLookupItem>
        //{
        //    new StringAsLookupItem { Name = "Nam", Value = "Nam" },
        //    new StringAsLookupItem { Name = "Nữ", Value = "Nu" }
        //};


            //Get: ListChucVu/ListPhongBan
            var lstChucVu = new List<StringAsLookupItem>();
            var lstPhongBan = new List<StringAsLookupItem>();

            var resultChucVu = await _chucVu.GetAllAsync();
            var reultPhongBan = await _phongBan.GetAllAsync();

            if (resultChucVu.Success)
            {
                lstChucVu = resultChucVu.Data.Select(x=>new StringAsLookupItem(x.TenChucVu,x.Id)).ToList();
            } 
            
            if (reultPhongBan.Success)
            {
                lstPhongBan = reultPhongBan.Data.Select(x=>new StringAsLookupItem(x.TenPhongBan,x.Id)).ToList();
            }

            model.ChucVus = lstChucVu;
            model.PhongBans = lstPhongBan;

            return View(model);
        }

        public async Task<IActionResult> LoadData()
        {
            var items = await _nhanvienService.GetAllAsync();
            if (items.Data.Count <= 0)
            {
                return Json(items.Data);
            }
            var result = items.Data.ConvertToLoadResult();
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetLastEmployeeCode()
        {
            var lastEmployeeCode = await _nhanvienService.GetLastEmployeeCode();
            return Json(lastEmployeeCode);
        }
        public async Task<IActionResult> Insert(string values, string maNhanVien)
        {
            string msg;
            try
            {
                var result = await _nhanvienService.InsertAsync(values);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
                
            }
            catch (Exception ex)
            {
                msg = "Có lỗi xảy ra khi thêm mới nhân viên";
                return BadRequest(msg);
            }
        }

        public async Task<IActionResult> Update(int key, string values)
        {
            string msg;
            try
            {
                var result = await _nhanvienService.UpdateAsync(key, values);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                msg = "Có lỗi xảy ra khi sửa mới todo";
                return BadRequest(msg);
            }
        }

        public async Task<IActionResult> Delete(int key)
        {
            string msg;
            try
            {
                var result = await _nhanvienService.DeleteAsync(key);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                msg = "Có lỗi xảy ra khi xóa mới todo";
                return BadRequest(msg);
            }
        }
    }
}
