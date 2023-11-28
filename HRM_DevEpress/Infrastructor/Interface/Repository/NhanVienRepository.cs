using HRM.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRM_DevEpress.Infrastructor.Interface.Repository
{
    public class NhanVienRepository : INhanVienRepository
    {
        private readonly HrmTestContext _dbContext;
        public NhanVienRepository(HrmTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(NhanVienEntity entity)
        {
            _dbContext.NhanViens.Remove(entity);

            var result = await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<List<NhanVienEntity>> GetAllAsync()
        {
            var result = await _dbContext.NhanViens.ToListAsync();
            return result;
        }

        public async Task<NhanVienEntity> GetAsync(int id)
        {
            var reuslt = await _dbContext.NhanViens.FirstOrDefaultAsync(x => x.Id == id);
            return reuslt;
        }



        public async Task<NhanVienEntity> GetEmployeeByCode(string code)
        {
            var result = await _dbContext.NhanViens.FirstOrDefaultAsync(x => x.MaNhanVien == code);

            return result;
        }

        public Task<NhanVienEntity> GetLastEmployee()
        {
            var entity = _dbContext.NhanViens.OrderByDescending(x=>x.NgayTao).FirstOrDefaultAsync();
            return entity;
        }

        public int GetTotalEmployeeCount()
        {
            return _dbContext.NhanViens.Count();
        }


        public async Task<int> InsertAsync(NhanVienEntity entity)
        {

            int currentRecordCount = await _dbContext.NhanViens.CountAsync();

            _dbContext.NhanViens.Add(entity);

            var result = await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<int> UpdateAsync(NhanVienEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            var result = await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
