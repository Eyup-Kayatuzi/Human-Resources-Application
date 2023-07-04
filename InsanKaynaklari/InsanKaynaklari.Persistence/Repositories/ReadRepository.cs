using InsanKaynaklari.Application.Interfaces.Repositories;
using InsanKaynaklari.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Persistence.Repositories
{
    public class ReadRepository<T> : Repository<T>, IReadRepository<T> where T : class
    {
        public ReadRepository(InsanKaynaklariDb context) : base(context)
        {
            
        }
        public IQueryable<T> GetAll()
        {
            return Tablo;
        }
        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Tablo.FirstOrDefault(predicate);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Tablo.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return Tablo.Where(predicate);
        }
        public IQueryable<T> GetWhereWithInclude(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> predicate2)
        {
            return Tablo.Where(predicate).Include(predicate2);
        }
    }
}
