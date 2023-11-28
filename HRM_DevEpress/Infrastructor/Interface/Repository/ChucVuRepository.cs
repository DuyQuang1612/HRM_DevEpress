using HRM.Web.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HRM_DevEpress.Infrastructor.Interface.Repository
{
    public class ChucVuRepository : IChucVuRepository
    {
        private readonly HrmTestContext _dbContext;
        public ChucVuRepository(HrmTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(ChucVuEntity entity)
        {
            _dbContext.ChucVus.Remove(entity);

            var result = await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<List<ChucVuEntity>> GetAllAsync()
        {
            var result = await _dbContext.ChucVus.ToListAsync();
            return result;
        }

        public async Task<ChucVuEntity> GetAsync(int id)
        {
            var reuslt = await _dbContext.ChucVus.FirstOrDefaultAsync(x => x.Id == id);
            return reuslt;
        }

        public async Task<int> InsertAsync(ChucVuEntity entity)
        {
            _dbContext.ChucVus.Add(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
        public async Task<ChucVuEntity> GetPositionByCode(string code)
        {
            var result = await _dbContext.ChucVus.FirstOrDefaultAsync(x => x.MaChucVu == code);

            return result;
        }
        public async Task<int> UpdateAsync(ChucVuEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            var result = await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
