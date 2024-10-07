using Fashion.Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        Task Create(T entity);
        Task Delete(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> Get(Expression<Func<T,bool>>predicate);
        Task<T> GetByIdAsync(Guid id);
        Task<bool> IsRecordExist(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Query();
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
    }
}
