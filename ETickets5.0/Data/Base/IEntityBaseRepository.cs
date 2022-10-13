using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ETickets5._0.Data.Base
{
    public interface IEntityBaseRepository <T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> getallasync();

        Task<IEnumerable<T>> getallasync(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByIdasync(int id);

        Task Addasync(T entity);

        Task UpdateAsync(int id, T entity);

        Task Deleteasync(int id);
    }
}
