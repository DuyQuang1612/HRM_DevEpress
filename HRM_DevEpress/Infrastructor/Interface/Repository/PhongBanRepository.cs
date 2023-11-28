using DevExpress.XtraRichEdit.Import.Html;
using DevExpress.XtraRichEdit.Model;
using HRM.Web.Entities;
using HRM_DevEpress.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace HRM_DevEpress.Infrastructor.Interface.Repository
{
    public class PhongBanRepository : IPhongBanRepository
    {
        private readonly HrmTestContext _dbContext;
        public PhongBanRepository(HrmTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> DeleteAsync(PhongBanEntity entity)
        {

            _dbContext.PhongBans.Remove(entity);

            var result = await _dbContext.SaveChangesAsync();

            return result;
        }

        public async Task<List<PhongBanEntity>> GetAllAsync()
        {
            var result = await _dbContext.PhongBans.ToListAsync();
            return result;
        }

        public async Task<PhongBanEntity> GetAsync(int id)
        {
            var reuslt = await _dbContext.PhongBans.FirstOrDefaultAsync(x => x.Id == id);
            return reuslt;
        }
        public async Task<PhongBanEntity> GetDepartmentByCode(string code)
        {
            var result = await _dbContext.PhongBans.FirstOrDefaultAsync(x => x.MaPhongBan == code);

            return result;
        }
        public async Task<int> InsertAsync(PhongBanEntity entity)
        {
            
                _dbContext.PhongBans.Add(entity);
                var result = await _dbContext.SaveChangesAsync();
                return result;
         

        }

        public async Task<int> UpdateAsync(PhongBanEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            var result = await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
