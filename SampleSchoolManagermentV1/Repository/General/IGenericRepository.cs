using Microsoft.EntityFrameworkCore.Query;
using SampleSchoolManagermentV1.Validation;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using X.PagedList;

namespace SampleSchoolManagermentV1.Repository.General
{
    public interface IGenericRepository<T> where T: class
        
    {
        Task<T> Get(int id, List<string> include = null);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IPagedList<T>> GetPagedList(RequestPaginate requestPaginate, List<string> include = null);

      
        Task<IList<T>> GetAllAsync(List<string> include = null);
    }
}
