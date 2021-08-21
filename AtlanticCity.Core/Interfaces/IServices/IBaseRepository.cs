using AtlanticCity.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCity.Core.Interfaces.IServices
{
    public interface IBaseService<T1, T2> where T1 : class
                                           where T2 : class
    {
        Task<Response> GetAll();
        Task<Response> Find(int id);
        Task<Response> Insert(T1 t1);
        Task<Response> Update(T2 t2);
        Task<Response> Delete(int id);
    }
}
