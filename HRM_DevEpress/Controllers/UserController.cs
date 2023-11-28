using HRM_DevEpress.Infrastructor.Service;
using HRM_DevEpress.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRM_DevEpress.Controllers
{
    public class UserController : Controller
    private readonly IUserService _UserService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    public IActionResult Index()
    {
     

        var model = new User
        {
            //FromDate = new DateTime(currentDate.Year, currentDate.Month, 1),
            //// DateTime.DaysInMonth - xác định số ngày trong tháng dựa vào năm và tháng
            //ToDate = new DateTime(currentDate.Year, currentDate.Month, DateTime.DaysInMonth(currentDate.Year, currentDate.Month)),
        };

        return View(model);
    }

    public async Task<IActionResult> LoadData()
    {
        var items = await _userService.GetAllAsync();
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
            var result = await _userService.InsertAsync(values);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        catch (Exception ex)
        {
            msg = "Có lỗi xảy ra khi thêm mới todo";
            return BadRequest(msg);
        }
    }

    public async Task<IActionResult> Update(int key, string values)
    {
        string msg;
        try
        {
            var result = await _userService.UpdateAsync(key, values);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            msg = "Có lỗi xảy ra khi sửa mới phòng ban";
            return BadRequest(msg);
        }
    }

    public async Task<IActionResult> Delete(int key)
    {
        string msg;
        try
        {
            var result = await _userService.DeleteAsync(key);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            msg = "Có lỗi xảy ra khi xóa phòng ban";
            return BadRequest(msg);
        }
    }
}
