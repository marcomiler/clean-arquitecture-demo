using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.Core.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(int id);
        Task<int> Insert(T t);
        Task<int> Update(T t);
        Task<bool> Delete(int id);

    }
}
