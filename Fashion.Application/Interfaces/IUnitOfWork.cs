using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBrandRepository Brand { get; }
        public IClothesRepository Clothes { get; }
        public INewDropRepository NewDrops { get; }

      
        Task SaveAsync();
    }
}
