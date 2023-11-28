using HRM_DevEpress.Infrastructor.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using HRM_DevEpress.Common;
using HRM_DevEpress.Infrastructor.Service;
using HRM_DevEpress.Models;

namespace HRM_DevEpress.Controllers
{
    public class ChucVuController : Controller
    {
        private readonly IChucVuService _chucvuService;
        public ChucVuController(IChucVuService chucvuService)
        {
            _chucvuService = chucvuService;
        }
        public IActionResult Index()
        {
            DateTime currentDate = DateTime.Now;

            var model = new ChucVu
            {
                //FromDate = new DateTime(currentDate.Year, currentDate.Month, 1),
                //// DateTime.DaysInMonth - xác định số ngày trong tháng dựa vào năm và tháng
                //ToDate = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month)),
            };

            return View(model);
        }

        public async Task<IActionResult> LoadData()
        {
            var items = await _chucvuService.GetAllAsync();
            if (items.Data.Count <= 0)
            {
                return Json(null);
            }
            var result = items.Data.ConvertToLoadResult();
            return Json(result);
        }

        public async Task<IActionResult> Insert(string values)
        {
            string msg;
            try
            {
                var result = await _chucvuService.InsertAsync(values);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {
                msg = "Có lỗi xảy ra khi thêm mới chức vụ";
                return BadRequest(msg);
            }
        }

        public async Task<IActionResult> Update(int key, string values)
        {
            string msg;
            try
            {
                var result = await _chucvuService.UpdateAsync(key, values);
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
                var result = await _chucvuService.DeleteAsync(key);
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
