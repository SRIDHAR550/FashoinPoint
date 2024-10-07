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
    public class ClothesRepository:GenericRepository<Clothes>,IClothesRepository
    {
        public ClothesRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            
        }

        public async Task Update(Clothes clothes)
        {
            var objFromDb = await _dbContext.Clothes.FirstOrDefaultAsync(x => x.Id == clothes.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = clothes.Name;

            }
            _dbContext.Update(objFromDb);
        }
    }
}
