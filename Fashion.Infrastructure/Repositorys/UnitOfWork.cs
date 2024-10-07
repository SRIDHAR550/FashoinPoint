using Fashion.Application.Interfaces;
using Fashion.Infrastructure.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Infrastructure.Repositorys
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbcontext)
        {
            dbContext = dbcontext;
            Brand = new BrandRepository(dbContext);
            Clothes=new ClothesRepository(dbContext);
            NewDrops=new NewDropRepository(dbContext);

        }

        public IBrandRepository Brand { get; private set; }

        public IClothesRepository Clothes { get; private set; }

        public INewDropRepository NewDrops { get; private set; }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
