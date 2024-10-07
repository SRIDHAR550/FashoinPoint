using Fashion.Domin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Application.Interfaces
{
    public interface IClothesRepository:IGenericRepository<Clothes>
    {
        Task Update(Clothes clothes);
    }

}
