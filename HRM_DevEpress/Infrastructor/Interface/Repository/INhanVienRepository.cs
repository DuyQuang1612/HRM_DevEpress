using HRM.Web.Entities;
using HRM_DevEpress.Models;

namespace HRM_DevEpress.Infrastructor.Interface.Repository
{
    public interface INhanVienRepository
    {
        Task<List<NhanVienEntity>> GetAllAsync();
        Task<NhanVienEntity> GetAsync(int id);
        Task<int> InsertAsync(NhanVienEntity entity);
        Task<int> UpdateAsync(NhanVienEntity entity);
        Task<int> DeleteAsync(NhanVienEntity entity);
        Task<NhanVienEntity> GetEmployeeByCode(string code);
        Task<NhanVienEntity> GetLastEmployee();
     
    }
}
