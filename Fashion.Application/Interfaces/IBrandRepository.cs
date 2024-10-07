using Fashion.Domin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Application.Interfaces
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task Update(Brand brand);
    }
}
