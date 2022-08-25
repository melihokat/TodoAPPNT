using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNT.DataAccess.Context;
using TodoAppNT.DataAccess.İnterfaces;
using TodoAppNT.DataAccess.Repositories;

namespace TodoAppNT.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly TodoContext _context;

        public Uow(TodoContext context)
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
