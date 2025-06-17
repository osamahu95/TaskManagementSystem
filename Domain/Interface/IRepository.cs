using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IRepository<T> where T: class
    {
        Task<T> GetById(int Id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Update(T entity);
        void DeleteById(T entity);
        Task InsertOrUpdate(IEnumerable<T> entities);
    }
}
