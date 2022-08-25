using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNT.DataAccess.Context;
using TodoAppNT.DataAccess.İnterfaces;

namespace TodoAppNT.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly TodoContext _context;
        public Repository(TodoContext context)
        {
            _context = context;
        }
        public async Task Create(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync() ; //Tüm liste geliyorsa bu listeyi izlemesin
        }

        public async Task<T> GetByFilter(System.Linq.Expressions.Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ? await _context.Set<T>().SingleOrDefaultAsync(filter):
                await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);

            //asnotracking eğer true ise contexte git setle sonra where filtersini çalıştır.
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
            //buradan bir id çektiğimiz zaman örnek Ramden düşene kadar Core onu inceler.
        }

        public IQueryable<T> GetQuerry()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(int id)
        {
            var deletedEntity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(deletedEntity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
