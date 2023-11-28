using HRM.Web.Entities;

namespace HRM_DevEpress.Infrastructor.Interface.Repository
{
    public interface IChucVuRepository
    {
        Task<List<ChucVuEntity>> GetAllAsync();
        Task<ChucVuEntity> GetAsync(int id);
        Task<int> InsertAsync(ChucVuEntity entity);
        Task<int> UpdateAsync(ChucVuEntity entity);
        Task<int> DeleteAsync(ChucVuEntity entity);
        Task<ChucVuEntity> GetPositionByCode(string code);
    }
}
