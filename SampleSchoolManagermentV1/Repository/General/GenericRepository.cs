using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SampleSchoolManagermentV1.Datas;
using SampleSchoolManagermentV1.Validation;
using System.Linq.Expressions;
using X.PagedList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SampleSchoolManagermentV1.Repository.General
{
    public class GenericRepository<T> : IGenericRepository<T> where
         T : class
    {
        protected readonly SchoolContext _schoolContext;
        protected GenericRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public async Task Add(T entity)
        {
            await _schoolContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _schoolContext.Set<T>().Remove(entity);
        }

        public async  Task<T> Get(int id)
        {
            return await _schoolContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _schoolContext.Set<T>().ToListAsync();
        }
        public void Update(T entity)
        {
            _schoolContext.Set<T>().Update(entity);
        }

        public async Task<IPagedList<T>> GetPagedList(RequestPaginate requestPaginate, List<string> include = null)
        {
            IQueryable<T> query = _schoolContext.Set<T>();
            if (include != null)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }
            return await query.AsNoTracking().ToPagedListAsync(requestPaginate.PageNumber, requestPaginate.PageSize);

        }

        public async Task<IList<T>> GetAllAsync(List<string> include = null)
        {
            IQueryable<T> query = _schoolContext.Set<T>();
            if (include != null)
            {
                foreach (var incudePropery in include)
                {
                    query = query.Include(incudePropery);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }
    }
}
