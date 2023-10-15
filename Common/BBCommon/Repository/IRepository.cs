using System.Collections.Generic;


namespace BBCommon.Repository
{
    public interface IRepository<T> 
    {
        Task <T> GetById(int id);
        Task <IEnumerable<T>> GetAll();
        Task <bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}
