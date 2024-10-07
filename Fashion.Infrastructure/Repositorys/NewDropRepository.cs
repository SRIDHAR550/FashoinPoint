using Fashion.Application.Interfaces;
using Fashion.Domin.Model;
using Fashion.Infrastructure.DbConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Infrastructure.Repositorys
{
    public class NewDropRepository:GenericRepository<NewDrops>,INewDropRepository
    {
        public NewDropRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            
        }

        public async Task<List<NewDrops>> GetAllNewDrops()
        {
            return await _dbContext.NewDrops.Include(x => x.Brand).Include(x => x.Clothes).ToListAsync();
        }

        public async Task<NewDrops> GetNewDropsById(Guid id)
        {
            return await _dbContext.NewDrops.Include(x => x.Brand).Include(x => x.Clothes).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(NewDrops newDrops)
        {
            var objFromDb = await _dbContext.NewDrops.FirstOrDefaultAsync(x => x.Id == newDrops.Id);
            if (objFromDb != null)
            {
                objFromDb.BrandId = newDrops.BrandId;

                objFromDb.ClothesID = newDrops.ClothesID;

                objFromDb.ClotheName = newDrops.ClotheName;

                objFromDb.Sizes = newDrops.Sizes;

                objFromDb.Price = newDrops.Price;

                objFromDb.Quantities = newDrops.Quantities;

                if (newDrops.ClotheImage != null)
                {

                    objFromDb.ClotheImage = newDrops.ClotheImage;

                }
                _dbContext.Update(objFromDb);
            }
        }
    }
}
