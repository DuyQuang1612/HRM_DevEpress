using HRM.Web.Entities;

namespace HRM_DevEpress.Infrastructor.Interface.Repository
{
    public interface IPhongBanRepository
    {
        Task<List<PhongBanEntity>> GetAllAsync();
        Task<PhongBanEntity> GetAsync(int id);
        Task<int> InsertAsync(PhongBanEntity entity);
        Task<int> UpdateAsync(PhongBanEntity entity);
        Task<int> DeleteAsync(PhongBanEntity entity);
        Task<PhongBanEntity> GetDepartmentByCode(string code);
    }
}
