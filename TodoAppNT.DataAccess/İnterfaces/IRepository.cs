using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppNT.DataAccess.İnterfaces
{
    public interface IRepository<T> where T : class,new()
    {
        Task<List<T>> GetAll();
        Task<T> GetById(object id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false); //Bir sorgu atarsan trackingsiz getirir , değiştirilmeyek yani..
        Task Create(T entity);
        void Update(T entity);
        void Remove(int id);

        IQueryable<T> GetQuerry();
    }
}
