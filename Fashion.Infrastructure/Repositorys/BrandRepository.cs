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
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }

        public async Task Update(Brand brand)
        {
            var objFromDb = await _dbContext.Brand.FirstOrDefaultAsync(x => x.Id == brand.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = brand.Name;
                objFromDb.Year = brand.Year;

                if (brand.BrandLogo != null)
                {
                    objFromDb.BrandLogo = brand.BrandLogo;
                }
            }
            _dbContext.Update(objFromDb);


        }
    }
}
