using Fashion.Domin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Application.Interfaces
{
    public interface INewDropRepository:IGenericRepository<NewDrops>
    {
        Task Update(NewDrops newDrops);
        Task<NewDrops> GetNewDropsById(Guid id);
        Task<List<NewDrops>> GetAllNewDrops();
    }
}
