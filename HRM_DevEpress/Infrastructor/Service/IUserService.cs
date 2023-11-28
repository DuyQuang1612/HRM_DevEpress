using HRM_DevEpress.Infrastructor.Common;
using HRM_DevEpress.Infrastructor.Model.Todo;

namespace HRM_DevEpress.Infrastructor.Service
{
    public interface IUserService
    {
        Task<Result<List<PhongBanModel>>> GetAllAsync();
        Task<Result> InsertAsync(string values);
        Task<Result> UpdateAsync(int key, string values);
        Task<Result> DeleteAsync(int key);
    }
}
