using Microsoft.EntityFrameworkCore.Query;
using SampleSchoolManagermentV1.Model;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using X.PagedList;

namespace SampleSchoolManagermentV1.Repository.General
{
    public interface IGenericRepository<T> where T: class
        
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IPagedList<T>> GetPagedList(RequestPaginate requestPaginate, List<string> include = null);


    }
}
